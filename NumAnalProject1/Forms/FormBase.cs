using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Imaging;

namespace NumAnalProject1.Forms
{
    partial class FormBase : Form
    {
        public FormBase()
        {
            InitializeComponent();
            this.radioButtonBilinear.Select();
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Application.StartupPath + "\\..\\data";
            dialog.Filter = "暂仅支持bmp格式|*.bmp";
            dialog.RestoreDirectory = true;
            dialog.FilterIndex = 1;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = dialog.FileName;
                Bitmap image = new Bitmap(Image.FromFile(fileName));
                this.pictureBoxPreview.Image = image;
                rawImage = new Bitmap(image);
                this.updateImage();
            }
        }

        protected Bitmap rawImage;

        protected virtual void updateImage()
        {
        }

        // use unsafe pointers for performance
        // https://stackoverflow.com/questions/13511661/create-bitmap-from-double-two-dimentional-array
        // 
        protected static unsafe double[][][] bitmapToMat(Bitmap image)
        {
            int width = image.Width;
            int height = image.Height;

            double[][][] ret = new double[3][][];

            for (int j = 0; j < 3; j++)
            {
                ret[j] = new double[height][];
                for (int i = 0; i < height; i++)
                {
                    ret[j][i] = new double[width];
                }
            }

            BitmapData bitmapData = image.LockBits(new Rectangle(0, 0, width, height), 
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            UInt32* startingPosition = (UInt32*)bitmapData.Scan0;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    UInt32 aRGB = startingPosition[j + i * width];
                    ret[0][i][j] = (aRGB >> 16) & 0xff;
                    ret[1][i][j] = (aRGB >> 8) & 0xff;
                    ret[2][i][j] = (aRGB >> 0) & 0xff;
                }
            }

            image.UnlockBits(bitmapData);

            return ret;
        }

        // use unsafe pointers for performance
        // https://stackoverflow.com/questions/13511661/create-bitmap-from-double-two-dimentional-array
        // 
        protected static unsafe Bitmap matToBitmap(UInt32[][] mat)
        {
            // mat: 32-bit ARGB
            int height = mat.Length;
            int width = mat[0].Length;

            Bitmap image = new Bitmap(width, height);

            BitmapData bitmapData = image.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            UInt32* startingPosition = (UInt32*)bitmapData.Scan0;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    startingPosition[j + i * width] = mat[i][j];
                }
            }

            image.UnlockBits(bitmapData);
            return image;
        }

        private void buttonRawImage_Click(object sender, EventArgs e)
        {
            if (pictureBoxPreview.Image != null)
            {
                (new FormRawImage(pictureBoxPreview.Image)).ShowDialog();
            }
        }

        private void radioButtonNearestNeighbor_CheckedChanged(object sender, EventArgs e)
        {
            this.updateImage();
        }

        private void radioButtonBilinear_CheckedChanged(object sender, EventArgs e)
        {
            this.updateImage();
        }

        private void radioButtonBicubic_CheckedChanged(object sender, EventArgs e)
        {
            this.updateImage();
        }

    }
}
