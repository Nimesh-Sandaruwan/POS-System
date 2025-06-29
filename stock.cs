using MySql.Data.MySqlClient;
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
    public partial class stock : Form
    {
        private Size originalSize;
        private Dictionary<Control, Rectangle> originalControlBounds = new Dictionary<Control, Rectangle>();
        private bool isLoaded = false;

        public stock()
        {
            InitializeComponent();

            // Allow form to handle key events (optional)
            this.KeyPreview = true;
            this.KeyDown += Stock_KeyDown;
            LoadCatagaryList();
            CountCatagaries();
            LoadTotalQuantity();
            LoadTotalValueForAllItems();

            // Attach resize event
            this.Resize += stock_Resize;
        }

        private void stock_Load(object sender, EventArgs e)
        {
            // Set form to full screen
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.Sizable;

            // Save original size and control bounds
            originalSize = this.Size;
            foreach (Control control in this.Controls)
            {
                originalControlBounds[control] = control.Bounds;
            }

            isLoaded = true;
        }

        private void stock_Resize(object sender, EventArgs e)
        {
            if (!isLoaded || originalSize.Width == 0 || originalSize.Height == 0)
                return;

            float widthRatio = (float)this.Width / originalSize.Width;
            float heightRatio = (float)this.Height / originalSize.Height;

            foreach (var kvp in originalControlBounds)
            {
                ResizeControl(kvp.Key, kvp.Value, widthRatio, heightRatio);
            }
        }

        private void ResizeControl(Control control, Rectangle originalBounds, float widthRatio, float heightRatio)
        {
            int newX = (int)(originalBounds.X * widthRatio);
            int newY = (int)(originalBounds.Y * heightRatio);
            int newWidth = (int)(originalBounds.Width * widthRatio);
            int newHeight = (int)(originalBounds.Height * heightRatio);

            control.Bounds = new Rectangle(newX, newY, newWidth, newHeight);

            float newFontSize = control.Font.Size * Math.Min(widthRatio, heightRatio);

            if (newFontSize >= 6 && newFontSize < float.MaxValue &&
                !float.IsInfinity(newFontSize) && !float.IsNaN(newFontSize))
            {
                control.Font = new Font(control.Font.FontFamily, newFontSize);
            }
        }

        private void Stock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dashbord dashbord = new dashbord();
            dashbord.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            dashbord dashbord = new dashbord();
            dashbord.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            stock stock = new stock();
            stock.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Reporting Reporting = new Reporting();
            Reporting.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;uid=root;pwd=root;database=pos";
            string selectedCatagary = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedCatagary))
            {
                MessageBox.Show("Please select a catagary.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT * FROM items WHERE catagary = @Catagary";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Catagary", selectedCatagary);

                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // ✅ DEBUG: Check if any data was loaded
                        // MessageBox.Show("Rows loaded: " + dt.Rows.Count);

                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadCatagaryList()
        {
            string connectionString = "server=localhost;uid=root;pwd=root;database=pos";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT DISTINCT catagary FROM items";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        comboBox1.Items.Clear();

                        while (reader.Read())
                        {
                            comboBox1.Items.Add(reader["catagary"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load catagary list: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CountCatagaries()
        {
            string connectionString = "server=localhost;uid=root;pwd=root;database=pos";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT COUNT(DISTINCT catagary) FROM items";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        int count = Convert.ToInt32(result);

                        textBox1.Text = count.ToString(); // ✅ convert int to string
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error counting catagarys: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadTotalQuantity()
        {
            string connectionString = "server=localhost;uid=root;pwd=root;database=pos";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT SUM(quantity) FROM items";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        int totalQuantity = result != DBNull.Value ? Convert.ToInt32(result) : 0;

                        textBox2.Text = totalQuantity.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading total quantity: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadTotalValueForAllItems()
        {
            string connectionString = "server=localhost;uid=root;pwd=root;database=pos";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT SUM(quantity * price) FROM items";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        decimal totalValue = result != DBNull.Value ? Convert.ToDecimal(result) : 0;

                        textBox3.Text = totalValue.ToString("0.00");  // Show 2 decimal places
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading total value: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

    

