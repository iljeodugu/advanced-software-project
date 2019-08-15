namespace Project_Client
{
    partial class myTextBox
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.파일FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.열기OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.저장SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.다른이름으로저장SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.끝내기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.textBox1 = new MetroFramework.Controls.MetroTextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일FToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(20, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(520, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 파일FToolStripMenuItem
            // 
            this.파일FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.열기OToolStripMenuItem,
            this.저장SToolStripMenuItem,
            this.다른이름으로저장SToolStripMenuItem,
            this.toolStripMenuItem1,
            this.끝내기ToolStripMenuItem});
            this.파일FToolStripMenuItem.Name = "파일FToolStripMenuItem";
            this.파일FToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.파일FToolStripMenuItem.Text = "파일(&F)";
            // 
            // 열기OToolStripMenuItem
            // 
            this.열기OToolStripMenuItem.Name = "열기OToolStripMenuItem";
            this.열기OToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.열기OToolStripMenuItem.Text = "열기(&O)";
            this.열기OToolStripMenuItem.Click += new System.EventHandler(this.열기OToolStripMenuItem_Click);
            // 
            // 저장SToolStripMenuItem
            // 
            this.저장SToolStripMenuItem.Name = "저장SToolStripMenuItem";
            this.저장SToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.저장SToolStripMenuItem.Text = "저장(&S)";
            this.저장SToolStripMenuItem.Click += new System.EventHandler(this.저장SToolStripMenuItem_Click);
            // 
            // 다른이름으로저장SToolStripMenuItem
            // 
            this.다른이름으로저장SToolStripMenuItem.Name = "다른이름으로저장SToolStripMenuItem";
            this.다른이름으로저장SToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.다른이름으로저장SToolStripMenuItem.Text = "다른 이름으로 저장(&A)";
            this.다른이름으로저장SToolStripMenuItem.Click += new System.EventHandler(this.다른이름으로저장SToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(231, 6);
            // 
            // 끝내기ToolStripMenuItem
            // 
            this.끝내기ToolStripMenuItem.Name = "끝내기ToolStripMenuItem";
            this.끝내기ToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.끝내기ToolStripMenuItem.Text = "끝내기(&X)";
            this.끝내기ToolStripMenuItem.Click += new System.EventHandler(this.끝내기ToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBox1
            // 
            // 
            // 
            // 
            this.textBox1.CustomButton.Image = null;
            this.textBox1.CustomButton.Location = new System.Drawing.Point(182, 1);
            this.textBox1.CustomButton.Name = "";
            this.textBox1.CustomButton.Size = new System.Drawing.Size(337, 337);
            this.textBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBox1.CustomButton.TabIndex = 1;
            this.textBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBox1.CustomButton.UseSelectable = true;
            this.textBox1.CustomButton.Visible = false;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Lines = new string[0];
            this.textBox1.Location = new System.Drawing.Point(20, 88);
            this.textBox1.MaxLength = 32767;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox1.SelectedText = "";
            this.textBox1.SelectionLength = 0;
            this.textBox1.SelectionStart = 0;
            this.textBox1.ShortcutsEnabled = true;
            this.textBox1.Size = new System.Drawing.Size(520, 339);
            this.textBox1.TabIndex = 1;
            this.textBox1.UseSelectable = true;
            this.textBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // myTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 447);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "myTextBox";
            this.Text = "TextBox";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.myTextBox_FormClosing);
            this.Load += new System.EventHandler(this.myTextBox_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 파일FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 열기OToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 저장SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 다른이름으로저장SToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 끝내기ToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private MetroFramework.Controls.MetroTextBox textBox1;
    }
}