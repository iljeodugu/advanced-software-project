using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project_class;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace Project_Server 
{
    delegate void del(int a);
    
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        private NetworkStream[] m_NetStream;
        private bool[] Network_start;

        private TcpListener[] m_Listener;
        private Thread[] m_Thread;
        private Thread request;
        private bool request_start = false;
        private bool[] thread_start;//스레드 꺼졋는지 확인
        private bool[] m_ClientOn;
        private bool[] connect_peopel;//접속한 인원 체크
        int people_count;
        int server_count;//접속한 사람 목록
        private bool[] mutex;

        private string path; //파일 저장 경로

        public Form1()
        {
            InitializeComponent();
            people_count = 0;
            m_NetStream = new NetworkStream[32];
            m_Listener = new TcpListener[32];
            m_Thread = new Thread[32];  
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client_text_list.View = View.Details;
            client_text_list.Columns.Add("번호", 40, HorizontalAlignment.Center);
            client_text_list.Columns.Add("이름", 70, HorizontalAlignment.Center);
            client_text_list.Columns.Add("상태", 150, HorizontalAlignment.Center);
            server_count = 0;
            people_count = 0;
            m_ClientOn = new bool[32];
            thread_start = new bool[32];
            Network_start = new bool[32];
            connect_peopel = new bool[32];
            mutex = new bool[32];
            for (int i = 0; i < 32; i++)
            {
                Network_start[i] = false;
                thread_start[i] = false;
                connect_peopel[i] = false;
                mutex[i] = true;
            }

            ip_text_box.Text = Get_myIp();
        }

        private void server_on_Click(object sender, EventArgs e)
        {
            String sDirPath = path + "\\" + textBox1.Text + "/" + textBox2.Text + "월 " + textBox3.Text + "일";

            DirectoryInfo di = new DirectoryInfo(sDirPath);

            if (di.Exists == false)

            {
                di.Create();
            }

            sDirPath = path + "\\" + textBox1.Text + "/" + textBox2.Text + "월 " + textBox3.Text + "일" + "\\file";

            di = new DirectoryInfo(sDirPath);

            if (di.Exists == false)
            {
                di.Create();
            }

            if (server_on.Text == "서버 켜기")
            {
                m_Thread[server_count] = new Thread(new ThreadStart(server_run));
                request = new Thread(new ThreadStart(Request));
                request.Start();
                request_start = true;
                m_Thread[server_count].Start();
                thread_start[server_count] = true;
                server_on.Text = "서버 끄기";
                server_on.ForeColor = Color.Red;
                port_text_box.Enabled = false;
                ip_text_box.Enabled = false;
            }
            else
            {
                server_on.Text = "서버 켜기";
                server_stop();
                server_on.ForeColor = Color.Black;
                port_text_box.Enabled = true;
                ip_text_box.Enabled = true;
            }
        }

        private void Request()
        {
            int request_count = 0;
            byte[] sendBuffer = new byte[1024 * 8];
            Thread.Sleep(4000);
            string name = null;
            while (true)
            {
                while (true)
                {
                    request_count++;
                    if (request_count == 32)
                        request_count = 0;
                    if (connect_peopel[request_count])
                    {
                        for (int i = 0; i < 32; i++)
                        {
                            if (client_text_list.Items[i].SubItems[0].Text == request_count.ToString())
                            {
                                name = client_text_list.Items[i].SubItems[1].Text;
                                break;
                            }
                        }
                        server_text_box.AppendText(name + "님의 필기 업데이트 \n");
                        break;
                    }
                    Thread.Sleep(100);
                }
                if (mutex[request_count])
                {
                    fileCheck fCheck = new fileCheck();
                    fCheck.Type = (int)FileDataType.파일체크;
                    fCheck.fileNeed = 0;
                    fCheck.fileNumber = request_count;//여기서는 유저 인덱스 박자

                    sendBuffer = FileData.Serialize(fCheck);
                    m_NetStream[request_count].Write(sendBuffer, 0, sendBuffer.Length);
                    m_NetStream[request_count].Flush();

                    mutex[request_count] = true;
                }
            }
        }

        private void server_run()//서버를 열고 갯수만큼 가지고 있자.
        {
            int count = server_count;
            byte[] sendBuffer = new byte[1024 * 8];
            byte[] readBuffer = new byte[1024 * 8];
            m_Listener[count] = new TcpListener(Convert.ToInt32(port_text_box.Text));
            this.m_Listener[0].Start();//단일 리스너로 하면 되는거 같은데 잘모르겟다.
            m_ClientOn[count] = false;
 
            Socket Client = m_Listener[0].AcceptSocket();//이것도 연결요청 대기
            server_count++;
            people_count++;
            m_Thread[server_count] = new Thread(new ThreadStart(server_run));
            m_Thread[server_count].Start();

            if (Client.Connected)
            {
                m_ClientOn[count] = true;
                m_NetStream[count] = new NetworkStream(Client);
                connect_peopel[count] = true;
                Network_start[count] = false;
            }

            while (m_ClientOn[count])
            {
                try
                {
                    m_NetStream[count].Read(readBuffer, 0, readBuffer.Length);
                }
                catch
                {
                    m_ClientOn[count] = false;
                    m_NetStream[count] = null;
                }

                FileData temp = (FileData)FileData.Deserialize(readBuffer);

                switch ((int)temp.Type)
                {
                    case (int)FileDataType.로그인:
                        {
                            login log = (login)FileData.Deserialize(readBuffer);
                            if (log.logout)
                            {
                                int check = -1;
                                m_ClientOn[count] = false;
                                for (int i = 0; i < 32; i++)
                                {
                                    if(client_text_list.Items[i].SubItems[1].Text == log.id)
                                    {
                                        check = i;
                                        break;
                                    }
                                }
                                server_text_box.AppendText(client_text_list.Items[check].SubItems[1].Text + "님이 로그아웃 하셧습니다.\n");
                                connect_peopel[Convert.ToInt32(client_text_list.Items[check].SubItems[0].Text)] = false;
                                client_text_list.Items.RemoveAt(check);

                                listItem removeItem = new listItem();
                                removeItem.index = check;
                                removeItem.Type = (int)FileDataType.접속목록;
                                sendBuffer = FileData.Serialize(removeItem);
                                for (int i = 0; i < 32; i++)
                                {
                                    if (connect_peopel[i])
                                    {
                                        m_NetStream[i].Write(sendBuffer, 0, sendBuffer.Length);
                                        this.m_NetStream[i].Flush();
                                    }
                                }
                                people_count--;
                                break;
                            }
                            ListViewItem item;
                            string[] itemStr = new string[3];
                            itemStr[0] = count.ToString();
                            itemStr[1] = log.id;
                            itemStr[2] = "접속중...";
                            item = new ListViewItem(itemStr);
                            client_text_list.Items.Add(item);
                            server_text_box.AppendText(log.id + "님이 로그인 하셧습니다.\n");

                            listItem listitem = new listItem();
                            listitem.list = itemStr;
                            listitem.index = -1;
                            listitem.Type = (int)FileDataType.접속목록;
                            sendBuffer = FileData.Serialize(listitem);
                            
                            for (int i = 0; i < 32; i++)
                            {
                                if (connect_peopel[i] && i != count)
                                {
                                    m_NetStream[i].Write(sendBuffer, 0, sendBuffer.Length);
                                    this.m_NetStream[i].Flush();
                                }
                            }
                            listitem.first = true;
                            for(int i = 0; i < people_count; i ++)
                            {
                                itemStr[0] = client_text_list.Items[i].SubItems[0].Text;
                                itemStr[1] = client_text_list.Items[i].SubItems[1].Text;
                                itemStr[2] = client_text_list.Items[i].SubItems[2].Text;
                                listitem.list = itemStr;
                                sendBuffer = FileData.Serialize(listitem);
                                m_NetStream[count].Write(sendBuffer, 0, sendBuffer.Length);
                                m_NetStream[count].Flush();
                                Thread.Sleep(100);
                            }

                            break;
                        }
                    case (int)FileDataType.텍스트파일:
                        {
                            textFile tFile = (textFile)FileData.Deserialize(readBuffer);
                            FileStream fStream = new FileStream(path + "\\" +  textBox1.Text + "/" + textBox2.Text + "월 " + textBox3.Text + "일" + "\\" + tFile.userName + ".txt", FileMode.Create, FileAccess.Write);
                            StreamWriter fWriter = new StreamWriter(fStream);
                            fWriter.Write(tFile.text);
                            mutex[tFile.userIndex] = true;
                            fWriter.Close();
                            fStream.Close();

                            break;
                        }
                    case (int)FileDataType.파일:
                        {
                            while (!mutex[count]) ;
                            mutex[count] = false;

                            bool open = false;

                            myFile file = (myFile)FileData.Deserialize(readBuffer);

                            server_text_box.AppendText(file.filename + " : 업데이트 요청 \n");

                            FileStream fs = new FileStream(path + "\\" + textBox1.Text + "/" + textBox2.Text + "월 " + textBox3.Text + "일" + "\\file\\" + file.filename , FileMode.Create, FileAccess.Write);
                            
                            fs.Close();

                            fs = new FileStream(path + "\\" + textBox1.Text + "/" + textBox2.Text + "월 " + textBox3.Text + "일" + "\\file\\" + file.filename, FileMode.Append, FileAccess.Write);

                            for (int i = 0; i < (int)file.size / (1024*4); i++)//파일크기만큼 반복문
                            {
                                if (open)
                                {
                                    m_NetStream[count].Read(readBuffer, 0, readBuffer.Length);
                                    file = (myFile)FileData.Deserialize(readBuffer);
                                }
                                fs.Write(file.data, 0, 1024 * 4);
                                open = true;
                            }
                            if(open)
                                m_NetStream[count].Read(readBuffer, 0, readBuffer.Length);

                            file = (myFile)FileData.Deserialize(readBuffer);
                            fs.Write(file.data, 0, (int)file.size % (1024*4));

                            server_text_box.AppendText(file.filename + " 업데이트\n");

                            fs.Close();
                            mutex[count] = true;
                            break;
                        }
                    case (int)FileDataType.파일리스트:
                        {
                            DirectoryInfo di = new DirectoryInfo(path + "\\" + textBox1.Text + "/" + textBox2.Text + "월 " + textBox3.Text + "일" + "\\file");
                            string fileList = "";
                            foreach (var item in di.GetFiles())
                            {
                                fileList += item.Name + "%";
                                fileList += item.Length + "%";
                            }
                            filelist fList = new filelist();
                            
                            fList.fileList = fileList;
                            fList.Type = (int)FileDataType.파일리스트;
                            sendBuffer = FileData.Serialize(fList);

                            m_NetStream[count].Write(sendBuffer, 0, sendBuffer.Length);
                            m_NetStream[count].Flush();

                            break;
                        }
                    case (int)FileDataType.파일체크:
                        {
                            string userName = null;
                            string data;
                            FileStream fStream;
                            fileCheck fileCheck = (fileCheck)FileData.Deserialize(readBuffer);
                            for (int i = 0; i < 32; i ++)
                            {
                                if (Convert.ToInt32(client_text_list.Items[i].SubItems[0].Text) == fileCheck.fileNumber)
                                {
                                    userName = client_text_list.Items[i].SubItems[1].Text;
                                    break;
                                }
                            }

                            if ( fileCheck.fileNeed ==0 )//파일이 text 라면
                            {
                                while (!mutex[count]);
                                mutex[count] = false;

                                fStream = new FileStream(path + "\\" + textBox1.Text + "/" + textBox2.Text + "월 " + textBox3.Text + "일" + "\\" + userName + ".txt", FileMode.OpenOrCreate, FileAccess.Read);
                                StreamReader streamReader = new StreamReader(fStream);
                                data = streamReader.ReadToEnd();

                                textFile tFIle = new textFile(data);
                                tFIle.text = data;
                                tFIle.userName = userName;
                                tFIle.Type = (int)FileDataType.텍스트파일;
                                
                                sendBuffer = FileData.Serialize(tFIle);
                                m_NetStream[count].Write(sendBuffer, 0, sendBuffer.Length);
                                m_NetStream[count].Flush();
                                streamReader.Close();
                                fStream.Close();

                                mutex[count] = true;
                            }
                            else if(fileCheck.fileNeed ==1)
                            {
                                while (!mutex[count]) ;
                                mutex[count] = false;
                                string filename = fileCheck.filename;

                                server_text_box.AppendText(filename + " : 전송요청 \n");

                                fStream = new FileStream(path + "\\" + textBox1.Text + "/" + textBox2.Text + "월 " + textBox3.Text + "일" + "\\file\\" + filename, FileMode.OpenOrCreate, FileAccess.Read);
                                StreamReader streamReader = new StreamReader(fStream);

                                System.IO.FileInfo fi = new FileInfo(path + "\\" + textBox1.Text + "/" + textBox2.Text + "월 " + textBox3.Text + "일" + "\\file\\" + filename);

                                myFile myfile = new myFile();
                                myfile.Type = (int)FileDataType.파일;
                                myfile.size = (int)fi.Length;
                                myfile.filename = filename;

                                Byte[] byteSendData = new Byte[1024 * 4];

                                for (int i = 0; i < (int)fi.Length / (1024 * 4); i++)
                                {
                                    fStream.Read(byteSendData, 0, byteSendData.Length);//바이트단위로 뜯어서 보냄
                                    myfile.data = byteSendData;
                                    sendBuffer = FileData.Serialize(myfile);
                                    m_NetStream[count].Write(sendBuffer, 0, sendBuffer.Length);
                                    m_NetStream[count].Flush();
                                    Thread.Sleep(2);
                                }
                                fStream.Read(byteSendData, 0, (int)fi.Length % (1024 * 4));
                                myfile.data = byteSendData;
                                sendBuffer = FileData.Serialize(myfile);
                                m_NetStream[count].Write(sendBuffer, 0, sendBuffer.Length);
                                m_NetStream[count].Flush();

                                server_text_box.AppendText(filename + " : 전송 완료 \n");
                                mutex[count] = true;
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

        public string Get_myIp()
        {
            IPHostEntry host = Dns.GetHostByName(Dns.GetHostName());
            string myIp = host.AddressList[0].ToString();
            return myIp;
        }

        private void server_stop()
        {
            for (int i = 0; i < 32; i++)
            {
                if (thread_start[i])
                {
                    m_Listener[i].Stop();
                    m_Thread[i].Abort();
                }
                if (Network_start[i])
                    m_Listener[i].Stop();
            }
            if (request_start)
                request.Abort();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            server_stop();
        }

        private void findPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            path = folderBrowserDialog1.SelectedPath;
            path_text_box.Text = path;
        }

        private void direcOpen_Click(object sender, EventArgs e)
        {
            if (path_text_box.Text == "")
                MessageBox.Show("경로를 설정해주세요");
            else
            {
                String sDirPath = path + "\\" + textBox1.Text + "/" + textBox2.Text + "월 " + textBox3.Text + "일";

                DirectoryInfo di = new DirectoryInfo(sDirPath);

                if (di.Exists == false)
                {
                    di.Create();
                }

                sDirPath = path + "\\" + textBox1.Text + "/" + textBox2.Text + "월 " + textBox3.Text + "일" + "\\file";

                di = new DirectoryInfo(sDirPath);

                if (di.Exists == false)
                {
                    di.Create();
                }
                Process.Start(path + "\\" + textBox1.Text + "/" + textBox2.Text + "월 " + textBox3.Text + "일");
            }
        }

        private void check_text_Click(object sender, EventArgs e)
        {
            myTextBox text;
            int count;
            if (client_text_list.FocusedItem == null)
            {
                MessageBox.Show("아무것도 선택하지 않았습니다.");
            }
            else
            {
                String data;
                FileStream fStream;
                count = Int32.Parse(client_text_list.FocusedItem.SubItems[0].Text);
                while (!mutex[count]) ;
                mutex[count] = false;

                fStream = new FileStream(path + "\\" + textBox1.Text + "/" + textBox2.Text + "월 " + textBox3.Text + "일" + "\\" + client_text_list.FocusedItem.SubItems[1].Text + ".txt", FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader streamReader = new StreamReader(fStream);

                data = streamReader.ReadToEnd();
                streamReader.Close();
                fStream.Close();

                mutex[count] = true;
                text = new myTextBox(client_text_list.FocusedItem.SubItems[1].Text,data);
                text.Show();
            }
        }
    }
}
