using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Net;
using Project2_class;
using System.Collections;

namespace Project2_server
{
    public partial class Form1 : Form
    {
        private NetworkStream m_networkstream;
        public TcpListener server = null;

        private byte[] sendBuffer = new byte[1024 * 4];
        private byte[] readBuffer = new byte[1024 * 4];

        private bool m_bClientOn = false;
        public bool m_bConnect = false;

        public bool thread_on = false;
        private Thread m_thread;

        public bool m_thReader_on = false;
        private Thread m_thReader;

        public bool stream_on = false;

        public Form1()
        {
            InitializeComponent();
        }

        public void Send()
        {
            this.m_networkstream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
            this.m_networkstream.Flush();

            for (int i = 0; i < 1024 * 4; i++)
            {
                this.sendBuffer[i] = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(button2.Text == "서버끊기")
            {
                MessageBox.Show("서버가 켠 상태에서는 경로를 수정할 수 없습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                path_text_box.Text = folderBrowserDialog1.SelectedPath;
                log_txt_box.AppendText(folderBrowserDialog1.SelectedPath + "로 경로가 수정되었습니다.\n");
            }
        }

        public void ServerStart()
        {
            try
            {
                IPAddress localAddr = IPAddress.Parse(ip_txt_box.Text);
                int port_num = Int32.Parse(port_txt_box.Text);

                server = new TcpListener(localAddr, port_num);
                server.Start();
               
                m_bClientOn = true;
                this.Invoke(new MethodInvoker(delegate ()
                { 
                    this.log_txt_box.AppendText("클라이언트 접속 대기중...\n");
                }));
                
                while (m_bClientOn)
                {
                    TcpClient hClient = server.AcceptTcpClient();
                    
                    if (hClient.Connected)
                    {
                        m_bConnect = true;
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            this.log_txt_box.AppendText("클라이언트 접속\n");
                        }));

                        stream_on = true;
                        m_networkstream = hClient.GetStream();

                        m_thReader = new Thread(new ThreadStart(Receive));
                        m_thReader_on = true;
                        m_thReader.Start();
                    }
                }
            }
            catch
            {
                log_txt_box.AppendText("시작 도중에 오류 발생");
                disconnect();
                return;
            }
        }

        public void Receive()
        {
            try
            {
                while (m_bConnect)
                {
                    try
                    {
                        this.m_networkstream.Read(readBuffer, 0, 1024 * 4);
                    }
                    catch
                    {
                        disconnect();
                    }


                    Packet packet = (Packet)Packet.Desserialize(this.readBuffer);

                    switch ((int)packet.Type)
                    {
                        case (int)PacketType.초기화데이터요청:
                            {
                                string Drv = path_text_box.Text;
                                init_data_response temp_init_response = new init_data_response();

                                temp_init_response.rootName = path_text_box.Text;
                                Packet.Serialize(temp_init_response).CopyTo(this.sendBuffer, 0);

                                this.Send();

                                break;
                            }
                        case (int)PacketType.beforeExpand요청:
                            {
                                before_expand_request temp_request = (before_expand_request)Packet.Desserialize(this.readBuffer);

                                DirectoryInfo dir = new DirectoryInfo(temp_request.dir_path);
                                DirectoryInfo[] di = dir.GetDirectories();
                                before_expand_response temp_before_expand_response = new before_expand_response();
                                ArrayList temp_arr = new ArrayList();

                                int count = 0;
                                foreach (DirectoryInfo dirs in di)
                                {
                                    DirectoryInfo[] temp_di;
                                    string temp_path = temp_request.dir_path.ToString() + "\\" + dirs.Name.ToString();

                                    DirectoryInfo temp_dir = new DirectoryInfo(temp_path);
                                    dir_info temp_dir_info = new dir_info();
                                    temp_di = temp_dir.GetDirectories();
                                    temp_dir_info.file_name = dirs.Name;
                                    if (temp_di.Length > 0)
                                        temp_dir_info.is_dir = true;
                                    else
                                        temp_dir_info.is_dir = false;

                                    temp_arr.Add(temp_dir_info);
                                    count++;
                                }

                                temp_before_expand_response.dir_list = new dir_info[count];

                                count = 0;
                                foreach (dir_info dirs in temp_arr)
                                {
                                    temp_before_expand_response.dir_list[count].file_name = dirs.file_name;
                                    temp_before_expand_response.dir_list[count].is_dir = dirs.is_dir;
                                    count++;
                                }

                                temp_before_expand_response.Type = (int)PacketType.beforeExpand요청;
                                Packet.Serialize(temp_before_expand_response).CopyTo(this.sendBuffer, 0);

                                this.Send();

                                break;
                            }
                        case (int)PacketType.beforeSelect요청:
                            {
                                DirectoryInfo di;
                                DirectoryInfo[] diArray;
                                FileInfo[] fiArray;

                                before_select_request temp_request = (before_select_request)Packet.Desserialize(this.readBuffer);
                                di = new DirectoryInfo(temp_request.dir_path);

                                diArray = di.GetDirectories();
                                fiArray = di.GetFiles();

                                before_select_response temp_response = new before_select_response();
                                temp_response.fiArray_len = fiArray.Length;
                                temp_response.diArray_len = diArray.Length;
                                temp_response.fiArray = new FileInfo[fiArray.Length];
                                temp_response.diArray = new DirectoryInfo[diArray.Length];

                                int count = 0;
                                foreach (FileInfo temp_info in fiArray)
                                    temp_response.fiArray[count++] = temp_info;
                                count = 0;
                                foreach (DirectoryInfo temp_info in diArray)
                                    temp_response.diArray[count++] = temp_info;

                                temp_response.Type = (int)PacketType.beforeSelect응답;
                                Packet.Serialize(temp_response).CopyTo(this.sendBuffer, 0);

                                this.Send();
                                break;
                            }
                        case (int)PacketType.상세정보요청:
                            {
                                detail_info_request temp_request = (detail_info_request)Packet.Desserialize(this.readBuffer);
                                detail_info_response temp_response = new detail_info_response();

                                if (temp_request.file_type == "D")
                                {
                                    temp_response.dir_type = "D";
                                    temp_response.di_info = new DirectoryInfo(temp_request.detail_path);
                                    temp_response.file_info = null;
                                }
                                else
                                {
                                    temp_response.dir_type = "F";
                                    temp_response.file_info = new FileInfo(temp_request.detail_path);
                                    temp_response.di_info = null;
                                }

                                temp_response.Type = (int)PacketType.상세정보응답;
                                Packet.Serialize(temp_response).CopyTo(this.sendBuffer, 0);

                                this.Send();
                                break;
                            }
                    }
                }
            }
            catch
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    button2.Text = "서버켜기";
                    button2.ForeColor = Color.Black;
                    log_txt_box.AppendText("접속 종료...\n");
                    disconnect();
                }));
            }
        }

        public void disconnect()
        {
            m_bClientOn = false;
            if (stream_on)
            {
                m_networkstream.Close();
                server.Stop();
                stream_on = false;
            }
            if (thread_on)
            {
                m_thread.Abort();
                thread_on = false;
            }
            if(m_thReader_on)
            {
                m_thReader.Abort();
                m_thReader_on = false;
            }
            thread_on = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (path_text_box.Text == "")
            {
                MessageBox.Show("경로를 선택해주세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (button2.Text == "서버켜기")
                {
                    button2.Text = "서버끊기";
                    button2.ForeColor = Color.Red;
                    m_thread = new Thread(new ThreadStart(ServerStart));
                    thread_on = true;
                    m_thread.Start();
                }
                else
                {
                    button2.Text = "서버켜기";
                    button2.ForeColor = Color.Black;
                    log_txt_box.AppendText("접속 종료...\n");
                    disconnect();
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            disconnect();
        }
    }
}
