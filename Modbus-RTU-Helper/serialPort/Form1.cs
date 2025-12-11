using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace serialPort
{
    public partial class Form1 : Form
    {
        private ModbusRtuClient _modbusClient;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshPorts();

            comboBoxBaudRate.Items.AddRange(new object[] { 9600, 19200, 38400, 57600, 115200 });
            comboBoxBaudRate.SelectedIndex = 0;

            comboBoxParity.Items.AddRange(Enum.GetNames(typeof(Parity)));
            comboBoxParity.SelectedItem = Parity.None.ToString();

            comboBoxStopBits.Items.AddRange(Enum.GetNames(typeof(StopBits)));
            comboBoxStopBits.SelectedItem = StopBits.One.ToString();

            numericUpDownDataBits.Value = 8;
            numericUpDownSlaveId.Value = 1;

            comboBoxFunctionCode.Items.AddRange(new object[]
            {
                "0x01 读线圈",
                "0x02 读离散输入",
                "0x03 读保持寄存器",
                "0x04 读输入寄存器",
                "0x05 写单线圈",
                "0x06 写单寄存器",
                "0x0F 写多线圈",
                "0x10 写多寄存器"
            });
            comboBoxFunctionCode.SelectedIndex = 0;
            UpdateFunctionInputs();
            UpdateStatus();
        }

        private void RefreshPorts()
        {
            comboBoxComPort.Items.Clear();
            var ports = SerialPort.GetPortNames();
            comboBoxComPort.Items.AddRange(ports);
            if (ports.Length > 0)
                comboBoxComPort.SelectedIndex = 0;
            }

        private void buttonRefreshPorts_Click(object sender, EventArgs e)
        {
            RefreshPorts();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (_modbusClient != null)
            {
                MessageBox.Show("已连接，请先断开再切换串口。");
                return;
            }

            if (comboBoxComPort.SelectedItem == null)
            {
                MessageBox.Show("请选择串口。");
                return;
            }

            try
            {
                string portName = comboBoxComPort.SelectedItem.ToString();
                int baudRate = (int)comboBoxBaudRate.SelectedItem;
                Parity parity = (Parity)Enum.Parse(typeof(Parity), comboBoxParity.SelectedItem.ToString());
                int dataBits = (int)numericUpDownDataBits.Value;
                StopBits stopBits = (StopBits)Enum.Parse(typeof(StopBits), comboBoxStopBits.SelectedItem.ToString());

                _modbusClient = new ModbusRtuClient(portName, baudRate, parity, dataBits, stopBits);
                _modbusClient.Open();
                UpdateStatus();
            }
            catch (Exception ex)
            {
                _modbusClient = null;
                MessageBox.Show($"连接失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            DisconnectPort();
        }

        private void DisconnectPort()
        {
            try
            {
                _modbusClient?.Close();
            }
            catch
            {
                // ignore
            }
            _modbusClient = null;
            UpdateStatus();
        }

        private void UpdateStatus()
        {
            bool connected = _modbusClient != null && _modbusClient.Port.IsOpen;
            labelStatus.Text = connected ? $"已连接：{_modbusClient.Port.PortName}" : "未连接";
            buttonConnect.Enabled = !connected;
            buttonDisconnect.Enabled = connected;
            buttonSend.Enabled = connected;
        }

        private void comboBoxFunctionCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFunctionInputs();
        }

        private void UpdateFunctionInputs()
        {
            byte func = GetSelectedFunctionCode();
            
            // 功能说明
            string[] descriptions = {
                "读取线圈状态（ON/OFF）",
                "读取离散输入状态（ON/OFF）",
                "读取保持寄存器值（16位）",
                "读取输入寄存器值（16位）",
                "写入单个线圈（ON/OFF）",
                "写入单个寄存器值（0-65535）",
                "写入多个线圈（按位打包）",
                "写入多个寄存器（每2字节1个）"
            };
            if (comboBoxFunctionCode.SelectedIndex >= 0 && comboBoxFunctionCode.SelectedIndex < descriptions.Length)
            {
                labelFunctionDesc.Text = descriptions[comboBoxFunctionCode.SelectedIndex];
            }
            
            // 数量/点数：读操作和写多操作需要
            bool showQuantity = func <= 0x04 || func == 0x0F || func == 0x10;
            label9.Visible = showQuantity;
            numericUpDownQuantity.Visible = showQuantity;
            numericUpDownQuantity.Enabled = showQuantity;
            
            // 写单线圈：只显示复选框
            bool showWriteCoil = func == 0x05;
            label10.Visible = showWriteCoil;
            checkBoxCoilOn.Visible = showWriteCoil;
            checkBoxCoilOn.Enabled = showWriteCoil;
            labelWriteSingleCoil.Visible = showWriteCoil;
            textBoxWriteValue.Visible = false;
            labelWriteSingleReg.Visible = false;
            
            // 写单寄存器：只显示数值框
            bool showWriteReg = func == 0x06;
            if (showWriteReg)
            {
                label10.Text = "写单寄存器";
                label10.Visible = true;
                textBoxWriteValue.Visible = true;
                textBoxWriteValue.Enabled = true;
                labelWriteSingleReg.Visible = true;
            }
            else if (!showWriteCoil)
            {
                label10.Visible = false;
            }
            
            // 多写数据：写多线圈和写多寄存器需要
            bool showPayload = func == 0x0F || func == 0x10;
            label11.Visible = showPayload;
            textBoxPayload.Visible = showPayload;
            textBoxPayload.Enabled = showPayload;
            labelWriteMultiHint.Visible = showPayload;
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (_modbusClient == null || !_modbusClient.Port.IsOpen)
            {
                AppendLog("请先连接串口。");
                return;
            }

            byte slaveId = (byte)numericUpDownSlaveId.Value;
            
            if (!ushort.TryParse(textBoxStartAddress.Text, out ushort startAddr))
            {
                AppendLog("起始地址格式错误，请输入0-65535之间的数字。");
                return;
            }
            
            ushort quantity = (ushort)numericUpDownQuantity.Value;
            byte func = GetSelectedFunctionCode();

            byte[] request = null;
            int expected = 8;

            try
            {
                switch (func)
                {
                    case 0x01:
                        request = ModbusRtuClient.BuildReadCoilsRequest(slaveId, startAddr, quantity);
                        expected = 5 + ((quantity + 7) / 8);
                        break;
                    case 0x02:
                        request = ModbusRtuClient.BuildReadDiscreteInputsRequest(slaveId, startAddr, quantity);
                        expected = 5 + ((quantity + 7) / 8);
                        break;
                    case 0x03:
                        request = ModbusRtuClient.BuildReadHoldingRegistersRequest(slaveId, startAddr, quantity);
                        expected = 5 + quantity * 2;
                        break;
                    case 0x04:
                        request = ModbusRtuClient.BuildReadInputRegistersRequest(slaveId, startAddr, quantity);
                        expected = 5 + quantity * 2;
                        break;
                    case 0x05:
                        request = ModbusRtuClient.BuildWriteSingleCoilRequest(slaveId, startAddr, checkBoxCoilOn.Checked);
                        expected = 8;
                        break;
                    case 0x06:
                        if (!ushort.TryParse(textBoxWriteValue.Text, out ushort writeValue))
                        {
                            AppendLog("寄存器值格式错误，请输入0-65535之间的数字。");
                            return;
                        }
                        request = ModbusRtuClient.BuildWriteSingleRegisterRequest(slaveId, startAddr, writeValue);
                        expected = 8;
                        break;
                    case 0x0F:
                    case 0x10:
                        byte[] data = ParsePayload(textBoxPayload.Text);
                        request = ModbusRtuClient.BuildWriteMulti(slaveId, func, startAddr, quantity, data);
                        expected = 8;
                        break;
                    default:
                        MessageBox.Show("未支持的功能码。");
                        return;
                }

                var response = _modbusClient.SendAndReceive(request, expected);
                HandleResponse(func, response, slaveId, quantity);
            }
            catch (Exception ex)
            {
                AppendLog($"发送失败：{ex.Message}");
            }
        }

        private byte[] ParsePayload(string text)
        {
            // 输入格式：以空格或逗号分隔的十六进制字节，如 "01 02 03" 或 "01,02,03"
            var parts = text.Split(new[] { ' ', ',', ';', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            return parts.Select(p => Convert.ToByte(p, 16)).ToArray();
        }

        private byte GetSelectedFunctionCode()
        {
            switch (comboBoxFunctionCode.SelectedIndex)
            {
                case 0: return 0x01;
                case 1: return 0x02;
                case 2: return 0x03;
                case 3: return 0x04;
                case 4: return 0x05;
                case 5: return 0x06;
                case 6: return 0x0F;
                case 7: return 0x10;
                default: return 0;
            }
        }

        private void HandleResponse(byte func, byte[] response, byte slaveId, ushort quantity)
        {
            if (response == null || response.Length < 5)
            {
                AppendLog("无响应或长度不足。");
                return;
            }

            ModbusError err;
            switch (func)
            {
                case 0x01:
                case 0x02:
                    {
                        var bits = new byte[quantity];
                        err = ModbusRtuClient.ParseReadBitsResponse(response, response.Length, slaveId, func, bits, out int count);
                        if (err == ModbusError.Ok)
                        {
                            var text = string.Join(" ", bits.Take(count).Select(b => b.ToString()));
                            AppendLog($"读取成功，数量 {count}，值：{text}");
                        }
                        else
                        {
                            AppendLog($"解析失败：{err}");
                        }
                        break;
                    }
                case 0x03:
                case 0x04:
                    {
                        var regs = new ushort[quantity];
                        err = ModbusRtuClient.ParseReadRegistersResponse(response, response.Length, slaveId, func, regs, out int count);
                        if (err == ModbusError.Ok)
                        {
                            var text = string.Join(" ", regs.Take(count).Select(r => $"0x{r:X04}"));
                            AppendLog($"读取成功，数量 {count}，值：{text}");
                        }
                        else
                        {
                            AppendLog($"解析失败：{err}");
                        }
                        break;
                    }
                case 0x05:
                case 0x06:
                case 0x0F:
                case 0x10:
                    err = ModbusRtuClient.ParseWriteResponse(response, response.Length, slaveId, func);
                    if (err == ModbusError.Ok)
                    {
                        AppendLog("写入成功。");
                    }
                    else
                    {
                        AppendLog($"写入响应解析失败：{err}");
                    }
                    break;
                default:
                    AppendLog($"未处理的功能码，原始响应：{BitConverter.ToString(response)}");
                    break;
            }
        }

        private void AppendLog(string text)
        {
            if (string.IsNullOrWhiteSpace(textBoxLog.Text))
            {
                textBoxLog.Text = text;
            }
            else
            {
                textBoxLog.AppendText(Environment.NewLine + text);
            }
        }

        private void buttonClearLog_Click(object sender, EventArgs e)
        {
            textBoxLog.Clear();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            DisconnectPort();
        }

    }
}
