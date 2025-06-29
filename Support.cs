using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos_System
{
    public partial class Support : Form
    {



        public Support()
        {
            InitializeComponent();
        }

        private void Support_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            dashbord dashbord = new dashbord();
            dashbord.Show();
            this.Hide();

        }
    }
}
