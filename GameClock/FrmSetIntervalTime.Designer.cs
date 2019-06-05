namespace GameClock
{
    partial class FrmSetIntervalTime
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
            this.Label6 = new System.Windows.Forms.Label();
            this.numSecond = new System.Windows.Forms.NumericUpDown();
            this.Label5 = new System.Windows.Forms.Label();
            this.numMinute = new System.Windows.Forms.NumericUpDown();
            this.Label4 = new System.Windows.Forms.Label();
            this.numHour = new System.Windows.Forms.NumericUpDown();
            this.Label3 = new System.Windows.Forms.Label();
            this.numDay = new System.Windows.Forms.NumericUpDown();
            this.btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numSecond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDay)).BeginInit();
            this.SuspendLayout();
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(281, 54);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(17, 12);
            this.Label6.TabIndex = 35;
            this.Label6.Text = "秒";
            // 
            // numSecond
            // 
            this.numSecond.Location = new System.Drawing.Point(241, 54);
            this.numSecond.Name = "numSecond";
            this.numSecond.Size = new System.Drawing.Size(35, 21);
            this.numSecond.TabIndex = 34;
            this.numSecond.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(223, 53);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(17, 12);
            this.Label5.TabIndex = 33;
            this.Label5.Text = "分";
            // 
            // numMinute
            // 
            this.numMinute.Location = new System.Drawing.Point(184, 53);
            this.numMinute.Name = "numMinute";
            this.numMinute.Size = new System.Drawing.Size(34, 21);
            this.numMinute.TabIndex = 32;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(161, 54);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(17, 12);
            this.Label4.TabIndex = 31;
            this.Label4.Text = "时";
            // 
            // numHour
            // 
            this.numHour.Location = new System.Drawing.Point(121, 54);
            this.numHour.Name = "numHour";
            this.numHour.Size = new System.Drawing.Size(35, 21);
            this.numHour.TabIndex = 30;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(103, 54);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(17, 12);
            this.Label3.TabIndex = 29;
            this.Label3.Text = "天";
            // 
            // numDay
            // 
            this.numDay.Location = new System.Drawing.Point(68, 54);
            this.numDay.Name = "numDay";
            this.numDay.Size = new System.Drawing.Size(33, 21);
            this.numDay.TabIndex = 28;
            // 
            // btn
            // 
            this.btn.BackColor = System.Drawing.SystemColors.Control;
            this.btn.Location = new System.Drawing.Point(201, 103);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(75, 23);
            this.btn.TabIndex = 36;
            this.btn.Text = "确认设置";
            this.btn.UseVisualStyleBackColor = false;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // FrmSetIntervalTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 154);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.numSecond);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.numMinute);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.numHour);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.numDay);
            this.Name = "FrmSetIntervalTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SetIntervalTime";
            this.Load += new System.EventHandler(this.FrmSetIntervalTime_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numSecond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.NumericUpDown numSecond;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.NumericUpDown numMinute;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.NumericUpDown numHour;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.NumericUpDown numDay;
        private System.Windows.Forms.Button btn;
    }
}