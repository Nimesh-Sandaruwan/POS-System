using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Drawing2D; // For LinearGradientBrush


namespace pos_System
{
    public partial class Reporting : Form
    {
        private Size originalSize;
        private Dictionary<Control, Rectangle> originalControlBounds = new Dictionary<Control, Rectangle>();
        private bool isLoaded = false;
        private int currentRow = 0;
        private PrintDocument printDocumentSales = new PrintDocument();
        private PrintDocument printDocumentCashout = new PrintDocument();


        public Reporting()
        {
            InitializeComponent();
            LoadTotalCashOut();
            LoadTotalPayableAmount();
            LoadAveragePercentageOfPayable();

            printDocumentSales.PrintPage += new PrintPageEventHandler(PrintSalesDocument);
            printDocumentCashout.PrintPage += new PrintPageEventHandler(PrintCashoutDocument);

            this.Resize += Form_Resize;
            this.KeyPreview = true;
            this.KeyDown += items_KeyDown;
            dataGridView1.Visible = false;

        }

        private void Reporting_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.Sizable;

            originalSize = this.Size;
            foreach (Control control in this.Controls)
            {
                originalControlBounds[control] = control.Bounds;
            }

            isLoaded = true;
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            if (!isLoaded) return;

            float xRatio = (float)this.Width / originalSize.Width;
            float yRatio = (float)this.Height / originalSize.Height;

            foreach (var pair in originalControlBounds)
            {
                Control control = pair.Key;
                Rectangle originalBounds = pair.Value;

                int newX = (int)(originalBounds.X * xRatio);
                int newY = (int)(originalBounds.Y * yRatio);
                int newWidth = (int)(originalBounds.Width * xRatio);
                int newHeight = (int)(originalBounds.Height * yRatio);

                control.Bounds = new Rectangle(newX, newY, newWidth, newHeight);
            }
        }

        private void items_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new dashbord().Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            new dashbord().Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            new stock().Show();
            this.Hide();
        }

        private void LoadTotalCashOut()
        {
            string connStr = "server=localhost;uid=root;pwd=root;database=pos";
            string query = "SELECT IFNULL(SUM(Amount), 0) FROM cashout";

            try
            {
                using var conn = new MySqlConnection(connStr);
                conn.Open();
                using var cmd = new MySqlCommand(query, conn);
                textBox1.Text = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading total cash out: " + ex.Message);
            }
        }

        private void LoadTotalPayableAmount()
        {
            string connStr = "server=localhost;uid=root;pwd=root;database=pos";
            string query = "SELECT IFNULL(SUM(paybleamount), 0) FROM sales";

            try
            {
                using var conn = new MySqlConnection(connStr);
                conn.Open();
                using var cmd = new MySqlCommand(query, conn);
                textBox3.Text = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading total payable amount: " + ex.Message);
            }
        }

        private void LoadAveragePercentageOfPayable()
        {
            string connStr = "server=localhost;uid=root;pwd=root;database=pos";
            string totalQuery = "SELECT IFNULL(SUM(paybleamount), 0) FROM sales";
            string avgQuery = "SELECT IFNULL(AVG(paybleamount), 0) FROM sales";

            try
            {
                using var conn = new MySqlConnection(connStr);
                conn.Open();

                decimal total = Convert.ToDecimal(new MySqlCommand(totalQuery, conn).ExecuteScalar());
                decimal avg = Convert.ToDecimal(new MySqlCommand(avgQuery, conn).ExecuteScalar());

                decimal percentage = (total > 0) ? (avg / total) * 100 : 0;
                textBox2.Text = percentage.ToString("0.00") + "%";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadSalesData(DateTime startDate, DateTime endDate)
        {
            string connStr = "server=localhost;user=root;password=root;database=pos;";
            string query = @"SELECT bill_no, itemcode, itemname, quantity, paybleamount, payment_date FROM sales WHERE payment_date >= @StartDate AND payment_date < @EndDate";

            using var conn = new MySqlConnection(connStr);
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@StartDate", startDate);
            cmd.Parameters.AddWithValue("@EndDate", endDate.AddDays(1));

            var adapter = new MySqlDataAdapter(cmd);
            var dt = new DataTable();
            adapter.Fill(dt);

            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = dt;
        }

        private void LoadCashoutData(DateTime startDate, DateTime endDate)
        {
            string connStr = "server=localhost;user=root;password=root;database=pos;";
            string query = @"SELECT id, amount, reason, date FROM cashout WHERE date >= @StartDate AND date < @EndDate";

            using var conn = new MySqlConnection(connStr);
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@StartDate", startDate);
            cmd.Parameters.AddWithValue("@EndDate", endDate.AddDays(1));

            var adapter = new MySqlDataAdapter(cmd);
            var dt = new DataTable();
            adapter.Fill(dt);

            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dateTimePicker3.Value.Date;
            DateTime toDate = dateTimePicker1.Value.Date.AddDays(1).AddTicks(-1);

            LoadSalesData(fromDate, toDate);
            Application.DoEvents();

            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No data available to print.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            currentRow = 0;
            printPreviewDialog1.Document = printDocumentSales;
            printPreviewDialog1.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // If you want to do something when textBox1 changes, add logic here.
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // If you want to do something when textBox2 changes, add logic here.
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // If you want to do something when textBox3 changes, add logic here.
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // If label3 is meant to be clickable, you can add code here.
        }







        private void button2_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dateTimePicker4.Value.Date;
            DateTime toDate = dateTimePicker2.Value.Date.AddDays(1).AddTicks(-1);

            LoadCashoutData(fromDate, toDate);
            Application.DoEvents();

            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No data available to print.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            currentRow = 0;
            printPreviewDialog1.Document = printDocumentCashout;
            printPreviewDialog1.ShowDialog();
        }

        private void PrintSalesDocument(object sender, PrintPageEventArgs e)
        {
            PrintReport(e, "දෛනික ආදායම් වාර්තාව - Daily CashBook");
        }

        private void PrintCashoutDocument(object sender, PrintPageEventArgs e)
        {
            PrintReport(e, "මුදල් බැහැරදීම -  Cash Out");
        }

        private void PrintReport(PrintPageEventArgs e, string reportTitle)
        {
            int leftMargin = 10;
            int topMargin = 100;
            int rowHeight = 60;

            Font headerFont = new Font("Arial", 18, FontStyle.Bold); // PDF-friendly font
            Font reportFont = new Font("Arial", 14, FontStyle.Bold);
            Font font = new Font("Arial", 12); // Changed from "Segoe UI"
            Brush brush = Brushes.Black;
            Pen pen = Pens.Black;

            int x = leftMargin;
            int y = topMargin;

            string companyName = "MKB මල්ටි ෂොප් ";

            // --- Draw Company Name ---
            SizeF companyNameSize = e.Graphics.MeasureString(companyName, headerFont);
            float centerX = (e.PageBounds.Width - companyNameSize.Width) / 2;
            e.Graphics.DrawString(companyName, headerFont, brush, new PointF(centerX, y));
            y += rowHeight;

            e.Graphics.DrawLine(pen, centerX, y, centerX + companyNameSize.Width, y);
            y += 10;

            // --- Report Title ---
            SizeF reportTitleSize = e.Graphics.MeasureString(reportTitle, reportFont);
            float reportTitleCenterX = (e.PageBounds.Width - reportTitleSize.Width) / 2;
            e.Graphics.DrawString(reportTitle, reportFont, brush, new PointF(reportTitleCenterX, y));
            y += rowHeight + 10;

            // --- Calculate Scaling ---
            int totalGridWidth = dataGridView1.Columns.Cast<DataGridViewColumn>().Sum(col => col.Width);
            float scale = (float)e.MarginBounds.Width / totalGridWidth;

            List<int> columnWidths = new List<int>();
            int extraWidthForPaymentDate = 120;

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                int baseWidth = (int)(dataGridView1.Columns[i].Width * scale);
                if (dataGridView1.Columns[i].HeaderText.ToLower().Contains("payment date"))
                    baseWidth += extraWidthForPaymentDate;

                columnWidths.Add(baseWidth);
            }

            // --- Draw Headers ---
            x = leftMargin;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                int colWidth = columnWidths[i];
                RectangleF headerRect = new RectangleF(x, y, colWidth, rowHeight);
                e.Graphics.FillRectangle(Brushes.LightGray, headerRect);
                e.Graphics.DrawRectangle(pen, x, y, colWidth, rowHeight);

                StringFormat headerFormat = new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Center,
                    FormatFlags = StringFormatFlags.NoWrap
                };

                e.Graphics.DrawString(dataGridView1.Columns[i].HeaderText, font, brush, headerRect, headerFormat);
                x += colWidth;
            }

            y += rowHeight;

            // --- Draw Rows ---
            for (; currentRow < dataGridView1.Rows.Count; currentRow++)
            {
                var row = dataGridView1.Rows[currentRow];
                if (row.IsNewRow) continue;

                x = leftMargin;

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    int colWidth = columnWidths[i];
                    string cellText = row.Cells[i].Value?.ToString() ?? "";
                    RectangleF cellRect = new RectangleF(x, y, colWidth, rowHeight);

                    StringFormat format = new StringFormat
                    {
                        Alignment = StringAlignment.Near,
                        LineAlignment = StringAlignment.Center,
                        FormatFlags = StringFormatFlags.LineLimit
                    };

                    // Prevent cut-off issues for datetime columns
                    if (dataGridView1.Columns[i].HeaderText.ToLower().Contains("payment date"))
                        format.FormatFlags = 0;

                    e.Graphics.DrawRectangle(pen, x, y, colWidth, rowHeight);
                    e.Graphics.DrawString(cellText, font, brush, cellRect, format);
                    x += colWidth;
                }

                y += rowHeight;

                // --- Page Break Handling ---
                if (y + rowHeight > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    currentRow++;
                    return;
                }
            }

            e.HasMorePages = false;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            new billing().Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}







