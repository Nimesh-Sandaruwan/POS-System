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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing.Printing;
using MySql.Data.MySqlClient;


namespace pos_System
{
    public partial class billing : Form
    {
        private Size originalSize;
        private Dictionary<Control, Rectangle> originalControlBounds = new Dictionary<Control, Rectangle>();
        private bool isLoaded = false;

        string connectionString = "server=localhost;uid=root;pwd=root;database=pos";
        string billNo = ""; // will be set when button4 is clicked
        List<string> itemLines = new List<string>();
        PrintDocument printDoc = new PrintDocument();
        // printDocument1.PrintPage += new PrintPageEventHandler(PrintReceipt);


        string paymentSummary = "";

        public billing()
        {
            InitializeComponent();
            button7.Visible = false;
            printDocument1.PrintPage += new PrintPageEventHandler(PrintReceipt);
            printDoc.DefaultPageSettings.PaperSize = new PaperSize("Custom", 280, 600); // width 80mm, height flexible
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox55.Visible = false;

            button1.KeyDown += MoveToNextControl;
            textBox8.KeyDown += MoveToNextControl;
            textBox9.KeyDown += MoveToNextControl;
            // textBox10.KeyDown += MoveToNextControl;
            //button3.KeyDown += MoveToNextControl;
            button4.KeyDown += MoveToNextControl;

        }


        private void MoveToNextControl(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // avoid beep sound
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void billing_Load(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;uid=root;pwd=root;database=pos";
            string itemCode = textBox3.Text.Trim();

            if (string.IsNullOrEmpty(itemCode))
            {
                textBox1.Clear();  // Price
                textBox5.Clear();  // Item Name
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                SELECT itemname, price
                FROM items
                WHERE TRIM(LOWER(itemcode)) = TRIM(LOWER(@ItemCode))";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ItemCode", itemCode.Trim().ToLower());

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBox1.Text = reader["price"].ToString();
                                textBox5.Text = reader["itemname"].ToString();
                            }
                            else
                            {
                                textBox1.Clear();
                                textBox5.Clear();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // Get values
            string qtyText = textBox4.Text.Trim();
            string priceText = textBox1.Text.Trim();

            if (decimal.TryParse(qtyText, out decimal qty) && decimal.TryParse(priceText, out decimal price))
            {
                decimal total = qty * price;
                textBox6.Text = total.ToString("0.00"); // Show 2 decimal places
            }
            else
            {
                textBox6.Text = "0.00";
            }


            if (!string.IsNullOrEmpty(textBox4.Text))
            {
                button1.Focus(); // Move focus to the button
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string itemCode = textBox3.Text.Trim();
            string itemName = textBox5.Text.Trim();
            string qtyText = textBox4.Text.Trim();
            string price = textBox6.Text.Trim();

            // Validation
            if (string.IsNullOrEmpty(itemCode) || string.IsNullOrEmpty(itemName) ||
                string.IsNullOrEmpty(qtyText) || string.IsNullOrEmpty(price))
            {
                MessageBox.Show("Please fill all fields.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(qtyText, out int qtyToReduce))
            {
                MessageBox.Show("Invalid quantity value.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = "server=localhost;uid=root;pwd=root;database=pos";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // 1. Check item quantity
                    string checkQuery = "SELECT quantity FROM items WHERE itemcode = @ItemCode";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@ItemCode", itemCode);
                        object result = checkCmd.ExecuteScalar();

                        if (result == null)
                        {
                            MessageBox.Show("Item code not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        int currentQty = Convert.ToInt32(result);
                        if (currentQty < qtyToReduce)
                        {
                            MessageBox.Show("Not enough stock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // 2. Reduce quantity in `items`
                        string updateQuery = "UPDATE items SET quantity = quantity - @QtyToReduce WHERE itemcode = @ItemCode";
                        using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn))
                        {
                            updateCmd.Parameters.AddWithValue("@QtyToReduce", qtyToReduce);
                            updateCmd.Parameters.AddWithValue("@ItemCode", itemCode);
                            updateCmd.ExecuteNonQuery();
                        }

                        // 3. Add row to DataGridView
                        dataGridView1.Rows.Add(itemCode, itemName, qtyText, price);

                        // 4. Insert into `reciveditems`
                        string insertQuery = "INSERT INTO reciveditems (itemcode, quantity, price) VALUES (@ItemCode, @Quantity, @Price)";
                        using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@ItemCode", itemCode);
                            insertCmd.Parameters.AddWithValue("@Quantity", qtyToReduce);
                            insertCmd.Parameters.AddWithValue("@Price", price);
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 5. Update total
            CalculateTotalPrice();

            // 6. Clear inputs
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }




        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string connectionString = "server=localhost;uid=root;pwd=root;database=pos";

                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    if (row.IsNewRow) continue;

                    string itemCode = row.Cells[0].Value?.ToString(); // Item Code
                    string qtyText = row.Cells[2].Value?.ToString();  // Qty
                    string priceText = row.Cells[3].Value?.ToString(); // Price

                    if (string.IsNullOrEmpty(itemCode) ||
                        !int.TryParse(qtyText, out int qtyToRestore) ||
                        !decimal.TryParse(priceText, out decimal price))
                        continue;

                    try
                    {
                        using (MySqlConnection conn = new MySqlConnection(connectionString))
                        {
                            conn.Open();

                            // 1. Restore stock
                            string updateQuery = "UPDATE items SET quantity = quantity + @Qty WHERE itemcode = @ItemCode";
                            using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@Qty", qtyToRestore);
                                cmd.Parameters.AddWithValue("@ItemCode", itemCode);
                                cmd.ExecuteNonQuery();
                            }

                            // 2. Delete from receiveditems
                            string deleteQuery = "DELETE FROM reciveditems WHERE itemcode = @ItemCode AND quantity = @Qty AND price = @Price LIMIT 1";
                            using (MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, conn))
                            {
                                deleteCmd.Parameters.AddWithValue("@ItemCode", itemCode);
                                deleteCmd.Parameters.AddWithValue("@Qty", qtyToRestore);
                                deleteCmd.Parameters.AddWithValue("@Price", price);
                                deleteCmd.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating database: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 3. Remove from DataGridView
                    dataGridView1.Rows.Remove(row);
                }

                // 4. Update total
                CalculateTotalPrice();
            }
            else
            {
                MessageBox.Show("Please select a row to remove.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void CalculateTotalPrice()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                string priceText = row.Cells[3].Value?.ToString(); // Column 3 = Price

                if (decimal.TryParse(priceText, out decimal price))
                {
                    total += price;
                }
            }

            textBox7.Text = total.ToString("0.00"); // Show 2 decimal places
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBox7.Text, out decimal total) &&
        decimal.TryParse(textBox8.Text, out decimal discountPercent))
            {
                decimal discountAmount = total * (discountPercent / 100);
                decimal payable = total - discountAmount;
                textBox9.Text = payable.ToString("0.00");
            }
            else
            {
                textBox9.Text = "0.00";
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBox9.Text, out decimal payable) &&
        decimal.TryParse(textBox10.Text, out decimal received))
            {
                decimal balance = received - payable;
                textBox11.Text = balance.ToString("0.00");
            }
            else
            {
                textBox11.Text = "0.00";
            }
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button3.Focus(); // Move focus only when user presses Enter
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Step 1: Generate Bill Number
            string billNo = GenerateNextBillNo();

            // Step 2: Read form inputs
            string total = textBox7.Text.Trim();
            string discount = textBox8.Text.Trim();
            string payable = textBox9.Text.Trim();
            string received = textBox10.Text.Trim();
            string balance = textBox11.Text.Trim();
            DateTime paymentDate = dateTimePicker1.Value;

            // Basic validation (you can improve this)
            if (string.IsNullOrEmpty(total) || string.IsNullOrEmpty(discount) ||
                string.IsNullOrEmpty(payable) || string.IsNullOrEmpty(received) ||
                string.IsNullOrEmpty(balance))
            {
                MessageBox.Show("Please fill all payment fields.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = "server=localhost;uid=root;pwd=root;database=pos";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string insertQuery = @"INSERT INTO payment 
                (bill_no, total, discount, paybleamount, receivedamount, balance, payment_date)
                VALUES 
                (@BillNo, @Total, @Discount, @Payable, @Received, @Balance, @Date)";

                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@BillNo", billNo);
                        cmd.Parameters.AddWithValue("@Total", total);
                        cmd.Parameters.AddWithValue("@Discount", discount);
                        cmd.Parameters.AddWithValue("@Payable", payable);
                        cmd.Parameters.AddWithValue("@Received", received);
                        cmd.Parameters.AddWithValue("@Balance", balance);
                        cmd.Parameters.AddWithValue("@Date", paymentDate);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Payment recorded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string GenerateNextBillNo()
        {
            string connectionString = "server=localhost;uid=root;pwd=root;database=pos";
            string latestBillNo = "";
            int nextNumber = 1;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT bill_no FROM payment ORDER BY id DESC LIMIT 1";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        latestBillNo = result.ToString(); // e.g., POS007
                        string numberPart = latestBillNo.Substring(3); // "007"
                        if (int.TryParse(numberPart, out int lastNumber))
                        {
                            nextNumber = lastNumber + 1;
                        }
                    }
                }
            }

            return "POS" + nextNumber.ToString("D3"); // D3 = 3 digits with leading zeros
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Loop through all controls in the form
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is System.Windows.Forms.TextBox)
                {
                    ((System.Windows.Forms.TextBox)ctrl).Clear();
                }
            }

            // If you have TextBoxes inside other containers (like GroupBox or Panel), use recursion:
            ClearTextBoxesRecursive(this);

            // Optional: Reset date picker
            dateTimePicker1.Value = DateTime.Now;
        }
        private void ClearTextBoxesRecursive(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is System.Windows.Forms.TextBox)
                {
                    ((System.Windows.Forms.TextBox)ctrl).Clear();
                }
                else if (ctrl.HasChildren)
                {
                    ClearTextBoxesRecursive(ctrl);
                }
            }
        }














        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            float y = 20;
            Font font = new Font("Arial", 10);
            Font headerFont = new Font("Arial", 14, FontStyle.Bold);

            e.Graphics.DrawString("MKB SUPERMARKET", headerFont, Brushes.Black, new PointF(80, y));
            y += 40;
            e.Graphics.DrawString("PAYMENT SLIP", headerFont, Brushes.Black, new PointF(110, y));
            y += 40;

            e.Graphics.DrawString("Bill No: " + billNo, font, Brushes.Black, new PointF(20, y));
            y += 25;

            // Draw Items
            e.Graphics.DrawString("ItemCode    Qty    Price", font, Brushes.Black, new PointF(20, y));
            y += 20;
            foreach (string line in itemLines)
            {
                e.Graphics.DrawString(line, font, Brushes.Black, new PointF(20, y));
                y += 20;
            }

            y += 20;
            e.Graphics.DrawString("--------", font, Brushes.Black, new PointF(20, y));
            y += 25;

            // Payment Summary
            e.Graphics.DrawString(paymentSummary, font, Brushes.Black, new PointF(20, y));
        }

        private void ConfigurePrintDocument()
        {
            // 80mm width ≈ 3.15 inches → 3.15 * 100 = 315 hundredths of inch
            int width = 315;
            int height = 800;  // fixed height, can be increased if needed

            PaperSize paperSize = new PaperSize("Custom", width, height);
            printDocument1.DefaultPageSettings.PaperSize = paperSize;

            // Set small margins typical for receipts
            printDocument1.DefaultPageSettings.Margins = new Margins(5, 5, 5, 5);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ConfigurePrintDocument();
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void PrintReceipt(object sender, PrintPageEventArgs e)
        {
            Font headerFont = new Font("Consolas", 10, FontStyle.Bold);
            Font bodyFont = new Font("Consolas", 9);
            float yPos = 10;
            int leftMargin = 10;
            int pageWidth = e.PageBounds.Width;

            string billNo = textBox55.Text;
            string connStr = "server=localhost;user=root;password=root;database=pos;";
            string query = @"SELECT itemname, quantity, price, total, discount, 
                     paybleamount, receivedamount, balance, payment_date 
                     FROM sales WHERE bill_no = @billNo";

            using var conn = new MySqlConnection(connStr);
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@billNo", billNo);
            conn.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();

            // --- CENTERED HEADER ---
            string title = "MKB සුපර් මාකට් ";
            SizeF titleSize = e.Graphics.MeasureString(title, headerFont);
            float titleX = (pageWidth - titleSize.Width) / 2;
            e.Graphics.DrawString(title, headerFont, Brushes.Black, titleX, yPos);
            yPos += 25;

            string subTitle = "BILL RECEIPT - බිල්පත";
            SizeF subTitleSize = e.Graphics.MeasureString(subTitle, bodyFont);
            float subTitleX = (pageWidth - subTitleSize.Width) / 2;
            e.Graphics.DrawString(subTitle, bodyFont, Brushes.Black, subTitleX, yPos);
            yPos += 20;

            e.Graphics.DrawString($"Bill No: {billNo}", bodyFont, Brushes.Black, leftMargin, yPos);
            yPos += 20;
            e.Graphics.DrawString("========================================", bodyFont, Brushes.Black, leftMargin, yPos);
            yPos += 20;
            e.Graphics.DrawString("Item             Qty   Price    Total", bodyFont, Brushes.Black, leftMargin, yPos);
            yPos += 20;
            e.Graphics.DrawString("----------------------------------------", bodyFont, Brushes.Black, leftMargin, yPos);
            yPos += 20;

            decimal total = 0, discount = 0, payble = 0, received = 0, balance = 0;
            DateTime paymentDate = DateTime.Now;
            bool firstRow = true;

            while (reader.Read())
            {
                if (firstRow)
                {
                    paymentDate = Convert.ToDateTime(reader["payment_date"]);
                    discount = Convert.ToDecimal(reader["discount"]);
                    payble = Convert.ToDecimal(reader["paybleamount"]);
                    received = Convert.ToDecimal(reader["receivedamount"]);
                    balance = Convert.ToDecimal(reader["balance"]);
                    total = Convert.ToDecimal(reader["total"]); // Get total from DB
                    firstRow = false;
                }

                string item = reader["itemname"].ToString();
                string qty = reader["quantity"].ToString();
                string price = Convert.ToDecimal(reader["price"]).ToString("F2");
                string totalItem = Convert.ToDecimal(reader["total"]).ToString("F2");

                // Make sure item name fits 15 chars
                string itemName = item.Length > 15 ? item.Substring(0, 15) : item.PadRight(15);
                string line = $"{itemName} {qty.PadLeft(3)} {price.PadLeft(7)} {totalItem.PadLeft(8)}";
                e.Graphics.DrawString(line, bodyFont, Brushes.Black, leftMargin, yPos);
                yPos += 20;
            }

            // Summary
            e.Graphics.DrawString("----------------------------------------", bodyFont, Brushes.Black, leftMargin, yPos);
            yPos += 20;
            e.Graphics.DrawString($"දිනය                 : {paymentDate:yyyy-MM-dd HH:mm}", bodyFont, Brushes.Black, leftMargin, yPos);
            yPos += 20;
            e.Graphics.DrawString($"මුලු මුදල              : Rs. {total:F2}", bodyFont, Brushes.Black, leftMargin, yPos);
            yPos += 20;
            e.Graphics.DrawString($"වට්ටම                :  {discount}%", bodyFont, Brushes.Black, leftMargin, yPos);
            yPos += 20;
            e.Graphics.DrawString($"ගෙවිය යුතු මුදල       : Rs. {payble:F2}", bodyFont, Brushes.Black, leftMargin, yPos);
            yPos += 20;
            e.Graphics.DrawString($"ලැබුණු මුදල           : Rs. {received:F2}", bodyFont, Brushes.Black, leftMargin, yPos);
            yPos += 20;
            e.Graphics.DrawString($"ශේෂය                : Rs. {balance:F2}", bodyFont, Brushes.Black, leftMargin, yPos);
            yPos += 30;

            // --- CENTERED FOOTER ---
            string thanks1 = "ස්තූතියි නැවත පැමිණෙන්න ";
            SizeF thanks1Size = e.Graphics.MeasureString(thanks1, bodyFont);
            float thanks1X = (pageWidth - thanks1Size.Width) / 2;
            e.Graphics.DrawString(thanks1, bodyFont, Brushes.Black, thanks1X, yPos);
            yPos += 20;

            string thanks2 = "Visit Again!";
            SizeF thanks2Size = e.Graphics.MeasureString(thanks2, bodyFont);
            float thanks2X = (pageWidth - thanks2Size.Width) / 2;
            e.Graphics.DrawString(thanks2, bodyFont, Brushes.Black, thanks2X, yPos);
        }







        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;uid=root;pwd=root;database=pos";

            string total = textBox7.Text.Trim();
            string discount = textBox8.Text.Trim();
            string payble = textBox9.Text.Trim();
            string received = textBox10.Text.Trim();
            string balance = textBox11.Text.Trim();
            DateTime paymentDate = dateTimePicker1.Value;

            string newBillNo = GenerateNewBillNo(); // Generate Bill No

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Insert Each Item
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.IsNewRow) continue;

                            string itemCode = row.Cells[0].Value.ToString();
                            string itemName = row.Cells[1].Value.ToString();
                            string qty = row.Cells[2].Value.ToString();
                            string price = row.Cells[3].Value.ToString();

                            string insertItemQuery = @"INSERT INTO sales 
                        (bill_no, itemcode, itemname, quantity, price, total, discount, paybleamount, receivedamount, balance, payment_date)
                        VALUES 
                        (@billNo, @itemCode, @itemName, @qty, @price, @total, @discount, @payble, @received, @balance, @paymentDate)";

                            using (MySqlCommand cmd = new MySqlCommand(insertItemQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@billNo", newBillNo);
                                cmd.Parameters.AddWithValue("@itemCode", itemCode);
                                cmd.Parameters.AddWithValue("@itemName", itemName);
                                cmd.Parameters.AddWithValue("@qty", qty);
                                cmd.Parameters.AddWithValue("@price", price);
                                cmd.Parameters.AddWithValue("@total", total);
                                cmd.Parameters.AddWithValue("@discount", discount);
                                cmd.Parameters.AddWithValue("@payble", payble);
                                cmd.Parameters.AddWithValue("@received", received);
                                cmd.Parameters.AddWithValue("@balance", balance);
                                cmd.Parameters.AddWithValue("@paymentDate", paymentDate);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();

                        // ✅ Show bill number in TextBox55
                        textBox55.Text = newBillNo;

                        MessageBox.Show("Bill saved successfully!\nBill No: " + newBillNo, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error saving bill: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private string GenerateNewBillNo()
        {
            string connectionString = "server=localhost;uid=root;pwd=root;database=pos";
            string lastBillNo = "";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT bill_no FROM sales ORDER BY id DESC LIMIT 1";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        lastBillNo = result.ToString();
                        int number = int.Parse(lastBillNo.Substring(3));
                        return "POS" + (number + 1).ToString("D3");
                    }
                    else
                    {
                        return "POS001";
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            // string itemCode = textBox12.Text.Trim();
            //
            // if (!string.IsNullOrEmpty(itemCode))
            // {
            //     // Fetch details from DB using scanned barcode (itemCode)
            //     FillItemDetails(itemCode);
            // }
        }


        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            // if (e.KeyCode == Keys.Enter)
            {
                // FillItemDetailsFromBarcode(textBox12.Text.Trim());
            }
        }



        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FillItemDetailsFromBarcode(textBox3.Text.Trim());
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void FillItemDetailsFromBarcode(string barcodeText)
        {
            string[] parts = barcodeText.Split('-');

            if (parts.Length != 3)
            {
                MessageBox.Show("Invalid item code format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string itemCode = parts[0];
            string itemName = parts[1];
            string price = parts[2];

            textBox3.Text = itemCode;
            textBox5.Text = itemName;
            textBox1.Text = price;

        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick(); // Simulate button click
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            //button3.Focus(); // Move focus to the button

        }



        private void button3_KeyDown_1(object sender, KeyEventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {


        }

        private void button3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button3.PerformClick(); // Simulate button click
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}

            
        

    





