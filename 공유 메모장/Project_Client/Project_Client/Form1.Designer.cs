namespace Project_Client
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.textBox3 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.textBox1 = new MetroFramework.Controls.MetroTextBox();
            this.textBox2 = new MetroFramework.Controls.MetroTextBox();
            this.button1 = new MetroFramework.Controls.MetroButton();
            this.button4 = new MetroFramework.Controls.MetroButton();
            this.button2 = new MetroFramework.Controls.MetroButton();
            this.button3 = new MetroFramework.Controls.MetroButton();
            this.listView1 = new MetroFramework.Controls.MetroListView();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroListView1 = new MetroFramework.Controls.MetroListView();
            this.textBox4 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.button6 = new MetroFramework.Controls.MetroButton();
            this.button5 = new MetroFramework.Controls.MetroButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(42, 117);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(29, 20);
            this.metroLabel1.TabIndex = 8;
            this.metroLabel1.Text = "ID :";
            // 
            // textBox3
            // 
            // 
            // 
            // 
            this.textBox3.CustomButton.Image = null;
            this.textBox3.CustomButton.Location = new System.Drawing.Point(214, 1);
            this.textBox3.CustomButton.Name = "";
            this.textBox3.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.textBox3.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBox3.CustomButton.TabIndex = 1;
            this.textBox3.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBox3.CustomButton.UseSelectable = true;
            this.textBox3.CustomButton.Visible = false;
            this.textBox3.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.textBox3.Lines = new string[0];
            this.textBox3.Location = new System.Drawing.Point(100, 117);
            this.textBox3.MaxLength = 32767;
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '\0';
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox3.SelectedText = "";
            this.textBox3.SelectionLength = 0;
            this.textBox3.SelectionStart = 0;
            this.textBox3.ShortcutsEnabled = true;
            this.textBox3.Size = new System.Drawing.Size(242, 29);
            this.textBox3.TabIndex = 11;
            this.textBox3.UseSelectable = true;
            this.textBox3.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox3.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(372, 68);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(41, 20);
            this.metroLabel2.TabIndex = 12;
            this.metroLabel2.Text = "Port :";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(42, 68);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(27, 20);
            this.metroLabel3.TabIndex = 14;
            this.metroLabel3.Text = "IP :";
            // 
            // textBox1
            // 
            // 
            // 
            // 
            this.textBox1.CustomButton.Image = null;
            this.textBox1.CustomButton.Location = new System.Drawing.Point(214, 1);
            this.textBox1.CustomButton.Name = "";
            this.textBox1.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.textBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBox1.CustomButton.TabIndex = 1;
            this.textBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBox1.CustomButton.UseSelectable = true;
            this.textBox1.CustomButton.Visible = false;
            this.textBox1.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.textBox1.Lines = new string[] {
        "192.168.10.1"};
            this.textBox1.Location = new System.Drawing.Point(100, 68);
            this.textBox1.MaxLength = 32767;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox1.SelectedText = "";
            this.textBox1.SelectionLength = 0;
            this.textBox1.SelectionStart = 0;
            this.textBox1.ShortcutsEnabled = true;
            this.textBox1.Size = new System.Drawing.Size(242, 29);
            this.textBox1.TabIndex = 15;
            this.textBox1.Text = "192.168.10.1";
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
            this.textBox2.CustomButton.Location = new System.Drawing.Point(109, 1);
            this.textBox2.CustomButton.Name = "";
            this.textBox2.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.textBox2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBox2.CustomButton.TabIndex = 1;
            this.textBox2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBox2.CustomButton.UseSelectable = true;
            this.textBox2.CustomButton.Visible = false;
            this.textBox2.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.textBox2.Lines = new string[] {
        "7777"};
            this.textBox2.Location = new System.Drawing.Point(428, 68);
            this.textBox2.MaxLength = 32767;
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '\0';
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox2.SelectedText = "";
            this.textBox2.SelectionLength = 0;
            this.textBox2.SelectionStart = 0;
            this.textBox2.ShortcutsEnabled = true;
            this.textBox2.Size = new System.Drawing.Size(137, 29);
            this.textBox2.TabIndex = 16;
            this.textBox2.Text = "7777";
            this.textBox2.UseSelectable = true;
            this.textBox2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(428, 117);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 31);
            this.button1.TabIndex = 17;
            this.button1.Text = "접속";
            this.button1.UseSelectable = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(357, 63);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(118, 35);
            this.button4.TabIndex = 12;
            this.button4.Text = "내 필기보기";
            this.button4.UseSelectable = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(356, 121);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 35);
            this.button2.TabIndex = 13;
            this.button2.Text = "필기보기";
            this.button2.UseSelectable = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(356, 371);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(118, 35);
            this.button3.TabIndex = 14;
            this.button3.Text = "파일보기";
            this.button3.UseSelectable = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // listView1
            // 
            this.listView1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(32, 63);
            this.listView1.Name = "listView1";
            this.listView1.OwnerDraw = true;
            this.listView1.Size = new System.Drawing.Size(286, 165);
            this.listView1.TabIndex = 15;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.UseSelectable = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(32, 30);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(108, 20);
            this.metroLabel4.TabIndex = 16;
            this.metroLabel4.Text = "- 접속한 목록 -";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.metroTextBox1);
            this.groupBox1.Controls.Add(this.metroLabel7);
            this.groupBox1.Controls.Add(this.metroButton1);
            this.groupBox1.Controls.Add(this.metroButton2);
            this.groupBox1.Controls.Add(this.metroLabel6);
            this.groupBox1.Controls.Add(this.metroListView1);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.metroLabel5);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.metroLabel4);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(57, 181);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(508, 567);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RUN";
            // 
            // metroTextBox1
            // 
            // 
            // 
            // 
            this.metroTextBox1.CustomButton.Image = null;
            this.metroTextBox1.CustomButton.Location = new System.Drawing.Point(252, 1);
            this.metroTextBox1.CustomButton.Name = "";
            this.metroTextBox1.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.metroTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox1.CustomButton.TabIndex = 1;
            this.metroTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox1.CustomButton.UseSelectable = true;
            this.metroTextBox1.CustomButton.Visible = false;
            this.metroTextBox1.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.metroTextBox1.Lines = new string[0];
            this.metroTextBox1.Location = new System.Drawing.Point(94, 518);
            this.metroTextBox1.MaxLength = 32767;
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.PasswordChar = '\0';
            this.metroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox1.SelectedText = "";
            this.metroTextBox1.SelectionLength = 0;
            this.metroTextBox1.SelectionStart = 0;
            this.metroTextBox1.ShortcutsEnabled = true;
            this.metroTextBox1.Size = new System.Drawing.Size(284, 33);
            this.metroTextBox1.TabIndex = 26;
            this.metroTextBox1.UseSelectable = true;
            this.metroTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(19, 522);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(69, 20);
            this.metroLabel7.TabIndex = 25;
            this.metroLabel7.Text = "폴더경로";
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(401, 531);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(89, 30);
            this.metroButton1.TabIndex = 24;
            this.metroButton1.Text = "다운로드";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(401, 495);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(89, 30);
            this.metroButton2.TabIndex = 23;
            this.metroButton2.Text = "경로선택";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(32, 305);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(89, 20);
            this.metroLabel6.TabIndex = 22;
            this.metroLabel6.Text = "- 파일목록 -";
            // 
            // metroListView1
            // 
            this.metroListView1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.metroListView1.FullRowSelect = true;
            this.metroListView1.Location = new System.Drawing.Point(32, 334);
            this.metroListView1.Name = "metroListView1";
            this.metroListView1.OwnerDraw = true;
            this.metroListView1.Size = new System.Drawing.Size(286, 168);
            this.metroListView1.TabIndex = 21;
            this.metroListView1.UseCompatibleStateImageBehavior = false;
            this.metroListView1.UseSelectable = true;
            // 
            // textBox4
            // 
            // 
            // 
            // 
            this.textBox4.CustomButton.Image = null;
            this.textBox4.CustomButton.Location = new System.Drawing.Point(252, 1);
            this.textBox4.CustomButton.Name = "";
            this.textBox4.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.textBox4.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBox4.CustomButton.TabIndex = 1;
            this.textBox4.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBox4.CustomButton.UseSelectable = true;
            this.textBox4.CustomButton.Visible = false;
            this.textBox4.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.textBox4.Lines = new string[0];
            this.textBox4.Location = new System.Drawing.Point(94, 261);
            this.textBox4.MaxLength = 32767;
            this.textBox4.Name = "textBox4";
            this.textBox4.PasswordChar = '\0';
            this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox4.SelectedText = "";
            this.textBox4.SelectionLength = 0;
            this.textBox4.SelectionStart = 0;
            this.textBox4.ShortcutsEnabled = true;
            this.textBox4.Size = new System.Drawing.Size(284, 33);
            this.textBox4.TabIndex = 20;
            this.textBox4.UseSelectable = true;
            this.textBox4.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox4.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(19, 265);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(69, 20);
            this.metroLabel5.TabIndex = 19;
            this.metroLabel5.Text = "파일경로";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(401, 281);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(89, 30);
            this.button6.TabIndex = 18;
            this.button6.Text = "업로드";
            this.button6.UseSelectable = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(401, 245);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(89, 30);
            this.button5.TabIndex = 17;
            this.button5.Text = "파일선택";
            this.button5.UseSelectable = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 792);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox textBox3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox textBox1;
        private MetroFramework.Controls.MetroTextBox textBox2;
        private MetroFramework.Controls.MetroButton button1;
        private MetroFramework.Controls.MetroButton button4;
        private MetroFramework.Controls.MetroButton button2;
        private MetroFramework.Controls.MetroButton button3;
        private MetroFramework.Controls.MetroListView listView1;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroTextBox textBox4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroButton button6;
        private MetroFramework.Controls.MetroButton button5;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroListView metroListView1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

