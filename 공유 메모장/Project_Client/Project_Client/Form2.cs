using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Project_Client
{
    public partial class myTextBox : MetroFramework.Forms.MetroForm
    {
        public Form1 client;
        public string my_text;//내 필기
        public string text_file_name = null;//이 파일의 이름
        public bool second;

        public myTextBox(Form1 temp)
        {
            InitializeComponent();
            client = temp;
            this.text_file_name = client.backup_filename;
            this.textBox1.Text = client.backup;
            client.text_open_check = true;
            second = false;
        }

        public myTextBox()
        {
            InitializeComponent();
            second = true;
        }

        public void fillText(string str, string name)
        {
            textBox1.Text = str;
            this.Text = name;
        }

        private void myTextBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!second)
            {
                client.backup = this.textBox1.Text;
                client.backup_filename = this.text_file_name;
                client.text_open_check = false;
            }
        }

        private void myTextBox_Load(object sender, EventArgs e)
        {
        }

        private void 열기OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename;
            StreamReader fileReader = null;
            
            openFileDialog1.ShowDialog();
            filename = openFileDialog1.FileName;

            try
            {
                fileReader = new StreamReader(filename);
            }
            catch
            {
                MessageBox.Show("파일을 여는데 문제가 발생하였습니다.");
                return;
            }

            textBox1.Text = null;
            
            while (true)
            {
                string str = fileReader.ReadLine();
                if (str == null)
                    break;
                textBox1.Text += str;
            }

            fileReader.Close();
        }

        private void 저장SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter fileWriter = null;
            string filename;

            if (text_file_name == null)
            {
                saveFileDialog1.ShowDialog();
                filename = saveFileDialog1.FileName;

                try
                {
                    fileWriter = new StreamWriter(filename);
                }
                catch
                {
                    MessageBox.Show("파일을 저장하는데 문제가 생겼습니다.");
                    return;
                }
                text_file_name = filename;
                fileWriter.WriteLine(this.textBox1.Text);
                fileWriter.Close();
            }
            else
            {
                saveFileDialog1.ShowDialog();
                filename = saveFileDialog1.FileName;

                try
                {
                    fileWriter = new StreamWriter(filename);
                }
                catch
                {
                    MessageBox.Show("파일을 저장하는데 문제가 생겼습니다.");
                    return;
                }
                text_file_name = filename;
                fileWriter.WriteLine(this.textBox1.Text);
                fileWriter.Close();
            }
        }

        private void 다른이름으로저장SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter fileWriter = null;
            string filename;

            saveFileDialog1.ShowDialog();
            filename = saveFileDialog1.FileName;

            try
            {
                fileWriter = new StreamWriter(filename);
            }
            catch
            {
                MessageBox.Show("파일을 저장하는데 문제가 생겼습니다.");
                return;
            }
            text_file_name = filename;
            fileWriter.WriteLine(this.textBox1.Text);
            fileWriter.Close();        
        }

        private void 끝내기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            client.backup = this.textBox1.Text;
            client.text_open_check = false;
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!second)
            {
                client.backup = this.textBox1.Text;
            }
        }
    }
}
