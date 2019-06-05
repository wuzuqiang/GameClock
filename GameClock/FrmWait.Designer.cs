namespace GameClock
{
    partial class FrmWait
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
            this.lbShowText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbShowText
            // 
            this.lbShowText.AutoSize = true;
            this.lbShowText.Location = new System.Drawing.Point(71, 57);
            this.lbShowText.Name = "lbShowText";
            this.lbShowText.Size = new System.Drawing.Size(137, 12);
            this.lbShowText.TabIndex = 0;
            this.lbShowText.Text = "稍等，马上处理完毕....";
            // 
            // FrmWait
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 153);
            this.ControlBox = false;
            this.Controls.Add(this.lbShowText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmWait";
            this.Text = "稍等";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbShowText;
    }
}