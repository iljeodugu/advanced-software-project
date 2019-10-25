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
using System.IO;
using System.Net;
using System.Net.Sockets;
using WMPLib;

namespace Melon2
{
    public partial class Form1 : Form
    {
        string path;//디렉토리 경로를 저장을 해놓자

        WindowsMediaPlayer WMP;
        IWMPMedia Media;
        IWMPPlaylist PlayList;
        bool musicPlay = false;
        Array MediaSaver;

        public NetworkStream m_Stream;
        public StreamReader m_Read;
        public StreamWriter m_Write;
        private Thread m_thReader;
        bool m_thRead_alive = false;
        string[] tempPlayItem = new string[4];//내가 넘겻던 정보를 가지고 있자

        bool stream_alive = false;
        bool connect_OK = false;

        public string[] musicName = new string[128];
        public int maxCount = 0;//음악파일 시간 관리
        public int timeCount = 0;
        public int[] timeMax = new int[128];

        int musicPlayType;//음악 재생 스타일 확인

        public bool m_bStop = false;
        FileStream fs;

        public Thread musicThread;
        bool musicThread_alive = false;

        public bool m_bCounnect = false;
        TcpClient m_Client;
        bool tcp_alive = false;

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
            WMP = new WindowsMediaPlayer();
            PlayList = WMP.newPlaylist("MusicPlayer", "");
            WMP.currentPlaylist = PlayList;
            MediaSaver = Array.CreateInstance(typeof(IWMPMedia), 128);
            comboBox1.SelectedIndex = 0;
            musicPlayType = 1;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK != folderBrowserDialog1.ShowDialog())
                return;
            path = folderBrowserDialog1.SelectedPath;
            textBox3.Text = path;
        }

        private void button3_Click(object sender, EventArgs e)//재생목록 추가
        {
            if (textBox3.Text == "")
                MessageBox.Show("파일을 다운로드받을 위치를 정하지 않았습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (serverMusicList.FocusedItem == null)//추가기능
                MessageBox.Show("파일을 선택해주세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                for (int i = 0; i < 4; i++)
                    tempPlayItem[i] = serverMusicList.FocusedItem.SubItems[i].Text;
                m_Write.WriteLine(serverMusicList.FocusedItem.SubItems[0].Text);
                m_Write.Flush();
            }
        }

        private void Connect()
        {
            m_Client = new TcpClient();
            tcp_alive = true;

            try
            {
                m_Client.Connect(textBox1.Text, Int32.Parse(textBox2.Text));
            }
            catch
            {
                m_bCounnect = false;
                MessageBox.Show("Can Not Connection");
                return;
            }
            connect_OK = true;
            m_bCounnect = true;
            m_Stream = m_Client.GetStream();

            m_Read = new StreamReader(m_Stream);
            m_Write = new StreamWriter(m_Stream);

            m_thReader = new Thread(new ThreadStart(Receive));
            m_thReader.Start();
            m_thRead_alive = true;
            stream_alive = true;
        }

        private void Receive()
        {
            try
            {
                ListViewItem item;
                char spr = '@';
                while (m_bCounnect)
                {
                    string szMessage = m_Read.ReadLine();

                    if (szMessage != null)
                    {
                        if (szMessage == "End Query")
                            break;
                        string[] temp = new string[4];
                        temp = szMessage.Split(spr);

                        item = new ListViewItem(temp);
                        serverMusicList.Items.Add(item);
                    }
                }
                while (m_bCounnect)
                {
                    progressBar1.Minimum = 0;
                    progressBar1.Value = 0;

                    long filesize = 0;
                    char spr2 = '@';
                    while (true)
                    {
                        string szMessage = m_Read.ReadLine();

                        if (szMessage != null)
                        {
                            if (szMessage.IndexOf("Sending File") != -1)
                            {
                                filesize = Convert.ToInt64(szMessage.Split(spr2)[1]);
                                break;
                            }
                        }
                    }
                    string musicPath = path + "\\" + serverMusicList.FocusedItem.SubItems[0].Text;

                    fs = new FileStream(musicPath, FileMode.Create, FileAccess.Write);

                    byte[] response = new byte[1024];
                    int i = 0;
                    progressBar1.Maximum = (int)filesize / 1024 + 1;
                    for (i = 0; i < (int)filesize / 1024;)
                    {
                        m_Stream.Read(response, 0, response.Length);
                        if (response.Length != 0)
                        {
                            fs.WriteAsync(response, 0, response.Length);
                            i++;
                            progressBar1.PerformStep();
                            m_Write.WriteLine("OK");
                            m_Write.Flush();
                            Thread.Sleep(1);//스트림에 다들어가지 않았는데 받아지는경우를 막기위해 기다리자.
                        }
                    }

                    ListViewItem items = new ListViewItem(tempPlayItem);
                    playMusicList.Items.Add(items);

                    char timeSpr = ':';
                    timeMax[maxCount] = Int16.Parse(tempPlayItem[2].Split(timeSpr)[0]) * 360 +
                       Int16.Parse(tempPlayItem[2].Split(timeSpr)[1]) * 60 + Int16.Parse(tempPlayItem[2].Split(timeSpr)[2]);
                    musicName[maxCount] = tempPlayItem[0];

                    Media = WMP.newMedia(@musicPath);
                    PlayList.appendItem(Media);
                    MediaSaver.SetValue(Media, maxCount);

                    maxCount++;
                    fs.Close();
                }
            }
            catch
            {
                MessageBox.Show("클라이언트 연결이 종료되었습니다.");
            }

            m_thReader.Abort();
        }

        private void serverStop()
        {
            m_bStop = false;
            m_bCounnect = false;
            if (stream_alive)
            {
                m_Read.Close();
                m_Write.Close();
                m_Stream.Close();
            }
            if (m_thRead_alive)
                m_thReader.Abort();
            if (musicThread_alive)
                musicThread.Abort();
            if (tcp_alive)
                m_Client.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
                MessageBox.Show("ip 혹은 Port Number 가 설정되지 않았습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (button1.Text == "Connect")
                {
                    button1.Text = "DisConnect";
                    button1.ForeColor = Color.Red;
                    Connect();
                }
                else
                {
                    button1.Text = "Connect";
                    button1.ForeColor = Color.Black;
                    if (connect_OK)
                        serverStop();
                }
            }
        }

        private void track()//track 움직이는 함수
        {
            while (musicPlay)
            {
                Thread.Sleep(10);
                if (WMP.controls.currentPosition >= timeMax[timeCount] - 1)
                {
                    MessageBox.Show("what the2");
                    if (musicPlayType == 1)
                    {
                        if (maxCount - 1 == timeCount)
                        {
                            button5.Image = global::Melon2.Properties.Resources.Play;
                            timeCount = 0;
                            break;
                        }
                        else
                        {
                            timeCount++;
                            trackBar1.Maximum = timeMax[timeCount];
                            label5.Text = "재생 : " + musicName[timeCount];
                        }
                    }
                    else if(musicPlayType == 2)
                    {
                        WMP.controls.stop();
                        WMP.controls.play();
                    }
                    else if(musicPlayType == 3)
                    {
                        if (maxCount - 1 == timeCount)
                        {
                            timeCount = 0;
                            trackBar1.Maximum = timeMax[timeCount];
                            label5.Text = "재생 : " + musicName[timeCount];
                        }
                        else
                        {
                            timeCount++;
                            trackBar1.Maximum = timeMax[timeCount];
                            label5.Text = "재생 : " + musicName[timeCount];
                        }
                    }
                    else if(musicPlayType ==4)
                    {
                        int temp = timeCount;
                        Random r = new Random();
                        timeCount = r.Next(0, maxCount - 1);

                        if (timeCount == temp)
                        {
                            WMP.controls.stop();
                            WMP.controls.play();
                        }

                        for (; timeCount > temp; temp++)
                            WMP.controls.next();
                        for (; timeCount < temp; temp--)
                            WMP.controls.previous();
                        trackBar1.Maximum = timeMax[timeCount];
                        label5.Text = "재생 : " + musicName[timeCount];
                    }
                }
                trackBar1.Value = (int)WMP.controls.currentPosition;
            }
        }

        private void button5_Click(object sender, EventArgs e)//재생 버튼
        {
            if (!musicPlay)
            {
                label5.Text = "재생 : " + musicName[timeCount];
                musicPlay = true;
                button5.Image = global::Melon2.Properties.Resources.Pause;
                trackBar1.Maximum = timeMax[timeCount];
                WMP.controls.play();
                Thread.Sleep(30);
                musicThread = new Thread(new ThreadStart(track));
                musicThread.Start();
                musicThread_alive = true;
            }
            else
            {
                musicPlay = false;
                button5.Image = global::Melon2.Properties.Resources.Play;
                WMP.controls.pause();
            }
        }

        private void button6_Click(object sender, EventArgs e)//다음버튼
        {
            if (musicPlayType == 1)
            {
                if (timeCount == maxCount - 1)
                {
                    MessageBox.Show("리스트의 마지막 곡입니다.");
                    return;
                }
                else
                {
                    timeCount++;
                    trackBar1.Maximum = timeMax[timeCount];
                    label5.Text = "재생 : " + musicName[timeCount];
                    WMP.controls.next();
                }
            }
            else if (musicPlayType == 2)
            {
                WMP.controls.stop();
                WMP.controls.play();
            }
            else if (musicPlayType == 3)
            {
                if (timeCount == maxCount - 1)
                {
                    timeCount = 0;
                    WMP.controls.next();
                    trackBar1.Maximum = timeMax[timeCount];
                    label5.Text = "재생 : " + musicName[timeCount];
                }
                else
                {
                    WMP.controls.next();
                    timeCount++;
                    trackBar1.Maximum = timeMax[timeCount];
                    label5.Text = "재생 : " + musicName[timeCount];
                }
            }
            else if (musicPlayType == 4)
            {
                int temp = timeCount;
                Random r = new Random();
                timeCount = r.Next(0, maxCount - 1);

                if (timeCount == temp)
                {
                    WMP.controls.stop();
                    WMP.controls.play();
                }

                for (; timeCount > temp; temp++)
                    WMP.controls.next();
                for (; timeCount < temp; temp--)
                    WMP.controls.previous();
                trackBar1.Maximum = timeMax[timeCount];
                label5.Text = "재생 : " + musicName[timeCount];
            }
        }

        private void button4_Click(object sender, EventArgs e)//이전버튼
        {
            if (musicPlayType == 1)
            {
                if (timeCount == 0)
                {
                    MessageBox.Show("리스트의 첫 곡입니다.");
                    return;
                }
                else
                {
                    WMP.controls.previous();
                    timeCount--;
                    trackBar1.Maximum = timeMax[timeCount];
                    label5.Text = "재생 : " + musicName[timeCount];
                }
            }
            else if (musicPlayType == 2)
            {
                WMP.controls.stop();
                WMP.controls.play();
            }
            else if (musicPlayType == 3)
            {
                if (timeCount == 0)
                {
                    timeCount = maxCount - 1;
                    WMP.controls.previous();
                    trackBar1.Maximum = timeMax[timeCount];
                    label5.Text = "재생 : " + musicName[timeCount];
                }
                else
                {
                    WMP.controls.previous();
                    timeCount--;
                    trackBar1.Maximum = timeMax[timeCount];
                    label5.Text = "재생 : " + musicName[timeCount];
                }
            }
            else if (musicPlayType == 4)
            {
                int temp = timeCount;
                Random r = new Random();
                timeCount = r.Next(0, maxCount - 1);

                if(timeCount == temp)
                {
                    WMP.controls.stop();
                    WMP.controls.play();
                }

                for (; timeCount > temp; temp++)
                    WMP.controls.next();
                for (; timeCount < temp; temp--)
                    WMP.controls.previous();
                trackBar1.Maximum = timeMax[timeCount];
                label5.Text = "재생 : " + musicName[timeCount];
            }
            label5.Text += "tme " + timeCount;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            WMP.controls.currentPosition = trackBar1.Value;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string temp;
            temp = playMusicList.FocusedItem.SubItems[0].Text;
            if (temp.IndexOf(musicName[timeCount]) != -1)
                MessageBox.Show("현재 재생중인 곡은 삭제할 수 없습니다.");
            else
            {
                int index = playMusicList.FocusedItem.Index;
                playMusicList.Items.RemoveAt(index);
                Media = (IWMPMedia)MediaSaver.GetValue(index);
                PlayList.removeItem(Media);

                for (int i = index; i < maxCount - 1 - index; i++)
                {
                    musicName[i] = musicName[i + 1];
                    timeMax[i] = timeMax[i + 1];
                    MediaSaver.SetValue((IWMPMedia)MediaSaver.GetValue(i + 1), i);
                }
                maxCount--;
                if (timeCount > index)
                    timeCount--;
                label5.Text = "재생 : " + musicName[timeCount];
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            serverStop();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 2)
                musicPlayType = 3;
            else if (comboBox1.SelectedIndex == 1)
                musicPlayType = 2;
            else if (comboBox1.SelectedIndex == 3)
                musicPlayType = 4;
            else
                musicPlayType = 1;
        }
    } 

}
