using System;
using System.IO.Ports;

namespace serialPort
{

    public enum ModbusError
    {
        Ok = 0,
        CrcError = -1,
        LengthError = -2,
        FuncError = -3,
        Exception = -4
    }

    /// <summary>
    /// 纯 RTU 协议实现：组帧 + CRC + 解析
    /// 串口读写你可以用 SerialPort 自己实现，也可以用下面的 SendAndReceive 辅助方法。
    /// </summary>
    public class ModbusRtuClient : IDisposable
    {
        private readonly SerialPort _port;

        public ModbusRtuClient(string portName,
                               int baudRate = 9600,
                               Parity parity = Parity.None,
                               int dataBits = 8,
                               StopBits stopBits = StopBits.One)
        {
            _port = new SerialPort(portName, baudRate, parity, dataBits, stopBits)
            {
                ReadTimeout = 500,
                WriteTimeout = 500
            };
        }

        public SerialPort Port => _port;

        public void Open()
        {
            if (!_port.IsOpen)
                _port.Open();
        }

        public void Close()
        {
            if (_port.IsOpen)
                _port.Close();
        }

        public void Dispose()
        {
            Close();
            _port.Dispose();
        }

        #region CRC16 (Modbus)

        public static ushort ComputeCrc(byte[] buffer, int length)
        {
            ushort crc = 0xFFFF;

            for (int i = 0; i < length; i++)
            {
                crc ^= buffer[i];
                for (int j = 0; j < 8; j++)
                {
                    bool lsb = (crc & 0x0001) != 0;
                    crc >>= 1;
                    if (lsb)
                        crc ^= 0xA001;
                }
            }
            return crc;
        }

        #endregion

        #region 组帧 – 通用内部函数

        public static byte[] BuildReadRequest(byte slave, byte func,
                                               ushort startAddr, ushort quantity)
        {
            var frame = new byte[8];
            frame[0] = slave;
            frame[1] = func;
            frame[2] = (byte)(startAddr >> 8);
            frame[3] = (byte)(startAddr & 0xFF);
            frame[4] = (byte)(quantity >> 8);
            frame[5] = (byte)(quantity & 0xFF);

            ushort crc = ComputeCrc(frame, 6);
            frame[6] = (byte)(crc & 0xFF);       // CRC Lo
            frame[7] = (byte)(crc >> 8);         // CRC Hi

            return frame;
        }

        private static byte[] BuildWriteSingle(byte slave, byte func,
                                               ushort addr, ushort value)
        {
            var frame = new byte[8];
            frame[0] = slave;
            frame[1] = func;
            frame[2] = (byte)(addr >> 8);
            frame[3] = (byte)(addr & 0xFF);
            frame[4] = (byte)(value >> 8);
            frame[5] = (byte)(value & 0xFF);

            ushort crc = ComputeCrc(frame, 6);
            frame[6] = (byte)(crc & 0xFF);
            frame[7] = (byte)(crc >> 8);

            return frame;
        }

        public static byte[] BuildWriteMulti(byte slave, byte func,
                                             ushort startAddr, ushort quantity,
                                             byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            int len = 7 + data.Length + 2;
            var frame = new byte[len];

            frame[0] = slave;
            frame[1] = func;
            frame[2] = (byte)(startAddr >> 8);
            frame[3] = (byte)(startAddr & 0xFF);
            frame[4] = (byte)(quantity >> 8);
            frame[5] = (byte)(quantity & 0xFF);
            frame[6] = (byte)data.Length; // Byte count
            Buffer.BlockCopy(data, 0, frame, 7, data.Length);

            ushort crc = ComputeCrc(frame, 7 + data.Length);
            frame[7 + data.Length] = (byte)(crc & 0xFF);
            frame[7 + data.Length + 1] = (byte)(crc >> 8);

            return frame;
        }

        #endregion

        #region 组帧 – 对外 API

        // 0x01 读线圈
        public static byte[] BuildReadCoilsRequest(byte slave, ushort addr, ushort quantity)
        {
            return BuildReadRequest(slave, 0x01, addr, quantity);
        }

        // 0x02 读离散量输入
        public static byte[] BuildReadDiscreteInputsRequest(byte slave, ushort addr, ushort quantity)
        {
            return BuildReadRequest(slave, 0x02, addr, quantity);
        }

        // 0x03 读保持寄存器
        public static byte[] BuildReadHoldingRegistersRequest(byte slave, ushort addr, ushort quantity)
        {
            return BuildReadRequest(slave, 0x03, addr, quantity);
        }

        // 0x04 读输入寄存器
        public static byte[] BuildReadInputRegistersRequest(byte slave, ushort addr, ushort quantity)
        {
            return BuildReadRequest(slave, 0x04, addr, quantity);
        }

        // 0x05 写单个线圈
        public static byte[] BuildWriteSingleCoilRequest(byte slave, ushort addr, bool on)
        {
            ushort value = on ? (ushort)0xFF00 : (ushort)0x0000;
            return BuildWriteSingle(slave, 0x05, addr, value);
        }

        // 0x06 写单个寄存器
        public static byte[] BuildWriteSingleRegisterRequest(byte slave, ushort addr, ushort value)
        {
            return BuildWriteSingle(slave, 0x06, addr, value);
        }

        // 0x0F 写多个线圈 – bitsPacked 按位打包（bit0 对应起始线圈）
        public static byte[] BuildWriteMultipleCoilsRequest(byte slave, ushort addr,
                                                            ushort quantity, byte[] bitsPacked)
        {
            if (bitsPacked == null)
                throw new ArgumentNullException(nameof(bitsPacked));
            return BuildWriteMulti(slave, 0x0F, addr, quantity, bitsPacked);
        }

        // 0x10 写多个寄存器 – regs 是寄存器数组
        public static byte[] BuildWriteMultipleRegistersRequest(byte slave, ushort addr,
                                                                ushort quantity, ushort[] regs)
        {
            if (regs == null)
                throw new ArgumentNullException(nameof(regs));
            if (regs.Length < quantity)
                throw new ArgumentException("regs length < quantity");

            byte[] data = new byte[quantity * 2];
            for (int i = 0; i < quantity; i++)
            {
                data[i * 2] = (byte)(regs[i] >> 8);
                data[i * 2 + 1] = (byte)(regs[i] & 0xFF);
            }
            return BuildWriteMulti(slave, 0x10, addr, quantity, data);
        }

        #endregion

        #region 解析 – 应答帧

        // 解析读位(0x01/0x02)响应
        public static ModbusError ParseReadBitsResponse(
            byte[] frame,
            int length,
            byte expectedSlave,
            byte expectedFunc,
            byte[] bitsOut,     // 每 bit 一个字节，0 或 1
            out int bitCount)
        {
            bitCount = 0;
            if (frame == null || bitsOut == null)
                return ModbusError.LengthError;
            if (length < 5)
                return ModbusError.LengthError;

            ushort crcCalc = ComputeCrc(frame, length - 2);
            ushort crcRecv = (ushort)(frame[length - 2] | (frame[length - 1] << 8));
            if (crcCalc != crcRecv)
                return ModbusError.CrcError;

            byte slave = frame[0];
            byte func = frame[1];
            if (slave != expectedSlave)
                return ModbusError.FuncError;
            if ((func & 0x80) != 0)
                return ModbusError.Exception;
            if (func != expectedFunc)
                return ModbusError.FuncError;

            byte byteCount = frame[2];
            if (length != 3 + byteCount + 2)
                return ModbusError.LengthError;

            int index = 0;
            for (int i = 0; i < byteCount && index < bitsOut.Length; i++)
            {
                byte b = frame[3 + i];
                for (int j = 0; j < 8 && index < bitsOut.Length; j++)
                {
                    bitsOut[index++] = (byte)((b >> j) & 0x01);
                }
            }
            bitCount = index;
            return ModbusError.Ok;
        }

        // 解析读寄存器(0x03/0x04)响应
        public static ModbusError ParseReadRegistersResponse(
            byte[] frame,
            int length,
            byte expectedSlave,
            byte expectedFunc,
            ushort[] regsOut,
            out int regCount)
        {
            regCount = 0;
            if (frame == null || regsOut == null)
                return ModbusError.LengthError;
            if (length < 5)
                return ModbusError.LengthError;

            ushort crcCalc = ComputeCrc(frame, length - 2);
            ushort crcRecv = (ushort)(frame[length - 2] | (frame[length - 1] << 8));
            if (crcCalc != crcRecv)
                return ModbusError.CrcError;

            byte slave = frame[0];
            byte func = frame[1];
            if (slave != expectedSlave)
                return ModbusError.FuncError;
            if ((func & 0x80) != 0)
                return ModbusError.Exception;
            if (func != expectedFunc)
                return ModbusError.FuncError;

            byte byteCount = frame[2];
            if (length != 3 + byteCount + 2)
                return ModbusError.LengthError;

            int count = byteCount / 2;
            if (count > regsOut.Length)
                count = regsOut.Length;

            for (int i = 0; i < count; i++)
            {
                byte hi = frame[3 + i * 2];
                byte lo = frame[3 + i * 2 + 1];
                regsOut[i] = (ushort)((hi << 8) | lo);
            }

            regCount = count;
            return ModbusError.Ok;
        }

        // 解析写单个/多个(0x05/0x06/0x0F/0x10)响应
        public static ModbusError ParseWriteResponse(
            byte[] frame,
            int length,
            byte expectedSlave,
            byte expectedFunc)
        {
            if (frame == null || length < 8)
                return ModbusError.LengthError;

            ushort crcCalc = ComputeCrc(frame, length - 2);
            ushort crcRecv = (ushort)(frame[length - 2] | (frame[length - 1] << 8));
            if (crcCalc != crcRecv)
                return ModbusError.CrcError;

            byte slave = frame[0];
            byte func = frame[1];
            if (slave != expectedSlave)
                return ModbusError.FuncError;
            if ((func & 0x80) != 0)
                return ModbusError.Exception;
            if (func != expectedFunc)
                return ModbusError.FuncError;

            // frame[2..5] = 地址/数量，可按需再校验
            return ModbusError.Ok;
        }

        #endregion

        #region 串口发送/接收辅助（可选）

        /// <summary>
        /// 同步发送请求并接收指定长度的响应。
        /// 注意：Modbus RTU 实际长度是可计算的，建议根据功能码和数量计算 expectedLength。
        /// </summary>
        public byte[] SendAndReceive(byte[] request, int expectedLength, int timeoutMs = 500)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (!_port.IsOpen) throw new InvalidOperationException("SerialPort not open.");

            _port.DiscardInBuffer();
            _port.Write(request, 0, request.Length);

            _port.ReadTimeout = timeoutMs;

            var buffer = new byte[expectedLength];
            int offset = 0;

            while (offset < expectedLength)
            {
                int read = _port.Read(buffer, offset, expectedLength - offset);
                if (read <= 0) break;
                offset += read;
            }

            if (offset == expectedLength)
                return buffer;

            // 如果没读满，可以根据实际需要返回实际长度数据
            var real = new byte[offset];
            Buffer.BlockCopy(buffer, 0, real, 0, offset);
            return real;
        }

        #endregion
    }
}
