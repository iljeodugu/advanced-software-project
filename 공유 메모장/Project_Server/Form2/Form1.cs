using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form2
{
    public partial class myTextBox : MetroFramework.Forms.MetroForm
    {
        public myTextBox()
        {
            InitializeComponent();
        }

        public myTextBox(String userName, String memo)
        {
            InitializeComponent();
            this.Text = userName;
            metroTextBox1.Text = memo;
        }

        private void myTextBox_Load(object sender, EventArgs e)
        {

        }
    }
}
