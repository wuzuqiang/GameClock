namespace GameClock
{
    partial class FrmSetClock
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.txtClocktime = new System.Windows.Forms.TextBox();
            this.btnSetRingtime = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStarttime = new System.Windows.Forms.TextBox();
            this.btnSetBegintime = new System.Windows.Forms.Button();
            this.txtInv = new System.Windows.Forms.TextBox();
            this.btnSetInv = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnInit = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtTaskContent = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxStart = new System.Windows.Forms.CheckBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtInvSecond = new System.Windows.Forms.TextBox();
            this.btnSetNowStart = new System.Windows.Forms.Button();
            this.btnSetNowEnd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtClocktime
            // 
            this.txtClocktime.Location = new System.Drawing.Point(170, 160);
            this.txtClocktime.Name = "txtClocktime";
            this.txtClocktime.Size = new System.Drawing.Size(152, 21);
            this.txtClocktime.TabIndex = 57;
            this.txtClocktime.Text = "2018/1/1 0:0:2";
            // 
            // btnSetRingtime
            // 
            this.btnSetRingtime.Location = new System.Drawing.Point(332, 159);
            this.btnSetRingtime.Name = "btnSetRingtime";
            this.btnSetRingtime.Size = new System.Drawing.Size(60, 23);
            this.btnSetRingtime.TabIndex = 56;
            this.btnSetRingtime.Text = "set";
            this.btnSetRingtime.UseVisualStyleBackColor = true;
            this.btnSetRingtime.Click += new System.EventHandler(this.btnSetEndtime_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 55;
            this.label3.Text = "响铃时间";
            // 
            // txtStarttime
            // 
            this.txtStarttime.Location = new System.Drawing.Point(172, 127);
            this.txtStarttime.Name = "txtStarttime";
            this.txtStarttime.Size = new System.Drawing.Size(150, 21);
            this.txtStarttime.TabIndex = 54;
            this.txtStarttime.Text = "2018/1/1 0:0:1";
            // 
            // btnSetBegintime
            // 
            this.btnSetBegintime.Location = new System.Drawing.Point(333, 126);
            this.btnSetBegintime.Name = "btnSetBegintime";
            this.btnSetBegintime.Size = new System.Drawing.Size(60, 23);
            this.btnSetBegintime.TabIndex = 53;
            this.btnSetBegintime.Text = "set";
            this.btnSetBegintime.UseVisualStyleBackColor = true;
            this.btnSetBegintime.Click += new System.EventHandler(this.btnSetBegintime_Click);
            // 
            // txtInv
            // 
            this.txtInv.Location = new System.Drawing.Point(172, 88);
            this.txtInv.Name = "txtInv";
            this.txtInv.Size = new System.Drawing.Size(114, 21);
            this.txtInv.TabIndex = 52;
            this.txtInv.Text = "0天0时0分20秒";
            // 
            // btnSetInv
            // 
            this.btnSetInv.Location = new System.Drawing.Point(414, 87);
            this.btnSetInv.Name = "btnSetInv";
            this.btnSetInv.Size = new System.Drawing.Size(60, 23);
            this.btnSetInv.TabIndex = 51;
            this.btnSetInv.Text = "set";
            this.btnSetInv.UseVisualStyleBackColor = true;
            this.btnSetInv.Click += new System.EventHandler(this.btnSetInv_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(113, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 50;
            this.label8.Text = "起始时间";
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(115, 230);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(87, 23);
            this.btnInit.TabIndex = 47;
            this.btnInit.Text = "重置";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(113, 92);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(53, 12);
            this.Label2.TabIndex = 46;
            this.Label2.Text = "间隔时长";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(113, 55);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(53, 12);
            this.Label1.TabIndex = 45;
            this.Label1.Text = "任务内容";
            // 
            // txtTaskContent
            // 
            this.txtTaskContent.FormattingEnabled = true;
            this.txtTaskContent.Location = new System.Drawing.Point(172, 52);
            this.txtTaskContent.Name = "txtTaskContent";
            this.txtTaskContent.Size = new System.Drawing.Size(337, 20);
            this.txtTaskContent.TabIndex = 44;
            this.txtTaskContent.Text = "222";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(137, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 58;
            this.label4.Text = "状态";
            // 
            // cbxStart
            // 
            this.cbxStart.AutoSize = true;
            this.cbxStart.Checked = true;
            this.cbxStart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxStart.Location = new System.Drawing.Point(172, 28);
            this.cbxStart.Name = "cbxStart";
            this.cbxStart.Size = new System.Drawing.Size(48, 16);
            this.cbxStart.TabIndex = 59;
            this.cbxStart.Text = "开启";
            this.cbxStart.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(295, 220);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(87, 33);
            this.btnConfirm.TabIndex = 60;
            this.btnConfirm.Text = "确认并关闭";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(293, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 61;
            this.label5.Text = "共计(秒)";
            // 
            // txtInvSecond
            // 
            this.txtInvSecond.Location = new System.Drawing.Point(347, 88);
            this.txtInvSecond.Name = "txtInvSecond";
            this.txtInvSecond.Size = new System.Drawing.Size(55, 21);
            this.txtInvSecond.TabIndex = 62;
            this.txtInvSecond.Text = "20";
            // 
            // btnSetNowStart
            // 
            this.btnSetNowStart.Location = new System.Drawing.Point(401, 126);
            this.btnSetNowStart.Name = "btnSetNowStart";
            this.btnSetNowStart.Size = new System.Drawing.Size(73, 23);
            this.btnSetNowStart.TabIndex = 63;
            this.btnSetNowStart.Text = "当前时间";
            this.btnSetNowStart.UseVisualStyleBackColor = true;
            this.btnSetNowStart.Click += new System.EventHandler(this.btnSetNowStart_Click);
            // 
            // btnSetNowEnd
            // 
            this.btnSetNowEnd.Location = new System.Drawing.Point(401, 159);
            this.btnSetNowEnd.Name = "btnSetNowEnd";
            this.btnSetNowEnd.Size = new System.Drawing.Size(73, 23);
            this.btnSetNowEnd.TabIndex = 64;
            this.btnSetNowEnd.Text = "当前时间";
            this.btnSetNowEnd.UseVisualStyleBackColor = true;
            this.btnSetNowEnd.Click += new System.EventHandler(this.btnSetNowEnd_Click);
            // 
            // FrmSetClock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 298);
            this.Controls.Add(this.btnSetNowEnd);
            this.Controls.Add(this.btnSetNowStart);
            this.Controls.Add(this.txtInvSecond);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.cbxStart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtClocktime);
            this.Controls.Add(this.btnSetRingtime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtStarttime);
            this.Controls.Add(this.btnSetBegintime);
            this.Controls.Add(this.txtInv);
            this.Controls.Add(this.btnSetInv);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnInit);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txtTaskContent);
            this.Name = "FrmSetClock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置闹钟信息";
            this.Load += new System.EventHandler(this.FrmSetClock_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtClocktime;
        private System.Windows.Forms.Button btnSetRingtime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStarttime;
        private System.Windows.Forms.Button btnSetBegintime;
        private System.Windows.Forms.TextBox txtInv;
        private System.Windows.Forms.Button btnSetInv;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Button btnInit;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox txtTaskContent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbxStart;
        internal System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtInvSecond;
        private System.Windows.Forms.Button btnSetNowStart;
        private System.Windows.Forms.Button btnSetNowEnd;
    }
}