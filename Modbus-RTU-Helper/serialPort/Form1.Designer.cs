namespace serialPort
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxComPort = new System.Windows.Forms.ComboBox();
            this.buttonRefreshPorts = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxParity = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownDataBits = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxStopBits = new System.Windows.Forms.ComboBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxFunctionCode = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownSlaveId = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxStartAddress = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBoxCoilOn = new System.Windows.Forms.CheckBox();
            this.textBoxWriteValue = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxPayload = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.buttonClearLog = new System.Windows.Forms.Button();
            this.groupBoxFunction = new System.Windows.Forms.GroupBox();
            this.labelFunctionDesc = new System.Windows.Forms.Label();
            this.labelWriteSingleCoil = new System.Windows.Forms.Label();
            this.labelWriteSingleReg = new System.Windows.Forms.Label();
            this.labelWriteMultiHint = new System.Windows.Forms.Label();
            this.groupBoxFunction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDataBits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSlaveId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口：";
            // 
            // comboBoxComPort
            // 
            this.comboBoxComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxComPort.FormattingEnabled = true;
            this.comboBoxComPort.Location = new System.Drawing.Point(90, 16);
            this.comboBoxComPort.Name = "comboBoxComPort";
            this.comboBoxComPort.Size = new System.Drawing.Size(120, 26);
            this.comboBoxComPort.TabIndex = 1;
            // 
            // buttonRefreshPorts
            // 
            this.buttonRefreshPorts.Location = new System.Drawing.Point(220, 16);
            this.buttonRefreshPorts.Name = "buttonRefreshPorts";
            this.buttonRefreshPorts.Size = new System.Drawing.Size(80, 26);
            this.buttonRefreshPorts.TabIndex = 2;
            this.buttonRefreshPorts.Text = "刷新";
            this.buttonRefreshPorts.UseVisualStyleBackColor = true;
            this.buttonRefreshPorts.Click += new System.EventHandler(this.buttonRefreshPorts_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "波特率";
            // 
            // comboBoxBaudRate
            // 
            this.comboBoxBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBaudRate.FormattingEnabled = true;
            this.comboBoxBaudRate.Location = new System.Drawing.Point(90, 54);
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(110, 26);
            this.comboBoxBaudRate.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(210, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "校验";
            // 
            // comboBoxParity
            // 
            this.comboBoxParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxParity.FormattingEnabled = true;
            this.comboBoxParity.Location = new System.Drawing.Point(270, 54);
            this.comboBoxParity.Name = "comboBoxParity";
            this.comboBoxParity.Size = new System.Drawing.Size(110, 26);
            this.comboBoxParity.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(400, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "数据位";
            // 
            // numericUpDownDataBits
            // 
            this.numericUpDownDataBits.Location = new System.Drawing.Point(470, 54);
            this.numericUpDownDataBits.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDownDataBits.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownDataBits.Name = "numericUpDownDataBits";
            this.numericUpDownDataBits.Size = new System.Drawing.Size(80, 28);
            this.numericUpDownDataBits.TabIndex = 8;
            this.numericUpDownDataBits.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(560, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "停止位";
            // 
            // comboBoxStopBits
            // 
            this.comboBoxStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStopBits.FormattingEnabled = true;
            this.comboBoxStopBits.Location = new System.Drawing.Point(620, 54);
            this.comboBoxStopBits.Name = "comboBoxStopBits";
            this.comboBoxStopBits.Size = new System.Drawing.Size(80, 26);
            this.comboBoxStopBits.TabIndex = 10;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(320, 16);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(90, 26);
            this.buttonConnect.TabIndex = 11;
            this.buttonConnect.Text = "连接";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Location = new System.Drawing.Point(420, 16);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(90, 26);
            this.buttonDisconnect.TabIndex = 12;
            this.buttonDisconnect.Text = "断开";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(490, 20);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(62, 18);
            this.labelStatus.TabIndex = 13;
            this.labelStatus.Text = "未连接";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 18);
            this.label6.TabIndex = 14;
            this.label6.Text = "功能码";
            // 
            // comboBoxFunctionCode
            // 
            this.comboBoxFunctionCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFunctionCode.FormattingEnabled = true;
            this.comboBoxFunctionCode.Location = new System.Drawing.Point(80, 24);
            this.comboBoxFunctionCode.Name = "comboBoxFunctionCode";
            this.comboBoxFunctionCode.Size = new System.Drawing.Size(170, 26);
            this.comboBoxFunctionCode.TabIndex = 15;
            this.comboBoxFunctionCode.SelectedIndexChanged += new System.EventHandler(this.comboBoxFunctionCode_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 18);
            this.label7.TabIndex = 16;
            this.label7.Text = "站号ID";
            // 
            // numericUpDownSlaveId
            // 
            this.numericUpDownSlaveId.Location = new System.Drawing.Point(90, 158);
            this.numericUpDownSlaveId.Maximum = new decimal(new int[] {
            247,
            0,
            0,
            0});
            this.numericUpDownSlaveId.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSlaveId.Name = "numericUpDownSlaveId";
            this.numericUpDownSlaveId.Size = new System.Drawing.Size(80, 28);
            this.numericUpDownSlaveId.TabIndex = 17;
            this.numericUpDownSlaveId.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(180, 160);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 18);
            this.label8.TabIndex = 18;
            this.label8.Text = "起始址";
            // 
            // textBoxStartAddress
            // 
            this.textBoxStartAddress.Location = new System.Drawing.Point(250, 158);
            this.textBoxStartAddress.Name = "textBoxStartAddress";
            this.textBoxStartAddress.Size = new System.Drawing.Size(110, 28);
            this.textBoxStartAddress.TabIndex = 19;
            this.textBoxStartAddress.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(370, 160);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 18);
            this.label9.TabIndex = 20;
            this.label9.Text = "数量/点";
            // 
            // numericUpDownQuantity
            // 
            this.numericUpDownQuantity.Location = new System.Drawing.Point(450, 158);
            this.numericUpDownQuantity.Maximum = new decimal(new int[] {
            125,
            0,
            0,
            0});
            this.numericUpDownQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownQuantity.Name = "numericUpDownQuantity";
            this.numericUpDownQuantity.Size = new System.Drawing.Size(110, 28);
            this.numericUpDownQuantity.TabIndex = 21;
            this.numericUpDownQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 196);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 18);
            this.label10.TabIndex = 22;
            this.label10.Text = "写单线圈";
            // 
            // checkBoxCoilOn
            // 
            this.checkBoxCoilOn.AutoSize = true;
            this.checkBoxCoilOn.Location = new System.Drawing.Point(90, 194);
            this.checkBoxCoilOn.Name = "checkBoxCoilOn";
            this.checkBoxCoilOn.Size = new System.Drawing.Size(88, 22);
            this.checkBoxCoilOn.TabIndex = 23;
            this.checkBoxCoilOn.Text = "线圈ON";
            this.checkBoxCoilOn.UseVisualStyleBackColor = true;
            // 
            // labelWriteSingleCoil
            // 
            this.labelWriteSingleCoil.AutoSize = true;
            this.labelWriteSingleCoil.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelWriteSingleCoil.Location = new System.Drawing.Point(184, 196);
            this.labelWriteSingleCoil.Name = "labelWriteSingleCoil";
            this.labelWriteSingleCoil.Size = new System.Drawing.Size(188, 18);
            this.labelWriteSingleCoil.TabIndex = 30;
            this.labelWriteSingleCoil.Text = "（勾选=ON，不勾选=OFF）";
            // 
            // textBoxWriteValue
            // 
            this.textBoxWriteValue.Location = new System.Drawing.Point(90, 194);
            this.textBoxWriteValue.Name = "textBoxWriteValue";
            this.textBoxWriteValue.Size = new System.Drawing.Size(120, 28);
            this.textBoxWriteValue.TabIndex = 24;
            this.textBoxWriteValue.Text = "0";
            // 
            // labelWriteSingleReg
            // 
            this.labelWriteSingleReg.AutoSize = true;
            this.labelWriteSingleReg.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelWriteSingleReg.Location = new System.Drawing.Point(220, 196);
            this.labelWriteSingleReg.Name = "labelWriteSingleReg";
            this.labelWriteSingleReg.Size = new System.Drawing.Size(188, 18);
            this.labelWriteSingleReg.TabIndex = 31;
            this.labelWriteSingleReg.Text = "（寄存器值：0-65535）";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 230);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 18);
            this.label11.TabIndex = 25;
            this.label11.Text = "多写数据：";
            // 
            // labelWriteMultiHint
            // 
            this.labelWriteMultiHint.AutoSize = true;
            this.labelWriteMultiHint.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelWriteMultiHint.Location = new System.Drawing.Point(100, 230);
            this.labelWriteMultiHint.Name = "labelWriteMultiHint";
            this.labelWriteMultiHint.Size = new System.Drawing.Size(350, 18);
            this.labelWriteMultiHint.TabIndex = 32;
            this.labelWriteMultiHint.Text = "（HEX格式，空格分隔。写多线圈：每字节8位；写多寄存器：每2字节1个）";
            // 
            // textBoxPayload
            // 
            this.textBoxPayload.Location = new System.Drawing.Point(20, 254);
            this.textBoxPayload.Multiline = true;
            this.textBoxPayload.Name = "textBoxPayload";
            this.textBoxPayload.Size = new System.Drawing.Size(640, 100);
            this.textBoxPayload.TabIndex = 26;
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(570, 350);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(90, 32);
            this.buttonSend.TabIndex = 27;
            this.buttonSend.Text = "发送";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(20, 350);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(530, 90);
            this.textBoxLog.TabIndex = 28;
            // 
            // buttonClearLog
            // 
            this.buttonClearLog.Location = new System.Drawing.Point(570, 390);
            this.buttonClearLog.Name = "buttonClearLog";
            this.buttonClearLog.Size = new System.Drawing.Size(90, 32);
            this.buttonClearLog.TabIndex = 29;
            this.buttonClearLog.Text = "清空";
            this.buttonClearLog.UseVisualStyleBackColor = true;
            this.buttonClearLog.Click += new System.EventHandler(this.buttonClearLog_Click);
            // 
            // groupBoxFunction
            // 
            this.groupBoxFunction.Controls.Add(this.labelFunctionDesc);
            this.groupBoxFunction.Controls.Add(this.comboBoxFunctionCode);
            this.groupBoxFunction.Controls.Add(this.label6);
            this.groupBoxFunction.Location = new System.Drawing.Point(20, 88);
            this.groupBoxFunction.Name = "groupBoxFunction";
            this.groupBoxFunction.Size = new System.Drawing.Size(640, 60);
            this.groupBoxFunction.TabIndex = 33;
            this.groupBoxFunction.TabStop = false;
            this.groupBoxFunction.Text = "功能选择";
            // 
            // labelFunctionDesc
            // 
            this.labelFunctionDesc.AutoSize = true;
            this.labelFunctionDesc.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelFunctionDesc.Location = new System.Drawing.Point(260, 28);
            this.labelFunctionDesc.Name = "labelFunctionDesc";
            this.labelFunctionDesc.Size = new System.Drawing.Size(0, 18);
            this.labelFunctionDesc.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 454);
            this.Controls.Add(this.buttonClearLog);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.textBoxPayload);
            this.Controls.Add(this.labelWriteMultiHint);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.labelWriteSingleReg);
            this.Controls.Add(this.labelWriteSingleCoil);
            this.Controls.Add(this.textBoxWriteValue);
            this.Controls.Add(this.checkBoxCoilOn);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.numericUpDownQuantity);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxStartAddress);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numericUpDownSlaveId);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBoxFunction);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonDisconnect);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.comboBoxStopBits);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDownDataBits);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxParity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxBaudRate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonRefreshPorts);
            this.Controls.Add(this.comboBoxComPort);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modbus RTU Helper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxFunction.ResumeLayout(false);
            this.groupBoxFunction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDataBits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSlaveId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxComPort;
        private System.Windows.Forms.Button buttonRefreshPorts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxBaudRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxParity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownDataBits;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxStopBits;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxFunctionCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDownSlaveId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxStartAddress;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantity;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBoxCoilOn;
        private System.Windows.Forms.TextBox textBoxWriteValue;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxPayload;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Button buttonClearLog;
        private System.Windows.Forms.GroupBox groupBoxFunction;
        private System.Windows.Forms.Label labelFunctionDesc;
        private System.Windows.Forms.Label labelWriteSingleCoil;
        private System.Windows.Forms.Label labelWriteSingleReg;
        private System.Windows.Forms.Label labelWriteMultiHint;
    }
}

