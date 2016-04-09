namespace FirstWinform
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
            this.button1 = new System.Windows.Forms.Button();
            this.myListControl1 = new WinformCommon.MyListControl();
            this.firstControl1 = new WinformCommon.FirstControl();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(253, 269);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // myListControl1
            // 
            this.myListControl1.Item.Add(4);
            this.myListControl1.Item.Add(2);
            this.myListControl1.Item.Add(25);
            this.myListControl1.Item.Add(1);
            this.myListControl1.Location = new System.Drawing.Point(213, 48);
            this.myListControl1.Name = "myListControl1";
            this.myListControl1.Size = new System.Drawing.Size(251, 159);
            this.myListControl1.TabIndex = 2;
            this.myListControl1.Text = "myListControl1";
            // 
            // firstControl1
            // 
            this.firstControl1.DisplayText = "Hello World!";
            this.firstControl1.Location = new System.Drawing.Point(44, 75);
            this.firstControl1.Name = "firstControl1";
            this.firstControl1.Size = new System.Drawing.Size(75, 23);
            this.firstControl1.TabIndex = 3;
            this.firstControl1.Text = "firstControl1";
            this.firstControl1.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 403);
            this.Controls.Add(this.firstControl1);
            this.Controls.Add(this.myListControl1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private WinformCommon.MyListControl myListControl1;
        private WinformCommon.FirstControl firstControl1;
    }
}

