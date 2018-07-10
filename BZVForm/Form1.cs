using BZVForm;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace BZVForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Set the bitmap object to the size of the screen
            var bmpScreenshot = new Bitmap(this.Bounds.Width, this.Bounds.Height, PixelFormat.Format32bppArgb);
            // Create a graphics object from the bitmap
            var gfxScreenshot = Graphics.FromImage(bmpScreenshot);
            // Take the screenshot from the upper left corner to the right bottom corner
            button1.Hide();
            //textBox1.(BorderStyle.None);

            gfxScreenshot.CopyFromScreen(this.Bounds.X+20, this.Bounds.Y+30, 40, 40, this.Bounds.Size, CopyPixelOperation.SourceCopy);
            gfxScreenshot.InterpolationMode = InterpolationMode.HighQualityBicubic;

            SaveFileDialog saveImageDialog = new SaveFileDialog();
            saveImageDialog.Title = "Select output file:";
            saveImageDialog.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            //saveImageDialog.FileName = printFileName;
            if (saveImageDialog.ShowDialog() == DialogResult.OK)
            {
                // Save the screenshot to the specified path that the user has chosen
             bmpScreenshot.Save(saveImageDialog.FileName, ImageFormat.Png);
             button1.Show();
             MessageBox.Show("Файл сохранен");
            } 
            else button1.Show();
        }

        public void pictureBox1_Click(object sender, EventArgs e)
        {


                    }

        

        public void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            
            // chose the images type
            opf.Filter = "Choose Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                // get the image returned by OpenFileDialog 
                pictureBox1.Image = Image.FromFile(opf.FileName);

                //create a new Bitmap with the proper dimensions

                Bitmap finalImg = new Bitmap(pictureBox1.Image, pictureBox1.Width, pictureBox1.Height);

                //center the new image
                pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;

                //set the new image
                pictureBox1.Image = finalImg;

                pictureBox1.Show();
                //pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                button2.Hide();
            }
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    
}
