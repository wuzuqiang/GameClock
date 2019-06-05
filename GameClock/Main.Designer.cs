namespace GameClock
{
    partial class Main
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
            this.btnAddClock = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnEditClock = new System.Windows.Forms.Button();
            this.btnStartRing = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnStopClock = new System.Windows.Forms.Button();
            this.btnChangeFirstring = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddClock
            // 
            this.btnAddClock.Location = new System.Drawing.Point(510, 12);
            this.btnAddClock.Name = "btnAddClock";
            this.btnAddClock.Size = new System.Drawing.Size(71, 23);
            this.btnAddClock.TabIndex = 16;
            this.btnAddClock.Text = "新增";
            this.btnAddClock.UseVisualStyleBackColor = true;
            this.btnAddClock.Click += new System.EventHandler(this.btnAddClock_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Items.AddRange(new object[] {
            "响铃时间\t闹钟间隔\t状态\t起始时间\t记录时间"});
            this.listBox1.Location = new System.Drawing.Point(32, 53);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(737, 352);
            this.listBox1.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "初始化设置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnEditClock
            // 
            this.btnEditClock.Location = new System.Drawing.Point(611, 12);
            this.btnEditClock.Name = "btnEditClock";
            this.btnEditClock.Size = new System.Drawing.Size(68, 23);
            this.btnEditClock.TabIndex = 19;
            this.btnEditClock.Text = "修改";
            this.btnEditClock.UseVisualStyleBackColor = true;
            this.btnEditClock.Click += new System.EventHandler(this.btnEditClock_Click);
            // 
            // btnStartRing
            // 
            this.btnStartRing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartRing.Location = new System.Drawing.Point(680, 424);
            this.btnStartRing.Name = "btnStartRing";
            this.btnStartRing.Size = new System.Drawing.Size(75, 23);
            this.btnStartRing.TabIndex = 20;
            this.btnStartRing.Text = "开启闹钟";
            this.btnStartRing.UseVisualStyleBackColor = true;
            this.btnStartRing.Visible = false;
            this.btnStartRing.Click += new System.EventHandler(this.btnStartRing_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox1.Location = new System.Drawing.Point(51, 424);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(244, 21);
            this.textBox1.TabIndex = 21;
            // 
            // btnStopClock
            // 
            this.btnStopClock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStopClock.Location = new System.Drawing.Point(381, 424);
            this.btnStopClock.Name = "btnStopClock";
            this.btnStopClock.Size = new System.Drawing.Size(75, 23);
            this.btnStopClock.TabIndex = 22;
            this.btnStopClock.Text = "停止闹钟";
            this.btnStopClock.UseVisualStyleBackColor = true;
            this.btnStopClock.Visible = false;
            this.btnStopClock.Click += new System.EventHandler(this.btnStopClock_Click);
            // 
            // btnChangeFirstring
            // 
            this.btnChangeFirstring.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeFirstring.Location = new System.Drawing.Point(478, 422);
            this.btnChangeFirstring.Name = "btnChangeFirstring";
            this.btnChangeFirstring.Size = new System.Drawing.Size(105, 23);
            this.btnChangeFirstring.TabIndex = 23;
            this.btnChangeFirstring.Text = "改变第一闹钟";
            this.btnChangeFirstring.UseVisualStyleBackColor = true;
            this.btnChangeFirstring.Visible = false;
            this.btnChangeFirstring.Click += new System.EventHandler(this.btnChangeFirstring_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(701, 12);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(68, 23);
            this.btnDel.TabIndex = 24;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 459);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnChangeFirstring);
            this.Controls.Add(this.btnStopClock);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnStartRing);
            this.Controls.Add(this.btnEditClock);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnAddClock);
            this.Name = "Main";
            this.Text = "傲天斩月屠龙定时闹钟";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnAddClock;
        private System.Windows.Forms.ListBox listBox1;
        internal System.Windows.Forms.Button button1;
        internal System.Windows.Forms.Button btnEditClock;
        private System.Windows.Forms.Button btnStartRing;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnStopClock;
        private System.Windows.Forms.Button btnChangeFirstring;
        internal System.Windows.Forms.Button btnDel;
    }
}

