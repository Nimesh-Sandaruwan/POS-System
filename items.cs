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
using ZXing;
using ZXing.Common;
using ZXing.Rendering;     // 🔁 Needed for BitmapRenderer
using System.Drawing;
using System.Drawing.Imaging;
using ZXing.Windows.Compatibility;
using BarcodeStandard;
using BarcodeLib;



namespace pos_System
{
    public partial class items : Form
    {
        private Size originalSize;
        private Dictionary<Control, Rectangle> originalControlBounds = new Dictionary<Control, Rectangle>();
        private bool isLoaded = false;
        string connectionString = "server=localhost;uid=root;pwd=root;database=pos";

        public items()
        {
            InitializeComponent();
            LoadItemData();
            dataGridView1.CellClick += dataGridView1_CellClick; // Wire up the event
            button2.Visible = false;

            // Attach resize event
            this.Resize += Form_Resize;

            // Allow key events
            this.KeyPreview = true;
            this.KeyDown += items_KeyDown;


            itemtxt.KeyDown += MoveToNextControl;
            itemcodetxt.KeyDown += MoveToNextControl;
            quantitytxt.KeyDown += MoveToNextControl;
            catagarytxt.KeyDown += MoveToNextControl;
            pricetxt.KeyDown += MoveToNextControl;
            datetxt.KeyDown += MoveToNextControl;

        }


        private void MoveToNextControl(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // avoid beep sound
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }


        private void items_Load(object sender, EventArgs e)
        {
            // Set the form to full screen
            this.WindowState = FormWindowState.Maximized;

            // Set border style
            this.FormBorderStyle = FormBorderStyle.Sizable; // Add a border with resize option.

            // Save original size and positions of controls
            originalSize = this.Size;
            foreach (Control control in this.Controls)
            {
                originalControlBounds[control] = control.Bounds;
            }

            isLoaded = true;
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            if (!isLoaded || originalSize.Width == 0 || originalSize.Height == 0)
                return;

            // If the window is in normal (restore down) mode, use the normal size
            if (this.WindowState == FormWindowState.Normal)
            {
                float widthRatio = (float)this.Width / originalSize.Width;
                float heightRatio = (float)this.Height / originalSize.Height;

                foreach (var kvp in originalControlBounds)
                {
                    ResizeControl(kvp.Key, kvp.Value, widthRatio, heightRatio);
                }
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                // If the window is maximized, scale to the new size
                float widthRatio = (float)this.Width / originalSize.Width;
                float heightRatio = (float)this.Height / originalSize.Height;

                foreach (var kvp in originalControlBounds)
                {
                    ResizeControl(kvp.Key, kvp.Value, widthRatio, heightRatio);
                }
            }
        }

        private void ResizeControl(Control control, Rectangle originalBounds, float widthRatio, float heightRatio)
        {
            int newX = (int)(originalBounds.X * widthRatio);
            int newY = (int)(originalBounds.Y * heightRatio);
            int newWidth = (int)(originalBounds.Width * widthRatio);
            int newHeight = (int)(originalBounds.Height * heightRatio);

            control.Bounds = new Rectangle(newX, newY, newWidth, newHeight);

            // Adjust font size based on resizing
            float newFontSize = control.Font.Size * Math.Min(widthRatio, heightRatio);

            // Safe font resize
            if (newFontSize >= 6 && newFontSize < float.MaxValue &&
                !float.IsInfinity(newFontSize) && !float.IsNaN(newFontSize))
            {
                control.Font = new Font(control.Font.FontFamily, newFontSize);
            }
        }

        private void items_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        // Event handlers (optional)
        private void textBox4_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Reporting reporting = new Reporting();
            reporting.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            stock stock = new stock();
            stock.Show();
            this.Hide();
        }






        private void LoadItemData()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"
                SELECT 
                    itemcode,
                    itemname,
                    quantity,
                    catagary, -- make sure the column name is correct
                    price,
                    date
                FROM items"; // Make sure this is the correct table name

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Check if rows are loaded
                        if (dt.Rows.Count > 0)
                        {
                            dataGridView1.DataSource = dt;
                            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Optional for better appearance
                        }
                        else
                        {
                            MessageBox.Show("No data found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;uid=root;pwd=root;database=pos";

            string ItemName = itemtxt.Text.Trim();
            string ItemCode = itemcodetxt.Text.Trim();
            string Quantity = quantitytxt.Text.Trim();
            string Catagary = catagarytxt.Text.Trim();
            string Price = pricetxt.Text.Trim();
            string Date = datetxt.Text.Trim();

            // Validate required fields
            if (string.IsNullOrEmpty(ItemName) || string.IsNullOrEmpty(ItemCode) || string.IsNullOrEmpty(Quantity)
                || string.IsNullOrEmpty(Catagary) || string.IsNullOrEmpty(Price) || string.IsNullOrEmpty(Date))
            {
                MessageBox.Show("Please Fill All Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check Catagary length
            if (Catagary.Length > 50)
            {
                MessageBox.Show("Catagary is too long. Max 50 characters allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate date format
            if (!DateTime.TryParse(Date, out DateTime parsedDate))
            {
                MessageBox.Show("Invalid date format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string formattedDate = parsedDate.ToString("yyyy-MM-dd");

            // Validate barcode image
            if (pictureBoxBarcode.Image == null)
            {
                MessageBox.Show("Please generate the barcode before saving.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Convert barcode image to byte array
            byte[] barcodeImageBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                pictureBoxBarcode.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                barcodeImageBytes = ms.ToArray();
            }

            // Insert into database
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"INSERT INTO items 
                (itemname, itemcode, quantity, catagary, price, date, barcodepath)
                VALUES 
                (@ItemName, @ItemCode, @Quantity, @Catagary, @Price, @Date, @barcodepath)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ItemName", ItemName);
                        cmd.Parameters.AddWithValue("@ItemCode", ItemCode);
                        cmd.Parameters.AddWithValue("@Quantity", Quantity);
                        cmd.Parameters.AddWithValue("@Catagary", Catagary);
                        cmd.Parameters.AddWithValue("@Price", Price);
                        cmd.Parameters.AddWithValue("@Date", formattedDate);
                        cmd.Parameters.AddWithValue("@barcodepath", barcodeImageBytes);  // ✅ Use binary array

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            MessageBox.Show("Save Successful (with Barcode)!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Save Failed! Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                MessageBox.Show("Duplicate entry detected. Please use different values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Refresh the UI
            LoadItemData();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0) // make sure a row is selected, not the header
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                itemcodetxt.Text = row.Cells["itemcode"].Value?.ToString();
                itemtxt.Text = row.Cells["itemname"].Value?.ToString();
                quantitytxt.Text = row.Cells["quantity"].Value?.ToString();
                catagarytxt.Text = row.Cells["catagary"].Value?.ToString(); // match column name
                pricetxt.Text = row.Cells["price"].Value?.ToString();
                datetxt.Text = row.Cells["date"].Value?.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;uid=root;pwd=root;database=pos";

            string ItemName = itemtxt.Text.Trim();
            string ItemCode = itemcodetxt.Text.Trim();
            string Quantity = quantitytxt.Text.Trim();
            string Catagary = catagarytxt.Text.Trim();
            string Price = pricetxt.Text.Trim();
            string Date = datetxt.Text.Trim();

            // Validate fields
            if (string.IsNullOrEmpty(ItemName) || string.IsNullOrEmpty(ItemCode) || string.IsNullOrEmpty(Quantity)
                || string.IsNullOrEmpty(Catagary) || string.IsNullOrEmpty(Price) || string.IsNullOrEmpty(Date))
            {
                MessageBox.Show("Please Fill All Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Catagary.Length > 50)
            {
                MessageBox.Show("Catagary is too long. Max 50 characters allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!DateTime.TryParse(Date, out DateTime parsedDate))
            {
                MessageBox.Show("Invalid date format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string formattedDate = parsedDate.ToString("yyyy-MM-dd");

            // Convert barcode image if exists
            byte[] barcodeImageBytes = null;
            if (pictureBoxBarcode.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBoxBarcode.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    barcodeImageBytes = ms.ToArray();
                }
            }

            // Update database
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
            UPDATE items SET 
                itemname = @ItemName,
                quantity = @Quantity,
                catagary = @Catagary,
                price = @Price,
                date = @Date,
                barcodepath = @barcodepath
            WHERE itemcode = @ItemCode"; // ItemCode used as unique key

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ItemName", ItemName);
                        cmd.Parameters.AddWithValue("@ItemCode", ItemCode);
                        cmd.Parameters.AddWithValue("@Quantity", Quantity);
                        cmd.Parameters.AddWithValue("@Catagary", Catagary);
                        cmd.Parameters.AddWithValue("@Price", Price);
                        cmd.Parameters.AddWithValue("@Date", formattedDate);
                        cmd.Parameters.AddWithValue("@barcodepath", barcodeImageBytes ?? new byte[0]);  // empty if no image

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            MessageBox.Show("Update Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("No records were updated. Check the Item Code.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadItemData(); // Refresh UI
        }






        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    string itemCode = itemcodetxt.Text.Trim();

                    // Confirm before deleting
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this item and its related records?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // Delete related records in receiveditems first
                        string deleteReceivedItems = "DELETE FROM receiveditems WHERE itemcode = @itemcode";
                        using (MySqlCommand cmd1 = new MySqlCommand(deleteReceivedItems, con))
                        {
                            cmd1.Parameters.AddWithValue("@itemcode", itemCode);
                            cmd1.ExecuteNonQuery();
                        }

                        // Then delete the item
                        string deleteItem = "DELETE FROM items WHERE itemcode = @itemcode";
                        using (MySqlCommand cmd2 = new MySqlCommand(deleteItem, con))
                        {
                            cmd2.Parameters.AddWithValue("@itemcode", itemCode);
                            int rowsAffected = cmd2.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Item and related records deleted successfully.");
                                LoadItemData(); // Refresh the grid or data view
                            }
                            else
                            {
                                MessageBox.Show("Delete failed. Item not found.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            itemcodetxt.Clear();      // Item Code TextBox එක හිස් කරන්න
            itemtxt.Clear();          // Item Name TextBox එක හිස් කරන්න
            quantitytxt.Clear();      // Quantity TextBox එක හිස් කරන්න
            catagarytxt.SelectedIndex = -1;
            pricetxt.Clear();         // Price TextBox එක හිස් කරන්න
            datetxt.Value = DateTime.Now;  // Date එක නැවත අද දිනයට set කරන්න
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;uid=root;pwd=root;database=pos";

            // Input values
            string amountText = textBox1.Text.Trim();
            string reason = textBox2.Text.Trim();
            DateTime date = dateTimePicker1.Value;

            // Validation
            if (string.IsNullOrEmpty(amountText) || string.IsNullOrEmpty(reason))
            {
                MessageBox.Show("Please fill all fields.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(amountText, out decimal amount))
            {
                MessageBox.Show("Invalid amount entered.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "INSERT INTO cashout (amount, reason, date) VALUES (@amount, @reason, @date)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@amount", amount);
                        cmd.Parameters.AddWithValue("@reason", reason);
                        cmd.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Cash out entry saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear fields
                textBox1.Clear();
                textBox2.Clear();
                dateTimePicker1.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving to database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            dateTimePicker1.Value = DateTime.Now; // Reset to current date
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string itemCode = itemcodetxt.Text.Trim();
            string itemName = itemtxt.Text.Trim();

            string itemPrice = pricetxt.Text.Trim();

            if (string.IsNullOrEmpty(itemName) || string.IsNullOrEmpty(itemCode) || string.IsNullOrEmpty(itemPrice))
            {
                MessageBox.Show("Please enter Item Name, Item Code, and Price.");
                return;
            }

            // ✅ Short barcode-friendly text
            string barcodeText = $"{itemCode}-{itemName}-{itemPrice}"; // e.g  itemCode

            // Create barcode writer
            BarcodeWriter<Bitmap> writer = new BarcodeWriter<Bitmap>
            {
                Format = BarcodeFormat.CODE_128,
                Options = new EncodingOptions
                {
                    Width = 250,
                    Height = 80,
                    Margin = 2
                },
                Renderer = new BitmapRenderer()
            };

            Bitmap barcodeBitmap = writer.Write(barcodeText);

            // Create image with text below barcode
            int totalHeight = barcodeBitmap.Height + 30;
            Bitmap finalImage = new Bitmap(barcodeBitmap.Width, totalHeight);

            using (Graphics g = Graphics.FromImage(finalImage))
            {
                g.Clear(Color.White);
                g.DrawImage(barcodeBitmap, new Point(0, 0));

                Font font = new Font("Arial", 10);
                Brush brush = Brushes.Black;
                StringFormat center = new StringFormat { Alignment = StringAlignment.Center };

                // g.DrawString(barcodeText, font, brush,
                //  new RectangleF(0, barcodeBitmap.Height + 5, barcodeBitmap.Width, 25), center);
            }

            // Show in picture box
            pictureBoxBarcode.Image = finalImage;

            // Save barcode image
            string safeFileName = itemName.Replace(" ", "_") + "_" + itemCode;
            string path = Path.Combine("F:\\POS system\\pos System\\Barcodes", $"{safeFileName}.png");
            Directory.CreateDirectory("F:\\POS system\\pos System\\Barcodes");
            finalImage.Save(path, ImageFormat.Png);

            MessageBox.Show("Barcode with Item Name, Code & Price generated and saved!");

        }

        private void pictureBoxBarcode_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            billing billing = new billing();
            billing.Show();
            this.Hide();
        }

    }
}





    