namespace pos_System
{
    partial class frmlogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmlogin));
            label6 = new Label();
            label5 = new Label();
            button2 = new Button();
            button1 = new Button();
            checkshopassword = new CheckBox();
            txtpassword = new TextBox();
            label3 = new Label();
            txtusername = new TextBox();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Cursor = Cursors.Hand;
            label6.Font = new Font("Nirmala UI", 9F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(116, 86, 174);
            label6.Location = new Point(147, 428);
            label6.Name = "label6";
            label6.Size = new Size(107, 15);
            label6.TabIndex = 4;
            label6.Text = "Back to REGISTER";
            label6.Click += label6_Click_1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(147, 402);
            label5.Name = "label5";
            label5.Size = new Size(121, 15);
            label5.TabIndex = 23;
            label5.Text = "Not Have an Account";
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.Cursor = Cursors.Hand;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.FromArgb(116, 86, 174);
            button2.Location = new Point(98, 348);
            button2.Name = "button2";
            button2.Size = new Size(216, 35);
            button2.TabIndex = 3;
            button2.Text = "CLEAR";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_1;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(116, 86, 174);
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(98, 307);
            button1.Name = "button1";
            button1.Size = new Size(216, 35);
            button1.TabIndex = 2;
            button1.Text = "LOGIN";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // checkshopassword
            // 
            checkshopassword.AutoSize = true;
            checkshopassword.Cursor = Cursors.Hand;
            checkshopassword.FlatStyle = FlatStyle.Flat;
            checkshopassword.Location = new Point(195, 272);
            checkshopassword.Name = "checkshopassword";
            checkshopassword.Size = new Size(119, 21);
            checkshopassword.TabIndex = 20;
            checkshopassword.Text = "Show Password";
            checkshopassword.UseVisualStyleBackColor = true;
            checkshopassword.CheckedChanged += checkshopassword_CheckedChanged_1;
            // 
            // txtpassword
            // 
            txtpassword.BackColor = Color.FromArgb(231, 232, 233);
            txtpassword.BorderStyle = BorderStyle.FixedSingle;
            txtpassword.Font = new Font("MS UI Gothic", 18F);
            txtpassword.Location = new Point(98, 238);
            txtpassword.Multiline = true;
            txtpassword.Name = "txtpassword";
            txtpassword.PasswordChar = '*';
            txtpassword.Size = new Size(216, 28);
            txtpassword.TabIndex = 1;
            txtpassword.TextChanged += txtpassword_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(85, 210);
            label3.Name = "label3";
            label3.Size = new Size(66, 17);
            label3.TabIndex = 16;
            label3.Text = "Password";
            // 
            // txtusername
            // 
            txtusername.BackColor = Color.FromArgb(231, 232, 233);
            txtusername.BorderStyle = BorderStyle.FixedSingle;
            txtusername.Font = new Font("MS UI Gothic", 18F);
            txtusername.Location = new Point(96, 158);
            txtusername.Multiline = true;
            txtusername.Name = "txtusername";
            txtusername.Size = new Size(216, 28);
            txtusername.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(83, 130);
            label2.Name = "label2";
            label2.Size = new Size(75, 17);
            label2.TabIndex = 14;
            label2.Text = "User Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MS UI Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(116, 86, 174);
            label1.Location = new Point(133, 92);
            label1.Name = "label1";
            label1.Size = new Size(155, 27);
            label1.TabIndex = 13;
            label1.Text = "Get Started";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(178, 6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(74, 70);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 25;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(367, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(40, 36);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 26;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // frmlogin
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(409, 462);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(checkshopassword);
            Controls.Add(txtpassword);
            Controls.Add(label3);
            Controls.Add(txtusername);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(164, 165, 169);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmlogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmlogin";
            Load += frmlogin_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label6;
        private Label label5;
        private Button button2;
        private Button button1;
        private CheckBox checkshopassword;
        private TextBox txtpassword;
        private Label label3;
        private TextBox txtusername;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}