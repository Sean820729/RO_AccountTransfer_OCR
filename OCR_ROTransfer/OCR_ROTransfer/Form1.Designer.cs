namespace OCR_ROTransfer
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FilePath_text = new System.Windows.Forms.TextBox();
            this.FilePath = new System.Windows.Forms.Button();
            this.Account_listView = new System.Windows.Forms.ListView();
            this.VeriImage_picturebox = new System.Windows.Forms.PictureBox();
            this.VeriCode_textbox = new System.Windows.Forms.TextBox();
            this.VeriCode_label = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VeriImage_picturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FilePath_text);
            this.groupBox1.Controls.Add(this.FilePath);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 49);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Accountlist.txt";
            // 
            // FilePath_text
            // 
            this.FilePath_text.Location = new System.Drawing.Point(6, 19);
            this.FilePath_text.Name = "FilePath_text";
            this.FilePath_text.Size = new System.Drawing.Size(139, 22);
            this.FilePath_text.TabIndex = 1;
            // 
            // FilePath
            // 
            this.FilePath.Location = new System.Drawing.Point(151, 18);
            this.FilePath.Name = "FilePath";
            this.FilePath.Size = new System.Drawing.Size(75, 23);
            this.FilePath.TabIndex = 0;
            this.FilePath.Text = "選擇路徑";
            this.FilePath.UseVisualStyleBackColor = true;
            this.FilePath.Click += new System.EventHandler(this.FilePath_Click);
            // 
            // Account_listView
            // 
            this.Account_listView.Location = new System.Drawing.Point(12, 68);
            this.Account_listView.Name = "Account_listView";
            this.Account_listView.Size = new System.Drawing.Size(438, 259);
            this.Account_listView.TabIndex = 4;
            this.Account_listView.UseCompatibleStateImageBehavior = false;
            // 
            // VeriImage_picturebox
            // 
            this.VeriImage_picturebox.BackColor = System.Drawing.Color.White;
            this.VeriImage_picturebox.Location = new System.Drawing.Point(250, 17);
            this.VeriImage_picturebox.Name = "VeriImage_picturebox";
            this.VeriImage_picturebox.Size = new System.Drawing.Size(120, 45);
            this.VeriImage_picturebox.TabIndex = 13;
            this.VeriImage_picturebox.TabStop = false;
            this.VeriImage_picturebox.Click += new System.EventHandler(this.VeriImage_picturebox_Click);
            // 
            // VeriCode_textbox
            // 
            this.VeriCode_textbox.Location = new System.Drawing.Point(376, 40);
            this.VeriCode_textbox.Name = "VeriCode_textbox";
            this.VeriCode_textbox.Size = new System.Drawing.Size(74, 22);
            this.VeriCode_textbox.TabIndex = 21;
            // 
            // VeriCode_label
            // 
            this.VeriCode_label.AutoSize = true;
            this.VeriCode_label.Location = new System.Drawing.Point(376, 25);
            this.VeriCode_label.Name = "VeriCode_label";
            this.VeriCode_label.Size = new System.Drawing.Size(56, 12);
            this.VeriCode_label.TabIndex = 22;
            this.VeriCode_label.Text = "驗  證  碼:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(456, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "OCR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(456, 68);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 24;
            this.button2.Text = "Login";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(456, 97);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 25;
            this.button3.Text = "Get Post data";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(456, 126);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 26;
            this.button4.Text = "POST data";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(456, 155);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 27;
            this.button5.Text = "Start";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 339);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.VeriCode_label);
            this.Controls.Add(this.VeriCode_textbox);
            this.Controls.Add(this.VeriImage_picturebox);
            this.Controls.Add(this.Account_listView);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VeriImage_picturebox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox FilePath_text;
        private System.Windows.Forms.Button FilePath;
        private System.Windows.Forms.ListView Account_listView;
        private System.Windows.Forms.PictureBox VeriImage_picturebox;
        private System.Windows.Forms.TextBox VeriCode_textbox;
        private System.Windows.Forms.Label VeriCode_label;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button5;
    }
}

