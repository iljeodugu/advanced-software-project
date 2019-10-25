using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Packet;
using System.IO;
using System.Net;

namespace Melon2
{
    public partial class Form1 : Form
    {
        string path;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.serverMusicList.View = View.Details;
            this.serverMusicList.Columns.Add("Music Name", 150, HorizontalAlignment.Left);
            this.serverMusicList.Columns.Add("Artist", 60, HorizontalAlignment.Center);
            this.serverMusicList.Columns.Add("Play Time", 100, HorizontalAlignment.Center);
            this.serverMusicList.Columns.Add("Bit Rate", 100, HorizontalAlignment.Left);
            this.playMusicList.View = View.Details;
            this.playMusicList.Columns.Add("Music Name", 150, HorizontalAlignment.Left);
            this.playMusicList.Columns.Add("Artist", 60, HorizontalAlignment.Center);
            this.playMusicList.Columns.Add("Play Time", 100, HorizontalAlignment.Center);
            this.playMusicList.Columns.Add("Bit Rate", 100, HorizontalAlignment.Left);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK != folderBrowserDialog1.ShowDialog())
                return;
            path = folderBrowserDialog1.SelectedPath;
            textBox3.Text = path;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox3.Text == "")
                MessageBox.Show("파일을 다운로드받을 위치를 정하지 않았습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
