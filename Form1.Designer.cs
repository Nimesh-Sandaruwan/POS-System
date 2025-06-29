namespace pos_System
{
    partial class Frmregister
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmregister));
            label1 = new Label();
            label2 = new Label();
            txtusername = new TextBox();
            txtpassword = new TextBox();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            label5 = new Label();
            label6 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MS UI Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(116, 86, 174);
            label1.Location = new Point(118, 97);
            label1.Name = "label1";
            label1.Size = new Size(155, 27);
            label1.TabIndex = 0;
            label1.Text = "Get Started";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(73, 148);
            label2.Name = "label2";
            label2.Size = new Size(65, 15);
            label2.TabIndex = 2;
            label2.Text = "User Name";
            // 
            // txtusername
            // 
            txtusername.BackColor = Color.FromArgb(231, 232, 233);
            txtusername.BorderStyle = BorderStyle.FixedSingle;
            txtusername.Font = new Font("MS UI Gothic", 18F);
            txtusername.Location = new Point(89, 169);
            txtusername.Multiline = true;
            txtusername.Name = "txtusername";
            txtusername.Size = new Size(216, 28);
            txtusername.TabIndex = 0;
            // 
            // txtpassword
            // 
            txtpassword.BackColor = Color.FromArgb(231, 232, 233);
            txtpassword.BorderStyle = BorderStyle.FixedSingle;
            txtpassword.Font = new Font("MS UI Gothic", 18F);
            txtpassword.Location = new Point(89, 230);
            txtpassword.Multiline = true;
            txtpassword.Name = "txtpassword";
            txtpassword.Size = new Size(216, 28);
            txtpassword.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(76, 206);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 4;
            label3.Text = "Password";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(116, 86, 174);
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(89, 296);
            button1.Name = "button1";
            button1.Size = new Size(216, 35);
            button1.TabIndex = 2;
            button1.Text = "REGISTER";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.Cursor = Cursors.Hand;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.FromArgb(116, 86, 174);
            button2.Location = new Point(89, 337);
            button2.Name = "button2";
            button2.Size = new Size(216, 35);
            button2.TabIndex = 3;
            button2.Text = "CLEAR";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(132, 388);
            label5.Name = "label5";
            label5.Size = new Size(141, 15);
            label5.TabIndex = 11;
            label5.Text = "Already Have an Account";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Cursor = Cursors.Hand;
            label6.Font = new Font("Nirmala UI", 9F, FontStyle.Bold);
            label6.Location = new Point(164, 412);
            label6.Name = "label6";
            label6.Size = new Size(89, 15);
            label6.TabIndex = 4;
            label6.Text = "Back to LOGIN";
            label6.Click += label6_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(165, 15);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(74, 70);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // Frmregister
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(409, 462);
            Controls.Add(pictureBox1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(txtpassword);
            Controls.Add(label3);
            Controls.Add(txtusername);
            Controls.Add(label2);
            Controls.Add(label1);
            ForeColor = Color.FromArgb(116, 86, 174);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Frmregister";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Frmregister";
            Load += Frmregister_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtusername;
        private TextBox txtpassword;
        private Label label3;
        private Button button1;
        private Button button2;
        private Label label5;
        private Label label6;
        private PictureBox pictureBox1;
    }
}
