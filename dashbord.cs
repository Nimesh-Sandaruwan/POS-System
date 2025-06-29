using System;
using System.Windows.Forms;

namespace pos_System
{
    public partial class dashbord : Form
    {
        private Button myButton; // Declare 'myButton' as a Button

        public dashbord()
        {
            InitializeComponent();
        }

        private void dashbord_Load(object sender, EventArgs e)
        {
            // Create the button
            myButton = new Button();
            myButton.Text = "Click Me!";
            myButton.Width = 100;
            myButton.Height = 50;

            // Anchor the button to the top-left corner
            myButton.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            // Add the button to the form's controls
            this.Controls.Add(myButton);

            // Set the button's position
            myButton.Left = 10;
            myButton.Top = 10;

            // Attach MouseEnter and MouseLeave events to all PictureBox controls
            pictureBox1.MouseEnter += new EventHandler(pictureBox_MouseEnter);
            pictureBox1.MouseLeave += new EventHandler(pictureBox_MouseLeave);
            pictureBox2.MouseEnter += new EventHandler(pictureBox_MouseEnter);
            pictureBox2.MouseLeave += new EventHandler(pictureBox_MouseLeave);
            pictureBox3.MouseEnter += new EventHandler(pictureBox_MouseEnter);
            pictureBox3.MouseLeave += new EventHandler(pictureBox_MouseLeave);
            pictureBox4.MouseEnter += new EventHandler(pictureBox_MouseEnter);
            pictureBox4.MouseLeave += new EventHandler(pictureBox_MouseLeave);
            pictureBox5.MouseEnter += new EventHandler(pictureBox_MouseEnter);
            pictureBox5.MouseLeave += new EventHandler(pictureBox_MouseLeave);
            pictureBox6.MouseEnter += new EventHandler(pictureBox_MouseEnter);
            pictureBox6.MouseLeave += new EventHandler(pictureBox_MouseLeave);
        }

        // Generic MouseEnter event handler for all PictureBoxes
        private void pictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            if (pictureBox != null)
            {
                // Slightly enlarge the image when the mouse enters the PictureBox
                pictureBox.Width = (int)(pictureBox.Width * 1.2); // Increase width by 20%
                pictureBox.Height = (int)(pictureBox.Height * 1.2); // Increase height by 20%
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // Stretch the image to fit the new size
            }
        }

        // Generic MouseLeave event handler for all PictureBoxes
        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            if (pictureBox != null)
            {
                // Restore the original size when the mouse leaves the PictureBox
                pictureBox.Width = (int)(pictureBox.Width / 1.2); // Decrease width by 20%
                pictureBox.Height = (int)(pictureBox.Height / 1.2); // Decrease height by 20%
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom; // Restore the zoom mode for the image
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Handle panel paint event (optional)
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Closes the application
                                // OR if inside a Form class:
                                // this.Close(); // Closes the current form
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            items items = new items();
            items.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            stock stock = new stock();
            stock.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Reporting reporting = new Reporting();
            reporting.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            billing billing = new billing();
            billing.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Support Support = new Support();
            Support.Show();
            this.Hide();
        }
    }
}
