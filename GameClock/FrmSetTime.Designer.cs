namespace GameClock
{
    partial class FrmSetTime
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
            this.btnConfirm = new System.Windows.Forms.Button();
            this.dtpStartYMD = new System.Windows.Forms.DateTimePicker();
            this.Label6 = new System.Windows.Forms.Label();
            this.numSecond = new System.Windows.Forms.NumericUpDown();
            this.Label5 = new System.Windows.Forms.Label();
            this.numMinute = new System.Windows.Forms.NumericUpDown();
            this.Label4 = new System.Windows.Forms.Label();
            this.numHour = new System.Windows.Forms.NumericUpDown();
            this.btnSetNow = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStarttime = new System.Windows.Forms.TextBox();
            this.btnSetHms = new System.Windows.Forms.Button();
            this.btnSetYMD = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numSecond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHour)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(258, 206);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "设置确认";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // dtpStartYMD
            // 
            this.dtpStartYMD.Location = new System.Drawing.Point(82, 45);
            this.dtpStartYMD.Name = "dtpStartYMD";
            this.dtpStartYMD.Size = new System.Drawing.Size(200, 21);
            this.dtpStartYMD.TabIndex = 1;
            this.dtpStartYMD.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(242, 91);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(17, 12);
            this.Label6.TabIndex = 43;
            this.Label6.Text = "秒";
            // 
            // numSecond
            // 
            this.numSecond.Location = new System.Drawing.Point(202, 87);
            this.numSecond.Name = "numSecond";
            this.numSecond.Size = new System.Drawing.Size(35, 21);
            this.numSecond.TabIndex = 42;
            this.numSecond.ValueChanged += new System.EventHandler(this.numSecond_ValueChanged);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(184, 91);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(17, 12);
            this.Label5.TabIndex = 41;
            this.Label5.Text = "分";
            // 
            // numMinute
            // 
            this.numMinute.Location = new System.Drawing.Point(145, 87);
            this.numMinute.Name = "numMinute";
            this.numMinute.Size = new System.Drawing.Size(34, 21);
            this.numMinute.TabIndex = 40;
            this.numMinute.ValueChanged += new System.EventHandler(this.numMinute_ValueChanged);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(122, 91);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(17, 12);
            this.Label4.TabIndex = 39;
            this.Label4.Text = "时";
            // 
            // numHour
            // 
            this.numHour.Location = new System.Drawing.Point(82, 87);
            this.numHour.Name = "numHour";
            this.numHour.Size = new System.Drawing.Size(35, 21);
            this.numHour.TabIndex = 38;
            this.numHour.ValueChanged += new System.EventHandler(this.numHour_ValueChanged);
            // 
            // btnSetNow
            // 
            this.btnSetNow.Location = new System.Drawing.Point(298, 148);
            this.btnSetNow.Name = "btnSetNow";
            this.btnSetNow.Size = new System.Drawing.Size(107, 23);
            this.btnSetNow.TabIndex = 44;
            this.btnSetNow.Text = "直接设置为此时";
            this.btnSetNow.UseVisualStyleBackColor = true;
            this.btnSetNow.Click += new System.EventHandler(this.btnSetNow_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 45;
            this.label1.Text = "年月日：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 46;
            this.label2.Text = "时分秒：";
            // 
            // txtStarttime
            // 
            this.txtStarttime.Location = new System.Drawing.Point(21, 148);
            this.txtStarttime.Name = "txtStarttime";
            this.txtStarttime.Size = new System.Drawing.Size(261, 21);
            this.txtStarttime.TabIndex = 47;
            // 
            // btnSetHms
            // 
            this.btnSetHms.Location = new System.Drawing.Point(274, 84);
            this.btnSetHms.Name = "btnSetHms";
            this.btnSetHms.Size = new System.Drawing.Size(107, 23);
            this.btnSetHms.TabIndex = 48;
            this.btnSetHms.Text = "设置为当前时分秒";
            this.btnSetHms.UseVisualStyleBackColor = true;
            this.btnSetHms.Click += new System.EventHandler(this.btnSetHms_Click);
            // 
            // btnSetYMD
            // 
            this.btnSetYMD.Location = new System.Drawing.Point(288, 43);
            this.btnSetYMD.Name = "btnSetYMD";
            this.btnSetYMD.Size = new System.Drawing.Size(107, 23);
            this.btnSetYMD.TabIndex = 49;
            this.btnSetYMD.Text = "设置为当前年月日";
            this.btnSetYMD.UseVisualStyleBackColor = true;
            this.btnSetYMD.Click += new System.EventHandler(this.btnSetYMD_Click);
            // 
            // FrmSetTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 257);
            this.Controls.Add(this.btnSetYMD);
            this.Controls.Add(this.btnSetHms);
            this.Controls.Add(this.txtStarttime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSetNow);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.numSecond);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.numMinute);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.numHour);
            this.Controls.Add(this.dtpStartYMD);
            this.Controls.Add(this.btnConfirm);
            this.Name = "FrmSetTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "时间设置";
            this.Load += new System.EventHandler(this.SetStartTime_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numSecond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHour)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.DateTimePicker dtpStartYMD;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.NumericUpDown numSecond;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.NumericUpDown numMinute;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.NumericUpDown numHour;
        private System.Windows.Forms.Button btnSetNow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStarttime;
        private System.Windows.Forms.Button btnSetHms;
        private System.Windows.Forms.Button btnSetYMD;
    }
}