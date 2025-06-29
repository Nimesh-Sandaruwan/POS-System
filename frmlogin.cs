using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BCrypt.Net;

namespace pos_System
{
    public partial class frmlogin : Form
    {
        public frmlogin()
        {
            InitializeComponent();
            checkshopassword.CheckedChanged += Checkshopassword_CheckedChanged;
            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
            label6.Click += Label6_Click; // "Back to LOGIN" label (if needed)


            txtusername.KeyDown += MoveToNextControl;
            txtpassword.KeyDown += MoveToNextControl;
            button1.KeyDown += MoveToNextControl;
            button2.KeyDown += MoveToNextControl;
            label6.KeyDown += MoveToNextControl;

        }


        private void MoveToNextControl(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // avoid beep sound
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;uid=root;pwd=root;database=pos";
            string username = txtusername.Text.Trim();
            string password = txtpassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both Username and Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Password FROM register WHERE Username = @Username";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            string storedHashedPassword = result.ToString();

                            if (BCrypt.Net.BCrypt.Verify(password, storedHashedPassword))
                            {
                                //   MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Open Dashboard Form
                                dashbord dashboard = new dashbord();
                                dashboard.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("User does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // Clear username and password fields
            txtusername.Text = "";
            txtpassword.Text = "";
            txtusername.Focus();
        }

        private void Checkshopassword_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle password visibility
            txtpassword.UseSystemPasswordChar = !checkshopassword.Checked;
        }

        private void Label6_Click(object sender, EventArgs e)
        {
            // Navigate to another form if needed
            MessageBox.Show("Back to login clicked!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void checkshopassword_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkshopassword.Checked)
            {
                txtpassword.PasswordChar = '\0'; // Show password

            }
            else
            {
                txtpassword.PasswordChar = '*'; // Mask password

            }
        }

        private void label6_Click_1(object sender, EventArgs e)
        {
            Frmregister registerForm = new Frmregister();
            registerForm.Show();
            this.Hide(); // Hide the login form
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            txtusername.Clear();
            txtpassword.Clear();

            txtusername.Focus(); // Set focus back to username field
        }

        private void frmlogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

