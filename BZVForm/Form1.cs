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
            button1.Hide();

            // Take the screenshot from the upper left corner to the right bottom corner (without frame)
            gfxScreenshot.CopyFromScreen(this.Bounds.X + 20, this.Bounds.Y + 30, 40, 113, this.Bounds.Size, CopyPixelOperation.SourceCopy);
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
        }

        public void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();

            // chose the images type
            opf.Filter = "Choose Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(opf.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap croppedBitmap = new Bitmap(pictureBox1.Image);
                croppedBitmap = croppedBitmap.Clone(
                new Rectangle(
                     (int)numericUpDown2.Value, (int)numericUpDown1.Value,
                       (int)croppedBitmap.Width - (int)numericUpDown2.Value - (int)numericUpDown3.Value,
                       (int)croppedBitmap.Height - (int)numericUpDown1.Value - (int)numericUpDown4.Value),
                        System.Drawing.Imaging.PixelFormat.DontCare);
                pictureBox1.Image = croppedBitmap;

            }
            else
            {
                MessageBox.Show("File not loaded");
            }
        }
    }
}
