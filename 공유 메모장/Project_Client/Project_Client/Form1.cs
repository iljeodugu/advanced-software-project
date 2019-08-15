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
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Project_class;

namespace Project_Client
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        String path;
        String drPath;
        myTextBox myText;
        myTextBox my_text_box;
        public bool text_open_check; //열려있는지 확인하는 변수
        public string backup;//모르고 닫았을시의 텍스트 저장
        public string backup_filename = null;//파일이름을 저장

        private NetworkStream m_NetStream;
        private byte[] sendBuffer = new byte[1024 * 8];
        private byte[] readBuffer = new byte[1024 * 8];
        private TcpClient m_Client;
        private bool client_start = false;
        private bool m_blsConnect = false;
        private Thread m_Thread;
        private bool thread_start;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // my_text_box = new myTextBox(this);
            //my_text_box.Show();
            thread_start = false;
            listView1.View = View.Details;
            listView1.Columns.Add("번호", 40, HorizontalAlignment.Center);
            listView1.Columns.Add("이름", 70, HorizontalAlignment.Center);
            listView1.Columns.Add("상태", 140, HorizontalAlignment.Center);
            metroListView1.View = View.Details;
            metroListView1.Columns.Add("파일이름", 150, HorizontalAlignment.Center);
            metroListView1.Columns.Add("파일사이즈", 100, HorizontalAlignment.Center);
        }

        private void text_open()
        {
            if (!my_text_box.Enabled)
                my_text_box.Show();
        }

        private void button1_Click(object sender, EventArgs e)//서버켜기 버튼
        {
            if (button1.Text == "접속")
            {
                button1.Text = "끊기";
                login();
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
            }
            else
            {
                button1.Text = "접속";
                server_stop();
                listView1.Items.Clear();
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
            }
        }

        private void login()
        {
            m_Client = new TcpClient();
            try
            {
                m_Client.Connect(textBox1.Text, Convert.ToInt32(textBox2.Text));
            }
            catch
            {
                MessageBox.Show("접속 실패");
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                button1.Text = "접속";
                return;
            }

            client_start = true;
            m_blsConnect = true;
            m_NetStream = m_Client.GetStream();

            login file = new login(textBox3.Text);
            file.Type = (int)FileDataType.로그인;

            sendBuffer = FileData.Serialize(file);
            this.Send();
            m_Thread = new Thread(new ThreadStart(Receive));
            m_Thread.Start();
        }

        private void logout()
        {
            client_start = false;
            m_blsConnect = false;
            
            login file = new login(textBox3.Text);
            file.Type = (int)FileDataType.로그인;
            file.logout = true;
            sendBuffer = FileData.Serialize(file);
            this.Send();
        }

        private void server_stop()
        {
            if (client_start)
            {
                logout();
                m_Thread.Abort();
                m_NetStream.Close(); 
            }
        }

        private void Send()
        {
            m_NetStream.Write(this.sendBuffer, 0, this.sendBuffer.Length);

            this.m_NetStream.Flush();
            for (int i = 0; i < sendBuffer.Length; i++)
                sendBuffer[i] = 0;
        }

        private void Receive()//받자 파일을
        {
            while(this.m_blsConnect)
            {
                try
                {
                    this.m_NetStream.Read(this.readBuffer, 0, readBuffer.Length);
                }
                catch
                {
                    this.m_blsConnect = false;
                    this.m_NetStream = null;
                }
                FileData temp = (FileData)FileData.Deserialize(readBuffer);

                switch ((int)temp.Type)
                {
                    case (int)FileDataType.로그인:
                        {
                            break;
                        }
                    case (int)FileDataType.파일리스트:
                        {
                            filelist fList = (filelist)FileData.Deserialize(readBuffer);
                            string list = fList.fileList;
                           
                            string[] strset = list.Split('%');
                            for (int i = 1; i < strset.Length; i = i + 2)
                            {
                                ListViewItem lvi = new ListViewItem(strset[i - 1]);
                                lvi.SubItems.Add(strset[i]);
                                metroListView1.Items.Add(lvi);
                            }

                            break;
                        }
                    case (int)FileDataType.텍스트파일:
                        {
                            textFile tempText = (textFile)FileData.Deserialize(readBuffer);
                            myText.fillText(tempText.text, tempText.userName);
                            break;
                        }
                    case (int)FileDataType.파일:
                        {
                            bool open = false;

                            myFile file = (myFile)FileData.Deserialize(readBuffer);

                            FileStream fs = new FileStream(drPath + "\\" + file.filename, FileMode.Create, FileAccess.Write);

                            fs.Close();

                            fs = new FileStream(drPath + "\\" + file.filename, FileMode.Append, FileAccess.Write);

                            for (int i = 0; i < (int)file.size / (1024 * 4); i++)//파일크기만큼 반복문
                            {
                                if (open)
                                {
                                    m_NetStream.Read(readBuffer, 0, readBuffer.Length);
                                    file = (myFile)FileData.Deserialize(readBuffer);
                                }
                                fs.Write(file.data, 0, 1024 * 4);
                                open = true;
                            }
                            if (open)
                                m_NetStream.Read(readBuffer, 0, readBuffer.Length);

                            file = (myFile)FileData.Deserialize(readBuffer);
                            fs.Write(file.data, 0, (int)file.size % (1024 * 4));
                            break;
                        }

                    case (int)FileDataType.접속목록:
                        {
                            listItem listitem = (listItem)FileData.Deserialize(readBuffer);
                            if(listitem.index != -1)
                            {
                                listView1.Items.RemoveAt(listitem.index);
                                break;
                            }
                            ListViewItem item;
                            item = new ListViewItem(listitem.list);
                            listView1.Items.Add(item);

                            break;
                        }
                    case (int)FileDataType.파일체크:
                        {
                            fileCheck fCheck = (fileCheck)FileData.Deserialize(readBuffer);
                            if(fCheck.fileNeed == 0)
                            {
                                textFile tFile = new textFile(backup);
                                tFile.Type = (int)FileDataType.텍스트파일;
                                tFile.userName = textBox3.Text;
                                tFile.userIndex = fCheck.fileNumber;//원래는 파일넘버가 이게 아니지만 유저 인덱스 넘겨줌
                                sendBuffer = FileData.Serialize(tFile);

                                m_NetStream.Write(sendBuffer, 0, sendBuffer.Length);
                                m_NetStream.Flush();
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                
            }
        }

        private void button4_Click(object sender, EventArgs e)//내필기열기 버튼
        {
            if (!text_open_check)
            {
                my_text_box = new myTextBox(this);
                my_text_box.Show();
                my_text_box.Focus();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            server_stop();
        }

        private void button2_Click(object sender, EventArgs e)//필기 요청
        {
            if (listView1.FocusedItem == null)
            {
                MessageBox.Show("아무것도 선택하지 않았습니다.");
            }
            else
            {
                myText = new myTextBox();
                myText.Show();
                fileCheck fCheck = new fileCheck();
                fCheck.Type = (int)FileDataType.파일체크;
                fCheck.fileNeed = 0;
                fCheck.fileNumber = Convert.ToInt32(listView1.FocusedItem.SubItems[0].Text);
                sendBuffer = FileData.Serialize(fCheck);
                m_NetStream.Write(sendBuffer, 0, sendBuffer.Length);
                m_NetStream.Flush();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            path = openFileDialog1.FileName;
            textBox4.Text = path;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("파일을 선택해주세요");
            }
            else
            {
                FileInfo fi = new FileInfo(textBox4.Text);

                myFile myfile = new myFile();

                myfile.Type = (int)FileDataType.파일;
                myfile.size = (int)fi.Length;
                string[] filenames = path.Split('\\');
                string filename = null;

                foreach (string s in filenames)
                    filename = s;

                myfile.filename = filename;
                FileStream filestream = new FileStream(path, FileMode.Open, FileAccess.Read);

                Byte[] byteSendData = new Byte[1024 * 4];

                for (int i = 0; i < (int)fi.Length / (1024 * 4); i++)
                {
                    filestream.Read(byteSendData, 0, byteSendData.Length);//바이트단위로 뜯어서 보냄
                    myfile.data = byteSendData;

                    sendBuffer = FileData.Serialize(myfile);
                    this.Send();
                    Thread.Sleep(2);
                }
                filestream.Read(byteSendData, 0, (int)fi.Length % (1024 * 4));
                myfile.data = byteSendData;
                sendBuffer = FileData.Serialize(myfile);
                this.Send();

                filestream.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            filelist flist = new filelist();

            flist.Type = (int)FileDataType.파일리스트;

            sendBuffer = FileData.Serialize(flist);
            this.Send();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            drPath = folderBrowserDialog1.SelectedPath;
            metroTextBox1.Text = drPath;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text == "")
            {
                MessageBox.Show("경로가 선택되지 않았습니다.");
            }
            else
            {
                if (metroListView1.FocusedItem == null)
                {
                    MessageBox.Show("아무것도 선택하지 않았습니다.");
                }
                else
                {
                    fileCheck fCheck = new fileCheck();
                    fCheck.fileNeed = 1;
                    fCheck.filename = metroListView1.FocusedItem.SubItems[0].Text;
                    fCheck.Type = (int)FileDataType.파일체크;

                    sendBuffer = FileData.Serialize(fCheck);
                    this.Send();
                }
            }
        }
    }
}
