using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2_client
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(string name, string file_type, string locate, string size, string make_day, string fix_day, string access_day)
        {
            InitializeComponent();
            textBox1.Text = name;
            file_type_label.Text = file_type;
            file_locate_label.Text = locate;
            file_size_label.Text = size;
            make_day_label.Text = make_day;
            fix_day_label.Text = fix_day;
            access_day_label.Text = access_day;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void picture_box_image_Change(string name)
        {
            if (name == "avi")
                pictureBox1.Image = Project2_client.Properties.Resources.avi;
            else if (name == "image")
                pictureBox1.Image = Project2_client.Properties.Resources.image;
            else if (name == "folder")
                pictureBox1.Image = Project2_client.Properties.Resources.folder;
            else if (name == "text")
                pictureBox1.Image = Project2_client.Properties.Resources.text;
            else if (name == "music")
                pictureBox1.Image = Project2_client.Properties.Resources.music;
            else if (name == "temp")
                pictureBox1.Image = Project2_client.Properties.Resources.temp;

        }
    }
}
