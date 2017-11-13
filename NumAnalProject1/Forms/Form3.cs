using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace NumAnalProject1.Forms
{
    partial class Form3 : FormBase
    {
        public Form3()
        {
            InitializeComponent();

            pictureBoxPreview.SizeMode = PictureBoxSizeMode.Normal;
            labelControlPointIndex.Text = "控制点下标：\r\n未选中";
        }

        private ControlPoint[,] controlPoints;
        private Bitmap paddedRawImage;

        protected override void updateImage()
        {
            if (pictureBoxPreview.Image == null)
            {
                return;
            }

            this.progressBar.Value = 30;

            this.SuspendLayout();

            if (this.controlPoints != null)
            {
                foreach (ControlPoint cp in this.controlPoints)
                {
                    this.Controls.Remove(cp);
                }
            }

            int densityRow = (int)this.numericUpDownIntervalRow.Value;
            int densityColumn = (int)this.numericUpDownIntervalColumn.Value;

            int nRow = (rawImage.Height - 2) / densityRow + 2;
            int nColumn = (rawImage.Width - 2) / densityColumn + 2;

            pictureBoxPreview.Image = padImage(new Bitmap(this.rawImage),
                (nRow - 1) * densityRow + 1 - rawImage.Height,
                (nColumn - 1) * densityColumn + 1 - rawImage.Width);
            paddedRawImage = new Bitmap(pictureBoxPreview.Image);

            pictureBoxPreview.Size = pictureBoxPreview.Image.Size;
            this.Size = new Size(Math.Max(400, 400 + pictureBoxPreview.Size.Width), Math.Max(275, 275 + pictureBoxPreview.Height));

            controlPoints = new ControlPoint[nRow, nColumn];

            for (int i = 0; i < nRow; i++)
            {
                for (int j = 0; j < nColumn; j++)
                {
                    controlPoints[i, j] = new ControlPoint(i, j, this,
                        pictureBoxPreview.Left - 3 + densityColumn * j,
                        pictureBoxPreview.Top - 3 + densityRow * i);
                    this.Controls.Add(controlPoints[i, j]);
                    controlPoints[i, j].BringToFront();
                }
            }

            this.ResumeLayout(false);
            this.PerformLayout();

            this.progressBar.Value = 100;
        }

        private unsafe Bitmap padImage(Bitmap origImage, int incrementRow, int incrementColumn)
        {

            int origSizeRow = origImage.Height;
            int origSizeColumn = origImage.Width;

            int newSizeRow = origImage.Height + incrementRow;
            int newSizeColumn = origImage.Width + incrementColumn;

            Bitmap newImage = new Bitmap(newSizeColumn, newSizeRow);

            BitmapData newBitmapData = newImage.LockBits(new Rectangle(0, 0, newSizeColumn, newSizeRow),
                ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            BitmapData origBitmapData = origImage.LockBits(new Rectangle(0, 0, origSizeColumn, origSizeRow),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            UInt32* newStartingPosition = (UInt32*)newBitmapData.Scan0;
            UInt32* origStartingPosition = (UInt32*)origBitmapData.Scan0;

            for (int i = 0; i < newSizeRow; i++)
            {
                for (int j = 0; j < newSizeColumn; j++)
                {
                    newStartingPosition[j + i * newSizeColumn] = 0xff000000;
                }
            }

            for (int i = 0; i < origSizeRow; i++)
            {
                for (int j = 0; j < origSizeColumn; j++)
                {
                    newStartingPosition[(j + incrementColumn / 2) + (i + incrementRow / 2) * newSizeColumn]
                        = origStartingPosition[j + i * origSizeColumn];
                }
            }

            origImage.UnlockBits(origBitmapData);
            newImage.UnlockBits(newBitmapData);

            return newImage;
        }

        protected void BSpline()
        {
            if (pictureBoxPreview.Image == null)
            {
                return;
            }

            int nx = (int)numericUpDownIntervalColumn.Value;
            int ny = (int)numericUpDownIntervalRow.Value;

            int X = pictureBoxPreview.Image.Size.Width;
            int Y = pictureBoxPreview.Image.Size.Height;

            Algorithms.Interpolation interpRed = null;
            Algorithms.Interpolation interpGreen = null;
            Algorithms.Interpolation interpBlue = null;

            double[][][] mats = bitmapToMat(paddedRawImage);

            if (radioButtonNearestNeighbor.Checked)
            {
                interpRed = new Algorithms.NearestNeighborInterpolation(mats[0]);
                interpGreen = new Algorithms.NearestNeighborInterpolation(mats[1]);
                interpBlue = new Algorithms.NearestNeighborInterpolation(mats[2]);
            }

            if (radioButtonBilinear.Checked)
            {
                interpRed = new Algorithms.BilinearInterpolation(mats[0]);
                interpGreen = new Algorithms.BilinearInterpolation(mats[1]);
                interpBlue = new Algorithms.BilinearInterpolation(mats[2]);
            }

            if (radioButtonBicubic.Checked)
            {
                interpRed = new Algorithms.BicubicInterpolation(mats[0]);
                interpGreen = new Algorithms.BicubicInterpolation(mats[1]);
                interpBlue = new Algorithms.BicubicInterpolation(mats[2]);
            }

            UInt32[][] mat = new UInt32[Y][];
            for (int k = 0; k < Y; k++)
            {
                mat[k] = new UInt32[X];
            }

            Algorithms.BSplineBase bSplineBase = null;
            int order = (int)numericUpDownBSplineOrder.Value;
            switch (order)
            {
                case 1:
                    bSplineBase = new Algorithms.LinearBSplineBase();
                    break;
                case 3:
                    bSplineBase = new Algorithms.CubicBSplineBase();
                    break;
            }

            this.progressBar.Value = 0;

            for (int x = 0; x < X; x++)
            {
                if (x % (X / 10) == 0)
                {
                    this.progressBar.Value = Math.Min(100, progressBar.Value + 10);
                }

                for (int y = 0; y < Y; y++)
                {

                    double currX = x;
                    double currY = y;

                    const double eps = 1e-2;
                    const int maxIteration = 10;

                    double disX = 0;
                    double disY = 0;

                    double prevDisX = 0;
                    double prevDisY = 0;

                    for (int count = 0; count < maxIteration; count++)
                    {
                        double u = (currX / nx) - Math.Floor(currX / nx);
                        double v = (currY / ny) - Math.Floor(currY / ny);

                        int i = (int)Math.Floor(currX / nx) - (order / 2);
                        int j = (int)Math.Floor(currY / ny) - (order / 2);

                        disX = 0;
                        disY = 0;

                        for (int l = 0; l <= order; l++)
                        {
                            for (int m = 0; m <= order; m++)
                            {
                                double t1 = bSplineBase.CalcBase(l, u);
                                double t2 = bSplineBase.CalcBase(m, v);

                                double t3 = 0;
                                double t4 = 0;
                                if (i + l >= 0 && i + l < controlPoints.GetLength(1)
                                    && j + m >= 0 && j + m < controlPoints.GetLength(0))
                                {
                                    t3 = controlPoints[j + m, i + l].getDisplacement().X;
                                    t4 = controlPoints[j + m, i + l].getDisplacement().Y;
                                }

                                disX += t1 * t2 * t3;
                                disY += t1 * t2 * t4;
                            }
                        }

                        currX = Math.Max(0, Math.Min(X - 1, x - disX));
                        currY = Math.Max(0, Math.Min(Y - 1, y - disY));

                        if (Math.Max(Math.Abs(disX - prevDisX), Math.Abs(disY - prevDisY)) < eps)
                        {
                            break;
                        }
                        else
                        {
                            prevDisX = disX;
                            prevDisY = disY;
                        }
                    }

                    double red = interpRed.FromMatrix((int)currY, (int)currX);
                    double green = interpGreen.FromMatrix((int)currY, (int)currX);
                    double blue = interpBlue.FromMatrix((int)currY, (int)currX);

                    int r = Math.Max(0, Math.Min(255, (int)red));
                    int g = Math.Max(0, Math.Min(255, (int)green));
                    int b = Math.Max(0, Math.Min(255, (int)blue));

                    mat[y][x] = (UInt32)((0xff << 24) | (r << 16) | (g << 8) | (b << 0));
                }
            }

            pictureBoxPreview.Image = new Bitmap(matToBitmap(mat));

            this.progressBar.Value = 100;
        }

        class ControlPoint : PictureBox
        {
            private int i;
            private int j;
            private Form3 parent;

            private int width;
            private int height;
            private bool moveFlag;

            private Point displacement;
            private Point prevLocation;

            public Point getDisplacement()
            {
                return this.displacement;
            }

            public ControlPoint(int i, int j, Form3 parent, int actualX, int actualY)
            {
                this.i = i;
                this.j = j;
                this.parent = parent;
                this.Size = new Size(7, 7);
                this.Image = Properties.Resources.ControlPoint;

                this.MouseDown += new MouseEventHandler(_MouseDown);
                this.MouseUp += new MouseEventHandler(_MouseUp);
                this.MouseMove += new MouseEventHandler(_MouseMove);

                this.Location = new Point(new Size(actualX, actualY));
                this.displacement = new Point(0, 0);
                this.prevLocation = this.Location;
            }

            private int xPos, yPos;
            
            private void _MouseDown(object sender, MouseEventArgs e)
            {
                moveFlag = true;
                xPos = e.X;
                yPos = e.Y;

                parent.labelControlPointIndex.Text = "控制点下标：\r\n" + i.ToString() + " 行 " + j.ToString() + " 列";
            }

            private void _MouseUp(object sender, MouseEventArgs e)
            {
                moveFlag = false;
                this.width = this.Left - parent.pictureBoxPreview.Left;
                this.height = this.Top - parent.pictureBoxPreview.Top;

                this.displacement = new Point(Location.X - prevLocation.X, Location.Y - prevLocation.Y);
                this.prevLocation = this.Location;

                this.BringToFront();

                parent.BSpline();

                parent.labelControlPointIndex.Text = "控制点下标：\r\n" + "未选中";
            }

            private void _MouseMove(object sender, MouseEventArgs e)
            {
                if (moveFlag)
                {
                    this.Left += Convert.ToInt16(e.X - xPos);
                    this.Top += Convert.ToInt16(e.Y - yPos);
                    
                    this.Left = Math.Max(this.Left, parent.pictureBoxPreview.Left) - 3;
                    this.Left = Math.Min(this.Left, parent.pictureBoxPreview.Left + parent.pictureBoxPreview.Size.Width + 2);

                    this.Top = Math.Max(this.Top, parent.pictureBoxPreview.Top) - 3;
                    this.Top = Math.Min(this.Top, parent.pictureBoxPreview.Top + parent.pictureBoxPreview.Size.Height + 2);
                }
            }
        }

        private void numericUpDownIntervalRow_ValueChanged(object sender, EventArgs e)
        {
            this.updateImage();
        }

        private void numericUpDownIntervalColumn_ValueChanged(object sender, EventArgs e)
        {
            this.updateImage();
        }

        private void numericUpDownBSplineOrder_ValueChanged(object sender, EventArgs e)
        {
            this.BSpline();
        }

        protected void radioButtonNearestNeighbor_CheckedChanged(object sender, EventArgs e)
        {
            this.BSpline();
        }

        protected void radioButtonBilinear_CheckedChanged(object sender, EventArgs e)
        {
            this.BSpline();
        }

        protected void radioButtonBicubic_CheckedChanged(object sender, EventArgs e)
        {
            this.BSpline();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            this.updateImage();
        }
    }
}
