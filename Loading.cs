using System;
using System.Windows.Forms;

namespace pos_System
{
    public partial class Loading : Form
    {
        private System.Windows.Forms.Timer timer1; // 🟢 Timer එක නිවැරදිව define කරන්න

        public Loading()
        {
            InitializeComponent();

            // Timer එක Initialize කිරීම
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 50; // 50ms update speed
            timer1.Tick += Timer1_Tick; // Timer එකට method එක attach කරන්න
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Step = 1;
            progressBar1.Value = 0;

            timer1.Start(); // Timer එක start කරන්න
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 1;
            }
            else
            {
                timer1.Stop(); // Timer එක නවත්වන්න
               

                // 🟢 frmLogin එක open කරන්න
                frmlogin loginForm = new frmlogin();
                loginForm.Show();

                // 🔴 Loading Form එක වසන්න
                this.Hide();
            }
        }
    }
}
