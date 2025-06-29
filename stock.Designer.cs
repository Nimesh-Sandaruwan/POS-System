namespace pos_System
{
    partial class stock
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(stock));
            panel1 = new Panel();
            panel5 = new Panel();
            label12 = new Label();
            dataGridView1 = new DataGridView();
            button1 = new Button();
            comboBox1 = new ComboBox();
            label5 = new Label();
            panel4 = new Panel();
            label8 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            panel3 = new Panel();
            textBox2 = new TextBox();
            label3 = new Label();
            panel2 = new Panel();
            textBox1 = new TextBox();
            label2 = new Label();
            nav = new Panel();
            pictureBox5 = new PictureBox();
            pictureBox6 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            nav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.Peru;
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(nav);
            panel1.Location = new Point(-5, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1386, 779);
            panel1.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Maroon;
            panel5.Controls.Add(label12);
            panel5.Location = new Point(-4, 696);
            panel5.Name = "panel5";
            panel5.Size = new Size(1390, 52);
            panel5.TabIndex = 29;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 6.75F);
            label12.Location = new Point(12, 2);
            label12.Name = "label12";
            label12.Size = new Size(74, 12);
            label12.TabIndex = 29;
            label12.Text = "POS System 1.0.1";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(471, 334);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(747, 207);
            dataGridView1.TabIndex = 28;
            // 
            // button1
            // 
            button1.Font = new Font("Nirmala UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(740, 244);
            button1.Name = "button1";
            button1.Size = new Size(79, 32);
            button1.TabIndex = 27;
            button1.Text = "💻View";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Nirmala UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Fruits & Vegetables", "Grocery / Food Items", "Dinks", "Snacks", "Milk Products", "Frozen Foods", "Household Items", "Stationery" });
            comboBox1.Location = new Point(495, 247);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(208, 29);
            comboBox1.TabIndex = 26;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Nirmala UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(394, 246);
            label5.Name = "label5";
            label5.Size = new Size(98, 25);
            label5.TabIndex = 25;
            label5.Text = "Category :";
            // 
            // panel4
            // 
            panel4.BackColor = Color.Red;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(label8);
            panel4.Controls.Add(textBox3);
            panel4.Controls.Add(label4);
            panel4.Cursor = Cursors.Hand;
            panel4.Location = new Point(49, 499);
            panel4.Name = "panel4";
            panel4.Size = new Size(212, 124);
            panel4.TabIndex = 24;
            panel4.Paint += panel4_Paint;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Nirmala UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(16, 54);
            label8.Name = "label8";
            label8.Size = new Size(37, 25);
            label8.TabIndex = 31;
            label8.Text = "Rs.";
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.Red;
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Font = new Font("Nirmala UI", 14.25F, FontStyle.Bold);
            textBox3.Location = new Point(53, 51);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(142, 26);
            textBox3.TabIndex = 28;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Nirmala UI", 14.25F, FontStyle.Bold);
            label4.Location = new Point(82, 16);
            label4.Name = "label4";
            label4.Size = new Size(56, 25);
            label4.TabIndex = 27;
            label4.Text = "Price";
            // 
            // panel3
            // 
            panel3.BackColor = Color.Lime;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(textBox2);
            panel3.Controls.Add(label3);
            panel3.Cursor = Cursors.Hand;
            panel3.Location = new Point(49, 312);
            panel3.Name = "panel3";
            panel3.Size = new Size(212, 124);
            panel3.TabIndex = 24;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.Lime;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Nirmala UI", 14.25F, FontStyle.Bold);
            textBox2.Location = new Point(92, 54);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 26);
            textBox2.TabIndex = 27;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Nirmala UI", 14.25F, FontStyle.Bold);
            label3.Location = new Point(68, 16);
            label3.Name = "label3";
            label3.Size = new Size(89, 25);
            label3.TabIndex = 26;
            label3.Text = "Quantity";
            // 
            // panel2
            // 
            panel2.BackColor = Color.DeepPink;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(label2);
            panel2.Cursor = Cursors.Hand;
            panel2.Location = new Point(49, 123);
            panel2.Name = "panel2";
            panel2.Size = new Size(212, 124);
            panel2.TabIndex = 23;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.DeepPink;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Nirmala UI", 14.25F, FontStyle.Bold);
            textBox1.Location = new Point(83, 54);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(111, 26);
            textBox1.TabIndex = 26;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Nirmala UI", 14.25F, FontStyle.Bold);
            label2.Location = new Point(49, 16);
            label2.Name = "label2";
            label2.Size = new Size(112, 25);
            label2.TabIndex = 25;
            label2.Text = "Item Count";
            // 
            // nav
            // 
            nav.BackColor = Color.Maroon;
            nav.BorderStyle = BorderStyle.FixedSingle;
            nav.Controls.Add(pictureBox5);
            nav.Controls.Add(pictureBox6);
            nav.Controls.Add(pictureBox4);
            nav.Controls.Add(pictureBox3);
            nav.Controls.Add(pictureBox1);
            nav.Controls.Add(label1);
            nav.Dock = DockStyle.Top;
            nav.Location = new Point(0, 0);
            nav.Name = "nav";
            nav.Size = new Size(1386, 52);
            nav.TabIndex = 22;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(1308, 11);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(39, 30);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 25;
            pictureBox5.TabStop = false;
            pictureBox5.Click += pictureBox5_Click;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(1196, 11);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(39, 30);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 26;
            pictureBox6.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(1250, 11);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(39, 30);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 24;
            pictureBox4.TabStop = false;
            pictureBox4.Click += pictureBox4_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(1140, 11);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(39, 30);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 24;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(29, 10);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(39, 30);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 23;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Adobe Gothic Std B", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(86, 12);
            label1.Name = "label1";
            label1.Size = new Size(73, 30);
            label1.TabIndex = 6;
            label1.Text = "Stock";
            // 
            // stock
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 749);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "stock";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "stock";
            Load += stock_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            nav.ResumeLayout(false);
            nav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel nav;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private PictureBox pictureBox1;
        private Label label1;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private Label label5;
        private DataGridView dataGridView1;
        private Button button1;
        private Label label8;
        private Panel panel5;
        private Label label12;
    }
}