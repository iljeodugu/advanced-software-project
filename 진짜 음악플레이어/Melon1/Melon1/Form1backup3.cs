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

namespace Melon1
{
    public partial class Form1 : Form
    {
        public string path; //경로 저장 
        public Socket hClient;
        public NetworkStream m_Stream;
        public StreamReader m_Read;
        public StreamWriter m_Write;
        private Thread m_thReader;
        private string[] query;//쿼리를 저장을 해놓자
        string[] fileArray;//파일이 모두 저장된 파일
        bool is_OK = false;
        
        public bool m_bStop = false;
        public bool lister_alive = false;
        private TcpListener m_listener;
        private Thread m_thServer;

        FileStream filestream;

        public bool m_bCounnect = false;
        bool stream_alive = false;
        bool m_thread_live = false;
        bool m_thServer_live = false;


        public Form1()
        {
            InitializeComponent();
            ipTextBox.Text = Get_myIp();
            init_List();
            query = new string[512];
        }//폼을 불러옴

        private void init_List()//리스트 초기화를 위한 함수
        {
            this.musicList.View = View.Details;
            this.musicList.Columns.Add("Music Name", 180, HorizontalAlignment.Left);
            this.musicList.Columns.Add("Artist", 60, HorizontalAlignment.Center);
            this.musicList.Columns.Add("Play Time", 100, HorizontalAlignment.Center);
            this.musicList.Columns.Add("Bit Rate", 100, HorizontalAlignment.Left);
            portTextBox.Text = "7777";
        }
        
        private void list_print(string path)//리스트에 그리자
        {
            string[] temp = new string[4];
            string filename = null;
            string[] tempstr= new string[10];
            ListViewItem item;
            ShellClass shell = new ShellClass();
            Folder folder = shell.NameSpace(path);
            FolderItem mp3file;
            char spr = '\\';
            int i=0;
            fileArray = Directory.GetFiles(path, "*.mp3");
            foreach (string str in fileArray)
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
                query[i] = temp[0];
                query[i] += "@" + temp[1] + "@" + temp[2] + "@" + temp[3];
                i++;
                item = new ListViewItem(temp);
                musicList.Items.Add(item);
            }
        }

        public string Get_myIp()
        {
            IPHostEntry host = Dns.GetHostByName(Dns.GetHostName());
            string myIp = host.AddressList[0].ToString();
            return myIp;
        }//내아이피 따오기

        private void Form1_Load(object sender, EventArgs e)
        {
        }//폼초기화

        private void IP_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void musicList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }//리스트 체크

        private void button1_Click(object sender, EventArgs e)//start 버튼
        {
            if (pathTextBox.Text == "")
                MessageBox.Show("전송 가능한 MP3파일이 없습니다. 경로를 다시 지정하십시오.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else
            {
                if (button1.Text == "Start")
                {
                    button1.Text = "Stop";
                    m_thServer = new Thread(new ThreadStart(serverRun));
                    m_thServer.Start();
                    m_thServer_live = true;
                }
                else
                {
                    button1.Text = "Start";
                    serverStop();
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

        private void serverStop()
        {
            m_bCounnect = false;
            m_bStop = false;

            if(lister_alive)
                m_listener.Stop();

            if (stream_alive)
            {
                m_Read.Close();
                m_Write.Close();
                m_Stream.Close();
            }
            if(m_thServer_live)
                m_thServer.Abort();
            if(m_thread_live)
                m_thReader.Abort();
            
        }

        private void serverRun()
        {
            try
            {
                int portNumber = Int32.Parse(portTextBox.Text);

                m_listener = new TcpListener(portNumber);
                m_listener.Start();
                lister_alive = true;

                m_bStop = true;
                serverTextBox.AppendText("Server-Start\n");
                serverTextBox.AppendText("Storage Path : " + path + "\n");
                serverTextBox.AppendText("wating for client access...\n");
                bool first_Check = true;
                while (m_bStop)
                {
                    hClient = m_listener.AcceptSocket();
                    
                    if(hClient.Connected)
                    {
                        serverTextBox.AppendText("Client Acess!!\n");

                        m_Stream = new NetworkStream(hClient);
                        m_Read = new StreamReader(m_Stream);
                        m_Write = new StreamWriter(m_Stream);

                        stream_alive = true;
                        m_bCounnect = true;
                        m_thReader = new Thread(new ThreadStart(Receive));
                        m_thReader.Start();
                        m_thread_live = true;
                    }

                    if(first_Check)
                    {
                        first_Check = false;
                        foreach (string query_str in query)
                        {
                            if (query_str == null)
                                break;
                            
                            m_Write.WriteLine(query_str);
                            m_Write.Flush();
                        }
                        m_Write.WriteLine("End Query");
                        m_Write.Flush();
                    }
                }
            }
            catch
            {
                MessageBox.Show("서버가 종료되었습니다.");
            }
        }

        private void Receive()//파일 날아옴
        {
            try
            {
                while (m_bCounnect)
                {
                    string szMessage = m_Read.ReadLine();

                    if (szMessage != null)
                    {
                        is_OK = true;
                        serverTextBox.AppendText("Download Requested\n");
                        serverTextBox.AppendText("Send File : " + szMessage + "\n");
                        sendFile(szMessage);
                    }
                }
            }
            catch
            {
                MessageBox.Show("서버에서 파일을 받는데 문제가 생겼습니다.");
            }

            m_thReader.Abort();
            m_thread_live = false;
        }

        private void sendFile(string requestFileName)
        {
            
            string saveStr = null;
            string szMesage;
            foreach(string str in fileArray)
            {
                saveStr = str;
                if (str.IndexOf(requestFileName) != -1)
                    break;
            }
            filestream = new FileStream(saveStr, FileMode.Open, FileAccess.Read);
            FileInfo fi = new FileInfo(saveStr);
            long lngFileLenght = fi.Length;

            Byte[] byteSendData = new Byte[1024];

            m_Write.WriteLine("Sending File@" + fi.Length.ToString());
            m_Write.Flush();

            int i = 0;
            for (i = 0; i< (int)fi.Length/1024; )
            {
                if (is_OK)
                {
                    filestream.ReadAsync(byteSendData, 0, 1024);
                    m_Stream.Write(byteSendData, 0, 1024);
                    m_Stream.Flush();
                    is_OK = false;
                    i++;
                    Thread.Sleep(1);
                }
                while(true)//TCP 규약 지키자
                {
                    szMesage = m_Read.ReadLine();
                    if(szMesage !=null)
                    {
                        is_OK = true;
                        break;
                    }
                }
            }
            filestream.Close();
        }

        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            serverStop();
        }
    }
}
