namespace TestProject
{
    partial class TCPServer
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxServer = new System.Windows.Forms.GroupBox();
            this.lblCurrentState = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnBroadcast = new System.Windows.Forms.Button();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.lblStartServer = new System.Windows.Forms.Label();
            this.groupBoxServer.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxServer
            // 
            this.groupBoxServer.Controls.Add(this.lblCurrentState);
            this.groupBoxServer.Controls.Add(this.lblState);
            this.groupBoxServer.Controls.Add(this.txtMessage);
            this.groupBoxServer.Controls.Add(this.lblMessage);
            this.groupBoxServer.Controls.Add(this.btnBroadcast);
            this.groupBoxServer.Controls.Add(this.btnStartStop);
            this.groupBoxServer.Controls.Add(this.lblStartServer);
            this.groupBoxServer.Location = new System.Drawing.Point(24, 24);
            this.groupBoxServer.Name = "groupBoxServer";
            this.groupBoxServer.Size = new System.Drawing.Size(539, 376);
            this.groupBoxServer.TabIndex = 1;
            this.groupBoxServer.TabStop = false;
            this.groupBoxServer.Text = "SocketServer";
            // 
            // lblCurrentState
            // 
            this.lblCurrentState.AutoSize = true;
            this.lblCurrentState.Location = new System.Drawing.Point(81, 80);
            this.lblCurrentState.Name = "lblCurrentState";
            this.lblCurrentState.Size = new System.Drawing.Size(29, 12);
            this.lblCurrentState.TabIndex = 7;
            this.lblCurrentState.Text = "停止";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(33, 80);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(35, 12);
            this.lblState.TabIndex = 5;
            this.lblState.Text = "状态:";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(83, 110);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(433, 248);
            this.txtMessage.TabIndex = 4;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(33, 125);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(35, 12);
            this.lblMessage.TabIndex = 3;
            this.lblMessage.Text = "消息:";
            // 
            // btnBroadcast
            // 
            this.btnBroadcast.Location = new System.Drawing.Point(181, 38);
            this.btnBroadcast.Name = "btnBroadcast";
            this.btnBroadcast.Size = new System.Drawing.Size(79, 23);
            this.btnBroadcast.TabIndex = 2;
            this.btnBroadcast.Text = "广播";
            this.btnBroadcast.UseVisualStyleBackColor = true;
            this.btnBroadcast.Click += new System.EventHandler(this.btnBroadcast_Click);
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(83, 38);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(79, 23);
            this.btnStartStop.TabIndex = 1;
            this.btnStartStop.Text = "启动";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // lblStartServer
            // 
            this.lblStartServer.AutoSize = true;
            this.lblStartServer.Location = new System.Drawing.Point(33, 43);
            this.lblStartServer.Name = "lblStartServer";
            this.lblStartServer.Size = new System.Drawing.Size(35, 12);
            this.lblStartServer.TabIndex = 0;
            this.lblStartServer.Text = "操作:";
            // 
            // TCPServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 412);
            this.Controls.Add(this.groupBoxServer);
            this.Name = "TCPServer";
            this.Text = "SocketServer";
            this.groupBoxServer.ResumeLayout(false);
            this.groupBoxServer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxServer;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnBroadcast;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Label lblStartServer;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblCurrentState;

    }
}

