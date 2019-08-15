using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net.Sockets;
using System.Drawing;
using Project2_class;
using System.IO;

namespace Project2_client
{
    public partial class Form1 : Form
    {
        private NetworkStream m_networkstream;
        private TcpClient m_client;

        private byte[] sendBuffer = new byte[1024 * 4];
        private byte[] readBuffer = new byte[1024 * 4];

        public bool stream_on = false;

        public file_info m_file_info_class;
        public folder_Info m_folder_info_class;

        public bool m_bConnect;

        public void Send()
        {
            this.m_networkstream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
            this.m_networkstream.Flush();

            for (int i = 0; i < 1024 * 4; i++)
            {
                this.sendBuffer[i] = 0;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//서버켜기
        {
            if (button1.Text == "서버연결")
            {
                button1.ForeColor = Color.Red;
                button1.Text = "서버끊기";
                this.m_client = new TcpClient();
                try
                {
                    this.m_client.Connect(this.ip_txt_box.Text, Int32.Parse(port_txt_box.Text));
                }
                catch
                {
                    MessageBox.Show("접속에러");
                    return;
                }
                this.m_networkstream = this.m_client.GetStream();
                
                stream_on = true;
                init_data();
            }
            else
            {
                button1.Text = "서버연결";
                button1.ForeColor = Color.Black;
            }
        }

        public void disconnect()
        {
            if (stream_on)
            {
                m_networkstream.Close();
                m_client.Close();
            }

            m_bConnect = false;
        }

        private void button2_Click(object sender, EventArgs e)//경로설정
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                path_text_box.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button3_Click(object sender, EventArgs e)//폴더열기
        {
            if(path_text_box.Text == "")
                MessageBox.Show("경로를 설정되어있지 않습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                Process.Start(path_text_box.Text);
        }

        private void mnuView_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            mnuDetail.Checked = false;
            mnuList.Checked = false;
            mnuSmall.Checked = false;
            mnuLarge.Checked = false;

            switch (item.Text)
            {
                case "자세히":
                    mnuDetail.Checked = true;
                    lvwFiles.View = View.Details;
                    break;
                case "간단히":
                    mnuList.Checked = true;
                    lvwFiles.View = View.List;
                    break;
                case "작은아이콘":
                    mnuSmall.Checked = true;
                    lvwFiles.View = View.SmallIcon;
                    break;
                case "큰아이콘":
                    mnuLarge.Checked = true;
                    lvwFiles.View = View.LargeIcon;
                    break;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            disconnect();
        }

        private void delete_Click(object sender, EventArgs e)
        {

        }

        private void detail_info_Click(object sender, EventArgs e)
        {
            try
            {
                detail_request();
            }
            catch
            {
                ;
            }
        }

        public void detail_request()
        {
            ListViewItem temp_item = lvwFiles.SelectedItems[0];

            detail_info_request temp_request = new detail_info_request();
            temp_request.file_type = temp_item.Tag.ToString();
            temp_request.detail_path = trvDir.SelectedNode.FullPath + "\\" + temp_item.Text;
            temp_request.Type = (int)PacketType.상세정보요청;

            Packet.Serialize(temp_request).CopyTo(this.sendBuffer, 0);
            this.Send();

            this.m_networkstream.Read(readBuffer, 0, 1024 * 4);
            detail_info_response temp_response = new detail_info_response();
            temp_response = (detail_info_response)Packet.Desserialize(this.readBuffer);

            Form2 detail_form;

            if (temp_response.dir_type == "D")
            {
                detail_form = new Form2(temp_item.Text, "Directory",
                    temp_request.detail_path, "",
                    temp_response.di_info.CreationTime.ToString(),
                    temp_response.di_info.LastWriteTime.ToString(),
                    temp_response.di_info.LastAccessTime.ToString());
                detail_form.picture_box_image_Change("folder");
            }
            else
            {
                detail_form = new Form2(temp_item.Text, temp_response.file_info.Extension.ToString().Replace(".", ""),
                    temp_request.detail_path, temp_response.file_info.Length + " 바이트",
                    temp_response.file_info.CreationTime.ToString(),
                    temp_response.file_info.LastWriteTime.ToString(),
                    temp_response.file_info.LastAccessTime.ToString());
                if (temp_response.file_info.Extension.ToString().Contains("avi") || temp_response.file_info.Extension.ToString().Contains("mpg") || temp_response.file_info.Extension.ToString().Contains("mov"))
                    detail_form.picture_box_image_Change("avi");
                else if (temp_response.file_info.Extension.ToString().Contains("jpg") || temp_response.file_info.Extension.ToString().Contains("png"))
                    detail_form.picture_box_image_Change("image");
                else if (temp_response.file_info.Extension.ToString().Contains("mp3") || temp_response.file_info.Extension.ToString().Contains("wav"))
                    detail_form.picture_box_image_Change("music");
                else if (temp_response.file_info.Extension.ToString().Contains("docx") || temp_response.file_info.Extension.ToString().Contains("hwp") || temp_response.file_info.Extension.ToString().Contains("txt"))
                    detail_form.picture_box_image_Change("text");
                else
                    detail_form.picture_box_image_Change("temp");
            }
            detail_form.Show();
        }

        public void init_data()
        {
            init_data_request request_data = new init_data_request();
            request_data.Type = (int)PacketType.초기화데이터요청;

            Packet.Serialize(request_data).CopyTo(this.sendBuffer, 0);
            this.Send();

            this.m_networkstream.Read(readBuffer, 0, 1024 * 4);

            init_data_response temp_respnse = (init_data_response)Packet.Desserialize(this.readBuffer);

            TreeNode root;

            root = trvDir.Nodes.Add(temp_respnse.rootName);
            root.ImageIndex = 1;

            if (trvDir.SelectedNode == null)
                trvDir.SelectedNode = root;
            root.SelectedImageIndex = root.ImageIndex;
            root.Nodes.Add("");
        }

        private void trvDir_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            before_expand_request request_data = new before_expand_request();
            request_data.Type = (int)PacketType.beforeExpand요청;

            e.Node.Nodes.Clear();
            request_data.dir_path = e.Node.FullPath;

            Packet.Serialize(request_data).CopyTo(this.sendBuffer, 0);
            this.Send();

            this.m_networkstream.Read(readBuffer, 0, 1024 * 4);

            before_expand_response temp_response = (before_expand_response)Packet.Desserialize(this.readBuffer);

            foreach (dir_info temp_dir in temp_response.dir_list)
            {
                TreeNode node = e.Node.Nodes.Add(temp_dir.file_name);
                if (temp_dir.is_dir)
                    node.Nodes.Add("");
            }
        }

        private void trvDir_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            ListViewItem item;

            before_select_request request_data = new before_select_request();
            request_data.Type = (int)PacketType.beforeSelect요청;

            lvwFiles.Items.Clear();
            request_data.dir_path = e.Node.FullPath;
            
            Packet.Serialize(request_data).CopyTo(this.sendBuffer, 0);
            
            this.Send();

            this.m_networkstream.Read(readBuffer, 0, 1024 * 4);
            before_select_response temp_response = (before_select_response)Packet.Desserialize(this.readBuffer);

            lvwFiles.Items.Clear();
            foreach (DirectoryInfo tdis in temp_response.diArray)
            {
                item = lvwFiles.Items.Add(tdis.Name);
                item.SubItems.Add("");
                item.SubItems.Add(tdis.LastWriteTime.ToString());
                item.ImageIndex = 1;
                item.Tag = "D";
            }

            foreach (FileInfo fis in temp_response.fiArray)
            {
                item = lvwFiles.Items.Add(fis.Name);
                item.SubItems.Add(fis.Length.ToString());
                item.SubItems.Add(fis.LastWriteTime.ToString());
                if(fis.Extension.ToString().Contains("avi") || fis.Extension.ToString().Contains("mpg") || fis.Extension.ToString().Contains("mov"))
                    item.ImageIndex = 0;
                else if (fis.Extension.ToString().Contains("jpg") || fis.Extension.ToString().Contains("png"))
                    item.ImageIndex = 2;
                else if (fis.Extension.ToString().Contains("mp3") || fis.Extension.ToString().Contains("wav"))
                    item.ImageIndex = 3;
                else if (fis.Extension.ToString().Contains("docx") || fis.Extension.ToString().Contains("hwp") || fis.Extension.ToString().Contains("txt"))
                    item.ImageIndex = 5;
                else
                    item.ImageIndex = 4;

                item.Tag = "F";
            }
        }

        public void OpenFIles()
        {
            ListView.SelectedListViewItemCollection siList;
            siList = lvwFiles.SelectedItems;

            foreach (ListViewItem item in siList)
            {
                OpenItem(item);
            }
        }

        public void OpenItem(ListViewItem item)
        {
            TreeNode node;
            TreeNode child;

            if (item.Tag.ToString() == "D")
            {
                node = trvDir.SelectedNode;
                node.Expand();

                child = node.FirstNode;

                while (child != null)
                {
                    if (child.Text == item.Text)
                    {
                        trvDir.SelectedNode = child;
                        trvDir.Focus();
                        break;
                    }
                    child = child.NextNode;
                }
            }
            else
            {
                detail_request();
            }
        }

        private void lvwFiles_DoubleClick(object sender, EventArgs e)
        {
            OpenFIles();
        }
    }
}
