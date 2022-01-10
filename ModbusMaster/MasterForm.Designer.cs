﻿namespace ModbusMaster
{
    partial class MasterForm
    {

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterForm));
            this.groupBoxFunctions = new System.Windows.Forms.GroupBox();
            this.txtPollDelay = new System.Windows.Forms.TextBox();
            this.cbPoll = new System.Windows.Forms.CheckBox();
            this.btnReadCoils = new System.Windows.Forms.Button();
            this.btnReadDisInp = new System.Windows.Forms.Button();
            this.btnWriteMultipleReg = new System.Windows.Forms.Button();
            this.btnReadHoldReg = new System.Windows.Forms.Button();
            this.btnWriteMultipleCoils = new System.Windows.Forms.Button();
            this.btnReadInpReg = new System.Windows.Forms.Button();
            this.btnWriteSingleReg = new System.Windows.Forms.Button();
            this.btnWriteSingleCoil = new System.Windows.Forms.Button();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.pollTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grpStart.SuspendLayout();
            this.groupBoxRTU.SuspendLayout();
            this.groupBoxMode.SuspendLayout();
            this.groupBoxTCP.SuspendLayout();
            this.grpExchange.SuspendLayout();
            this.groupBoxFunctions.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(9, 828);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox4.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            // 
            // listBoxCommLog
            // 
            this.listBoxCommLog.ItemHeight = 15;
            this.listBoxCommLog.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.listBoxCommLog.Size = new System.Drawing.Size(1128, 169);
            // 
            // textBoxSlaveID
            // 
            this.textBoxSlaveID.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            // 
            // groupBox3
            // 
            this.groupBox3.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox3.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox3.Size = new System.Drawing.Size(252, 127);
            // 
            // radioButtonInteger
            // 
            this.radioButtonInteger.Location = new System.Drawing.Point(115, 23);
            this.radioButtonInteger.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.radioButtonInteger.Size = new System.Drawing.Size(85, 24);
            // 
            // textBoxPort
            // 
            this.textBoxPort.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            // 
            // label1
            // 
            this.label1.Visible = false;
            // 
            // textBoxSlaveDelay
            // 
            this.textBoxSlaveDelay.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.textBoxSlaveDelay.Visible = false;
            // 
            // txtIP
            // 
            this.txtIP.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            // 
            // radioButtonReverseFloat
            // 
            this.radioButtonReverseFloat.Location = new System.Drawing.Point(115, 46);
            this.radioButtonReverseFloat.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            // 
            // groupBoxFunctions
            // 
            this.groupBoxFunctions.Controls.Add(this.txtPollDelay);
            this.groupBoxFunctions.Controls.Add(this.cbPoll);
            this.groupBoxFunctions.Controls.Add(this.btnReadCoils);
            this.groupBoxFunctions.Controls.Add(this.btnReadDisInp);
            this.groupBoxFunctions.Controls.Add(this.btnWriteMultipleReg);
            this.groupBoxFunctions.Controls.Add(this.btnReadHoldReg);
            this.groupBoxFunctions.Controls.Add(this.btnWriteMultipleCoils);
            this.groupBoxFunctions.Controls.Add(this.btnReadInpReg);
            this.groupBoxFunctions.Controls.Add(this.btnWriteSingleReg);
            this.groupBoxFunctions.Controls.Add(this.btnWriteSingleCoil);
            this.groupBoxFunctions.Enabled = false;
            this.groupBoxFunctions.Location = new System.Drawing.Point(288, 166);
            this.groupBoxFunctions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxFunctions.Name = "groupBoxFunctions";
            this.groupBoxFunctions.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxFunctions.Size = new System.Drawing.Size(453, 148);
            this.groupBoxFunctions.TabIndex = 35;
            this.groupBoxFunctions.TabStop = false;
            this.groupBoxFunctions.Text = "Functions";
            // 
            // txtPollDelay
            // 
            this.txtPollDelay.Location = new System.Drawing.Point(75, 115);
            this.txtPollDelay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPollDelay.Name = "txtPollDelay";
            this.txtPollDelay.Size = new System.Drawing.Size(68, 25);
            this.txtPollDelay.TabIndex = 25;
            this.txtPollDelay.Text = "2000";
            this.txtPollDelay.Leave += new System.EventHandler(this.txtPollDelay_Leave);
            // 
            // cbPoll
            // 
            this.cbPoll.AutoSize = true;
            this.cbPoll.Location = new System.Drawing.Point(9, 118);
            this.cbPoll.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbPoll.Name = "cbPoll";
            this.cbPoll.Size = new System.Drawing.Size(61, 19);
            this.cbPoll.TabIndex = 24;
            this.cbPoll.Text = "Poll";
            this.cbPoll.UseVisualStyleBackColor = true;
            this.cbPoll.CheckStateChanged += new System.EventHandler(this.cbPoll_CheckStateChanged);
            // 
            // btnReadCoils
            // 
            this.btnReadCoils.Location = new System.Drawing.Point(8, 22);
            this.btnReadCoils.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnReadCoils.Name = "btnReadCoils";
            this.btnReadCoils.Size = new System.Drawing.Size(104, 40);
            this.btnReadCoils.TabIndex = 11;
            this.btnReadCoils.Text = "Read coils";
            this.btnReadCoils.Click += new System.EventHandler(this.BtnReadCoilsClick);
            // 
            // btnReadDisInp
            // 
            this.btnReadDisInp.Location = new System.Drawing.Point(8, 69);
            this.btnReadDisInp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnReadDisInp.Name = "btnReadDisInp";
            this.btnReadDisInp.Size = new System.Drawing.Size(104, 40);
            this.btnReadDisInp.TabIndex = 16;
            this.btnReadDisInp.Text = "Read discrete inputs";
            this.btnReadDisInp.Click += new System.EventHandler(this.BtnReadDisInpClick);
            // 
            // btnWriteMultipleReg
            // 
            this.btnWriteMultipleReg.Location = new System.Drawing.Point(332, 69);
            this.btnWriteMultipleReg.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnWriteMultipleReg.Name = "btnWriteMultipleReg";
            this.btnWriteMultipleReg.Size = new System.Drawing.Size(104, 40);
            this.btnWriteMultipleReg.TabIndex = 23;
            this.btnWriteMultipleReg.Text = "Write multiple register";
            this.btnWriteMultipleReg.Click += new System.EventHandler(this.BtnWriteMultipleRegClick);
            // 
            // btnReadHoldReg
            // 
            this.btnReadHoldReg.Location = new System.Drawing.Point(116, 22);
            this.btnReadHoldReg.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnReadHoldReg.Name = "btnReadHoldReg";
            this.btnReadHoldReg.Size = new System.Drawing.Size(104, 40);
            this.btnReadHoldReg.TabIndex = 17;
            this.btnReadHoldReg.Text = "Read holding register";
            this.btnReadHoldReg.Click += new System.EventHandler(this.BtnReadHoldRegClick);
            // 
            // btnWriteMultipleCoils
            // 
            this.btnWriteMultipleCoils.Location = new System.Drawing.Point(332, 22);
            this.btnWriteMultipleCoils.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnWriteMultipleCoils.Name = "btnWriteMultipleCoils";
            this.btnWriteMultipleCoils.Size = new System.Drawing.Size(104, 40);
            this.btnWriteMultipleCoils.TabIndex = 22;
            this.btnWriteMultipleCoils.Text = "Write multiple coils";
            this.btnWriteMultipleCoils.Click += new System.EventHandler(this.BtnWriteMultipleCoilsClick);
            // 
            // btnReadInpReg
            // 
            this.btnReadInpReg.Location = new System.Drawing.Point(116, 69);
            this.btnReadInpReg.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnReadInpReg.Name = "btnReadInpReg";
            this.btnReadInpReg.Size = new System.Drawing.Size(104, 40);
            this.btnReadInpReg.TabIndex = 18;
            this.btnReadInpReg.Text = "Read input register";
            this.btnReadInpReg.Click += new System.EventHandler(this.BtnReadInpRegClick);
            // 
            // btnWriteSingleReg
            // 
            this.btnWriteSingleReg.Location = new System.Drawing.Point(224, 69);
            this.btnWriteSingleReg.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnWriteSingleReg.Name = "btnWriteSingleReg";
            this.btnWriteSingleReg.Size = new System.Drawing.Size(104, 40);
            this.btnWriteSingleReg.TabIndex = 21;
            this.btnWriteSingleReg.Text = "Write single register";
            this.btnWriteSingleReg.Click += new System.EventHandler(this.BtnWriteSingleRegClick);
            // 
            // btnWriteSingleCoil
            // 
            this.btnWriteSingleCoil.Location = new System.Drawing.Point(224, 22);
            this.btnWriteSingleCoil.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnWriteSingleCoil.Name = "btnWriteSingleCoil";
            this.btnWriteSingleCoil.Size = new System.Drawing.Size(104, 40);
            this.btnWriteSingleCoil.TabIndex = 19;
            this.btnWriteSingleCoil.Text = "Write single coil";
            this.btnWriteSingleCoil.Click += new System.EventHandler(this.BtnWriteSingleCoilClick);
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Enabled = false;
            this.buttonDisconnect.Location = new System.Drawing.Point(1012, 54);
            this.buttonDisconnect.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(115, 32);
            this.buttonDisconnect.TabIndex = 37;
            this.buttonDisconnect.Text = "Disconnect";
            this.buttonDisconnect.Click += new System.EventHandler(this.ButtonDisconnectClick);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(1012, 14);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(115, 32);
            this.btnConnect.TabIndex = 36;
            this.btnConnect.Text = "Connect";
            this.btnConnect.Click += new System.EventHandler(this.BtnConnectClick);
            // 
            // pollTimer
            // 
            this.pollTimer.Interval = 2000;
            this.pollTimer.Tick += new System.EventHandler(this.pollTimer_Tick);
            // 
            // MasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.ClientSize = new System.Drawing.Size(1159, 1055);
            this.Controls.Add(this.buttonDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.groupBoxFunctions);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.Name = "MasterForm";
            this.ShowDataLength = true;
            this.Text = "Modbus Master";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MasterFormClosing);
            this.Load += new System.EventHandler(this.MasterForm_Load);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.grpExchange, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.grpStart, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.groupBoxFunctions, 0);
            this.Controls.SetChildIndex(this.btnConnect, 0);
            this.Controls.SetChildIndex(this.buttonDisconnect, 0);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.grpStart.ResumeLayout(false);
            this.groupBoxRTU.ResumeLayout(false);
            this.groupBoxRTU.PerformLayout();
            this.groupBoxMode.ResumeLayout(false);
            this.groupBoxMode.PerformLayout();
            this.groupBoxTCP.ResumeLayout(false);
            this.groupBoxTCP.PerformLayout();
            this.grpExchange.ResumeLayout(false);
            this.grpExchange.PerformLayout();
            this.groupBoxFunctions.ResumeLayout(false);
            this.groupBoxFunctions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxFunctions;
        private System.Windows.Forms.Button btnReadCoils;
        private System.Windows.Forms.Button btnReadDisInp;
        private System.Windows.Forms.Button btnWriteMultipleReg;
        private System.Windows.Forms.Button btnReadHoldReg;
        private System.Windows.Forms.Button btnWriteMultipleCoils;
        private System.Windows.Forms.Button btnReadInpReg;
        private System.Windows.Forms.Button btnWriteSingleReg;
        private System.Windows.Forms.Button btnWriteSingleCoil;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtPollDelay;
        private System.Windows.Forms.CheckBox cbPoll;
        private System.Windows.Forms.Timer pollTimer;
        private System.ComponentModel.IContainer components;
    }
}
