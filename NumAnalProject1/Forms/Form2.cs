﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumAnalProject1.Forms
{
    public partial class Form2 : FormBase, OnValueChanged
    {
        public Form2()
        {
            InitializeComponent();
        }

        protected override void updateImage()
        {

            if (rawImage == null)
            {
                return;
            }
            
            double rho = ((double)this.hScrollBarRho.Value / this.hScrollBarRho.Maximum) * 10 * Math.PI;
            double phi = ((double)this.hScrollBarPhi.Value / this.hScrollBarPhi.Maximum) * Math.PI;
            double theta = ((double)this.hScrollBarTheta.Value / this.hScrollBarTheta.Maximum);

            Bitmap image = new Bitmap(rawImage);
            int height = image.Height;
            int width = image.Width;
            double R = Math.Min(height, width) / 2.0;
            double midHeight = height / 2.0;
            double midWidth = width / 2.0;

            double[][][] mats = bitmapToMat(image);

            Algorithms.Interpolation interpRed = null;
            Algorithms.Interpolation interpGreen = null;
            Algorithms.Interpolation interpBlue = null;

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

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    double r = Math.Sqrt((i - midHeight) * (i - midHeight) + (j - midWidth) * (j - midWidth));
                    double alpha = Math.Atan2(j - midWidth, i - midHeight);
                    
                    alpha -= theta * Math.Sin(r * rho / R + phi);
                    
                    double x = midHeight + r * Math.Cos(alpha);
                    double y = midWidth + r * Math.Sin(alpha);

                    int red = (int)Math.Round(interpRed.FromMatrix(x, y));
                    int green = (int)Math.Round(interpGreen.FromMatrix(x, y));
                    int blue = (int)Math.Round(interpBlue.FromMatrix(x, y));

                    red = Math.Max(0, Math.Min(0xff, red));
                    green = Math.Max(0, Math.Min(0xff - 1, green));
                    blue = Math.Max(0, Math.Min(0xff - 1, blue));

                    int argb = (0xFF << 24) | (red << 16) | (green << 8) | blue;

                    image.SetPixel(j, i, Color.FromArgb(argb));
                }
            }
            pictureBoxPreview.Image = image;
        }

        public void Refresh(object sender, EventArgs e)
        {
            this.updateImage();
        }
    }
}
