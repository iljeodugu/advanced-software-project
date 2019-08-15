namespace Project_Server
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.server_text_box = new System.Windows.Forms.TextBox();
            this.client_text_list = new System.Windows.Forms.ListView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.server_on = new MetroFramework.Controls.MetroButton();
            this.check_text = new MetroFramework.Controls.MetroButton();
            this.check_file = new MetroFramework.Controls.MetroButton();
            this.findPath = new MetroFramework.Controls.MetroButton();
            this.direcOpen = new MetroFramework.Controls.MetroButton();
            this.path_text_box = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1w = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.ip_text_box = new MetroFramework.Controls.MetroTextBox();
            this.port_text_box = new MetroFramework.Controls.MetroTextBox();
            this.textBox1 = new MetroFramework.Controls.MetroTextBox();
            this.textBox2 = new MetroFramework.Controls.MetroTextBox();
            this.textBox3 = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // server_text_box
            // 
            this.server_text_box.Location = new System.Drawing.Point(28, 248);
            this.server_text_box.Multiline = true;
            this.server_text_box.Name = "server_text_box";
            this.server_text_box.Size = new System.Drawing.Size(343, 403);
            this.server_text_box.TabIndex = 5;
            // 
            // client_text_list
            // 
            this.client_text_list.FullRowSelect = true;
            this.client_text_list.Location = new System.Drawing.Point(370, 248);
            this.client_text_list.Name = "client_text_list";
            this.client_text_list.Size = new System.Drawing.Size(298, 403);
            this.client_text_list.TabIndex = 6;
            this.client_text_list.UseCompatibleStateImageBehavior = false;
            // 
            // server_on
            // 
            this.server_on.DisplayFocus = true;
            this.server_on.ForeColor = System.Drawing.Color.Black;
            this.server_on.Location = new System.Drawing.Point(28, 708);
            this.server_on.Name = "server_on";
            this.server_on.Size = new System.Drawing.Size(165, 43);
            this.server_on.TabIndex = 22;
            this.server_on.Text = "서버 켜기";
            this.server_on.UseSelectable = true;
            this.server_on.Click += new System.EventHandler(this.server_on_Click);
            // 
            // check_text
            // 
            this.check_text.Location = new System.Drawing.Point(378, 674);
            this.check_text.Name = "check_text";
            this.check_text.Size = new System.Drawing.Size(130, 38);
            this.check_text.TabIndex = 23;
            this.check_text.Text = "필기확인";
            this.check_text.UseSelectable = true;
            this.check_text.Click += new System.EventHandler(this.check_text_Click);
            // 
            // check_file
            // 
            this.check_file.Location = new System.Drawing.Point(534, 674);
            this.check_file.Name = "check_file";
            this.check_file.Size = new System.Drawing.Size(130, 38);
            this.check_file.TabIndex = 24;
            this.check_file.Text = "파일확인";
            this.check_file.UseSelectable = true;
            // 
            // findPath
            // 
            this.findPath.Location = new System.Drawing.Point(498, 166);
            this.findPath.Name = "findPath";
            this.findPath.Size = new System.Drawing.Size(81, 34);
            this.findPath.TabIndex = 25;
            this.findPath.Text = "경로설정";
            this.findPath.UseSelectable = true;
            this.findPath.Click += new System.EventHandler(this.findPath_Click);
            // 
            // direcOpen
            // 
            this.direcOpen.Location = new System.Drawing.Point(587, 166);
            this.direcOpen.Name = "direcOpen";
            this.direcOpen.Size = new System.Drawing.Size(81, 34);
            this.direcOpen.TabIndex = 26;
            this.direcOpen.Text = "폴더열기";
            this.direcOpen.UseSelectable = true;
            this.direcOpen.Click += new System.EventHandler(this.direcOpen_Click);
            // 
            // path_text_box
            // 
            // 
            // 
            // 
            this.path_text_box.CustomButton.Image = null;
            this.path_text_box.CustomButton.Location = new System.Drawing.Point(290, 1);
            this.path_text_box.CustomButton.Name = "";
            this.path_text_box.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.path_text_box.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.path_text_box.CustomButton.TabIndex = 1;
            this.path_text_box.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.path_text_box.CustomButton.UseSelectable = true;
            this.path_text_box.CustomButton.Visible = false;
            this.path_text_box.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.path_text_box.Lines = new string[0];
            this.path_text_box.Location = new System.Drawing.Point(148, 169);
            this.path_text_box.MaxLength = 32767;
            this.path_text_box.Name = "path_text_box";
            this.path_text_box.PasswordChar = '\0';
            this.path_text_box.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.path_text_box.SelectedText = "";
            this.path_text_box.SelectionLength = 0;
            this.path_text_box.SelectionStart = 0;
            this.path_text_box.ShortcutsEnabled = true;
            this.path_text_box.Size = new System.Drawing.Size(316, 27);
            this.path_text_box.TabIndex = 27;
            this.path_text_box.UseSelectable = true;
            this.path_text_box.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.path_text_box.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1w
            // 
            this.metroLabel1w.AutoSize = true;
            this.metroLabel1w.Location = new System.Drawing.Point(370, 218);
            this.metroLabel1w.Name = "metroLabel1w";
            this.metroLabel1w.Size = new System.Drawing.Size(69, 20);
            this.metroLabel1w.TabIndex = 28;
            this.metroLabel1w.Text = "접속목록";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(28, 218);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(77, 20);
            this.metroLabel1.TabIndex = 29;
            this.metroLabel1.Text = "Server Log";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(29, 172);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(106, 20);
            this.metroLabel2.TabIndex = 30;
            this.metroLabel2.Text = "서버폴더경로 :";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(29, 76);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(27, 20);
            this.metroLabel3.TabIndex = 31;
            this.metroLabel3.Text = "IP :";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(458, 75);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(41, 20);
            this.metroLabel4.TabIndex = 32;
            this.metroLabel4.Text = "Port :";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(138, 122);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(76, 20);
            this.metroLabel5.TabIndex = 33;
            this.metroLabel5.Text = "수업이름 :";
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(378, 122);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(46, 20);
            this.metroLabel6.TabIndex = 34;
            this.metroLabel6.Text = "날짜 :";
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(470, 123);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(24, 20);
            this.metroLabel7.TabIndex = 35;
            this.metroLabel7.Text = "월";
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(537, 123);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(24, 20);
            this.metroLabel8.TabIndex = 36;
            this.metroLabel8.Text = "일";
            // 
            // ip_text_box
            // 
            // 
            // 
            // 
            this.ip_text_box.CustomButton.Image = null;
            this.ip_text_box.CustomButton.Location = new System.Drawing.Point(326, 1);
            this.ip_text_box.CustomButton.Name = "";
            this.ip_text_box.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.ip_text_box.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.ip_text_box.CustomButton.TabIndex = 1;
            this.ip_text_box.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ip_text_box.CustomButton.UseSelectable = true;
            this.ip_text_box.CustomButton.Visible = false;
            this.ip_text_box.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.ip_text_box.Lines = new string[0];
            this.ip_text_box.Location = new System.Drawing.Point(72, 76);
            this.ip_text_box.MaxLength = 32767;
            this.ip_text_box.Name = "ip_text_box";
            this.ip_text_box.PasswordChar = '\0';
            this.ip_text_box.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ip_text_box.SelectedText = "";
            this.ip_text_box.SelectionLength = 0;
            this.ip_text_box.SelectionStart = 0;
            this.ip_text_box.ShortcutsEnabled = true;
            this.ip_text_box.Size = new System.Drawing.Size(352, 27);
            this.ip_text_box.TabIndex = 37;
            this.ip_text_box.UseSelectable = true;
            this.ip_text_box.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ip_text_box.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // port_text_box
            // 
            // 
            // 
            // 
            this.port_text_box.CustomButton.Image = null;
            this.port_text_box.CustomButton.Location = new System.Drawing.Point(124, 1);
            this.port_text_box.CustomButton.Name = "";
            this.port_text_box.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.port_text_box.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.port_text_box.CustomButton.TabIndex = 1;
            this.port_text_box.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.port_text_box.CustomButton.UseSelectable = true;
            this.port_text_box.CustomButton.Visible = false;
            this.port_text_box.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.port_text_box.Lines = new string[] {
        "7777"};
            this.port_text_box.Location = new System.Drawing.Point(518, 76);
            this.port_text_box.MaxLength = 32767;
            this.port_text_box.Name = "port_text_box";
            this.port_text_box.PasswordChar = '\0';
            this.port_text_box.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.port_text_box.SelectedText = "";
            this.port_text_box.SelectionLength = 0;
            this.port_text_box.SelectionStart = 0;
            this.port_text_box.ShortcutsEnabled = true;
            this.port_text_box.Size = new System.Drawing.Size(150, 27);
            this.port_text_box.TabIndex = 38;
            this.port_text_box.Text = "7777";
            this.port_text_box.UseSelectable = true;
            this.port_text_box.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.port_text_box.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // textBox1
            // 
            // 
            // 
            // 
            this.textBox1.CustomButton.Image = null;
            this.textBox1.CustomButton.Location = new System.Drawing.Point(125, 1);
            this.textBox1.CustomButton.Name = "";
            this.textBox1.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.textBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBox1.CustomButton.TabIndex = 1;
            this.textBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBox1.CustomButton.UseSelectable = true;
            this.textBox1.CustomButton.Visible = false;
            this.textBox1.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.textBox1.Lines = new string[0];
            this.textBox1.Location = new System.Drawing.Point(220, 122);
            this.textBox1.MaxLength = 32767;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox1.SelectedText = "";
            this.textBox1.SelectionLength = 0;
            this.textBox1.SelectionStart = 0;
            this.textBox1.ShortcutsEnabled = true;
            this.textBox1.Size = new System.Drawing.Size(151, 27);
            this.textBox1.TabIndex = 39;
            this.textBox1.UseSelectable = true;
            this.textBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // textBox2
            // 
            // 
            // 
            // 
            this.textBox2.CustomButton.Image = null;
            this.textBox2.CustomButton.Location = new System.Drawing.Point(9, 1);
            this.textBox2.CustomButton.Name = "";
            this.textBox2.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.textBox2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBox2.CustomButton.TabIndex = 1;
            this.textBox2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBox2.CustomButton.UseSelectable = true;
            this.textBox2.CustomButton.Visible = false;
            this.textBox2.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.textBox2.Lines = new string[0];
            this.textBox2.Location = new System.Drawing.Point(429, 123);
            this.textBox2.MaxLength = 32767;
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '\0';
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox2.SelectedText = "";
            this.textBox2.SelectionLength = 0;
            this.textBox2.SelectionStart = 0;
            this.textBox2.ShortcutsEnabled = true;
            this.textBox2.Size = new System.Drawing.Size(35, 27);
            this.textBox2.TabIndex = 40;
            this.textBox2.UseSelectable = true;
            this.textBox2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // textBox3
            // 
            // 
            // 
            // 
            this.textBox3.CustomButton.Image = null;
            this.textBox3.CustomButton.Location = new System.Drawing.Point(9, 1);
            this.textBox3.CustomButton.Name = "";
            this.textBox3.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.textBox3.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBox3.CustomButton.TabIndex = 1;
            this.textBox3.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBox3.CustomButton.UseSelectable = true;
            this.textBox3.CustomButton.Visible = false;
            this.textBox3.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.textBox3.Lines = new string[0];
            this.textBox3.Location = new System.Drawing.Point(500, 122);
            this.textBox3.MaxLength = 32767;
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '\0';
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox3.SelectedText = "";
            this.textBox3.SelectionLength = 0;
            this.textBox3.SelectionStart = 0;
            this.textBox3.ShortcutsEnabled = true;
            this.textBox3.Size = new System.Drawing.Size(35, 27);
            this.textBox3.TabIndex = 41;
            this.textBox3.UseSelectable = true;
            this.textBox3.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox3.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 778);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.port_text_box);
            this.Controls.Add(this.ip_text_box);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroLabel1w);
            this.Controls.Add(this.path_text_box);
            this.Controls.Add(this.direcOpen);
            this.Controls.Add(this.findPath);
            this.Controls.Add(this.check_file);
            this.Controls.Add(this.check_text);
            this.Controls.Add(this.server_on);
            this.Controls.Add(this.client_text_list);
            this.Controls.Add(this.server_text_box);
            this.Name = "Form1";
            this.Text = "Shared Memory Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox server_text_box;
        private System.Windows.Forms.ListView client_text_list;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private MetroFramework.Controls.MetroButton server_on;
        private MetroFramework.Controls.MetroButton check_text;
        private MetroFramework.Controls.MetroButton check_file;
        private MetroFramework.Controls.MetroButton findPath;
        private MetroFramework.Controls.MetroButton direcOpen;
        private MetroFramework.Controls.MetroTextBox path_text_box;
        private MetroFramework.Controls.MetroLabel metroLabel1w;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroTextBox ip_text_box;
        private MetroFramework.Controls.MetroTextBox port_text_box;
        private MetroFramework.Controls.MetroTextBox textBox1;
        private MetroFramework.Controls.MetroTextBox textBox2;
        private MetroFramework.Controls.MetroTextBox textBox3;
    }
}

