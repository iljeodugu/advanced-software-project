using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Diagnostics;
using Shell32;
using System.Threading;
using Packet;

namespace Melon1
{
    public partial class Form1 : Form
    {
        public string path; //경로 저장 

        public Form1()
        {
            InitializeComponent();
            ipTextBox.Text = Get_myIp();
            init_List();
        }

        private void init_List()//리스트 초기화를 위한 함수
        {
            this.musicList.View = View.Details;
            this.musicList.Columns.Add("Music Name", 180, HorizontalAlignment.Left);
            this.musicList.Columns.Add("Artist", 60, HorizontalAlignment.Center);
            this.musicList.Columns.Add("Play Time", 100, HorizontalAlignment.Center);
            this.musicList.Columns.Add("Bit Rate", 100, HorizontalAlignment.Left);
            portTextBox.Text = "7777";
        }
        
        private void list_print(string path)//리스트에 초기화
        {
            string[] temp = new string[4];
            string filename = null;
            string[] tempstr= new string[10];
            ListViewItem item;
            ShellClass shell = new ShellClass();
            Folder folder = shell.NameSpace(path);
            FolderItem mp3file;
            char spr = '\\';
            string[] files = Directory.GetFiles(path, "*.mp3");
            foreach (string str in files)
            {
                tempstr = str.Split(spr);
                foreach (string tempname in tempstr)
                {
                    filename = tempname;
                }

                mp3file = folder.ParseName(filename);
                temp[0] = folder.GetDetailsOf(mp3file, 0);
                temp[1] = folder.GetDetailsOf(mp3file, 13);
                temp[2] = folder.GetDetailsOf(mp3file, 27);
                temp[3] = folder.GetDetailsOf(mp3file, 28);
                item = new ListViewItem(temp);
                musicList.Items.Add(item);
            }
        }

        public string Get_myIp()
        {
            IPHostEntry host = Dns.GetHostByName(Dns.GetHostName());
            string myIp = host.AddressList[0].ToString();
            return myIp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void IP_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void musicList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//start 버튼
        {
            if (pathTextBox.Text == "")
                MessageBox.Show("전송 가능한 MP3파일이 없습니다. 경로를 다시 지정하십시오.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else
            {
                if (button1.Text == "Start")
                { 
                    button1.Text = "Stop";
                }
                else
                {
                    button1.Text = "Start";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)//find path 버튼
        {
            musicList.Items.Clear();
            if (DialogResult.OK != folderBrowserDialog1.ShowDialog())
                return;
            path = folderBrowserDialog1.SelectedPath;
            pathTextBox.Text = path;
            list_print(path);
        }
    }
}
