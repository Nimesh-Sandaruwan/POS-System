using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BCrypt.Net;

namespace pos_System
{
    public partial class Frmregister : Form
    {
        public Frmregister()
        {
            InitializeComponent();

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


        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;uid=root;pwd=root;database=pos";
            string CustomerName = txtusername.Text.Trim();
            string Customerpass = txtpassword.Text.Trim();

            if (string.IsNullOrEmpty(CustomerName) || string.IsNullOrEmpty(Customerpass) )
            {
                MessageBox.Show("Please enter all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(Customerpass); // Hash Password

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO register (Username, Password) VALUES (@Username, @Password)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", CustomerName);
                        cmd.Parameters.AddWithValue("@Password", hashedPassword);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                         //   MessageBox.Show("Registration Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Open login form after successful registration
                            frmlogin loginForm = new frmlogin();
                            loginForm.Show();
                            this.Close(); // Close the registration form
                        }
                        else
                        {
                            MessageBox.Show("Registration Failed! Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (MySqlException ex) when (ex.Number == 1062) // Duplicate username error
            {
                MessageBox.Show("User ID already exists. Choose a different one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void Frmregister_Load(object sender, EventArgs e)
        {
        }

        internal class show
        {
            public show()
            {
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            
        }

        private void checkshopassword_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtusername.Clear();
            txtpassword.Clear();
            
            txtusername.Focus(); // Set focus back to username field
        }
    }
    }


