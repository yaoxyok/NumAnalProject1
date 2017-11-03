using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumAnalProject1.Algorithms
{
    class BicubicInterpolation : Interpolation
    {
        public BicubicInterpolation(double[][] mat) : base(mat)
        {
        }

        public override double FromMatrix(double x, double y)
        {
            int i = (int)Math.Floor(x);
            int j = (int)Math.Floor(y);

            double u = x - Math.Floor(x);
            double v = y - Math.Floor(y);

            int X = nrow;
            int Y = ncol;

            if (i < 1)
            {
                i = 1;
                u = 0;
            }

            if (j < 1)
            {
                j = 1;
                v = 0;
            }

            if (i > X - 3)
            {
                i = X - 3;
                u = 1;
            }

            if (j > Y - 3)
            {
                j = Y - 3;
                v = 1;
            }

            double f00 = mat[i][j];
            double f10 = mat[i + 1][j];
            double f01 = mat[i][j + 1];
            double f11 = mat[i + 1][j + 1];

            double fx00 = (f10 - mat[i - 1][j]) / 2;
            double fx10 = (mat[i + 2][j] - f00) / 2;
            double fx01 = (f11 - mat[i - 1][j + 1]) / 2;
            double fx11 = (mat[i + 2][j + 1] - f01) / 2;

            double fy00 = (f01 - mat[i][j - 1]) / 2;
            double fy10 = (f11 - mat[i + 1][j - 1]) / 2;
            double fy01 = (mat[i][j + 2] - f00) / 2;
            double fy11 = (mat[i + 1][j + 2] - f10) / 2;

            double fxy00 = (f11 + mat[i - 1][j - 1] - mat[i + 1][j - 1] - mat[i - 1][j + 1]) / 4;
            double fxy10 = (mat[i + 2][j + 1] + mat[i][j - 1] - mat[i + 2][j - 1] - f01) / 4;
            double fxy01 = (mat[i + 1][j + 2] + mat[i - 1][j] - f10 - mat[i - 1][j + 2]) / 4;
            double fxy11 = (mat[i + 2][j + 2] + f00 - mat[i + 2][j] - mat[i][j + 2]) / 4;

            double[,] a = new double[4, 4];

            a[0, 0] = f00;
            a[1, 0] = fx00;
            a[2, 0] = -3 * f00 + 3 * f10 - 2 * fx00 - fx10;
            a[3, 0] = 2 * f00 - 2 * f10 + fx00 + fx10;

            a[0, 1] = fy00;
            a[1, 1] = fxy00;
            a[2, 1] = -3 * fy00 + 3 * fy10 - 2 * fxy00 - fxy10;
            a[3, 1] = -2 * fy00 - 2 * fy10 + fxy00 + fxy10;

            a[0, 2] = -3 * f00 + 3 * f01 - 2 * fy00 - fy01;
            a[1, 2] = -3 * fx00 + 3 * fx01 - 2 * fxy00 - fxy01;
            a[2, 2] = 9 * f00 - 9 * f10 - 9 * f01 + 9 * f11 + 6 * fx00 + 3 * fx10 - 6 * fx01 - 3 * fx11
                + 6 * fy00 - 6 * fy10 + 3 * fy01 - 3 * fy11 + 4 * fxy00 + 2 * fxy10 + 2 * fxy01 + fxy11;
            a[3, 2] = -6 * f00 + 6 * f10 + 6 * f01 - 6 * f11 - 3 * fx00 - 3 * fx10 + 3 * fx01 + 3 * fx11
                - 4 * fy00 + 4 * fy10 - 2 * fy01 + 2 * fy11 - 2 * fxy00 - 2 * fxy10 - fxy01 - fxy11;

            a[0, 3] = 2 * f00 - 2 * f01 + fy00 + fy01;
            a[1, 3] = 2 * fx00 - 2 * fx01 + fxy00 + fxy01;
            a[2, 3] = -6 * f00 + 6 * f10 + 6 * f01 - 6 * f11 - 4 * fx00 - 2 * fx10 + 4 * fx01 + 2 * fx11
                - 3 * fy00 + 3 * fy10 - 3 * fy01 + 3 * fy11 - 2 * fxy00 - fxy10 - 2 * fxy01 - fxy11;
            a[3, 3] = 4 * f00 - 4 * f10 - 4 * f01 + 4 * f11 + 2 * fx00 + 2 * fx10 - 2 * fx01 - 2 * fx11
                + 2 * fy00 - 2 * fy10 + 2 * fy01 - 2 * fy11 + fxy00 + fxy10 + fxy01 + fxy11;

            double[] us = new double[] { 1, u, u * u, u * u * u };
            double[] vs = new double[] { 1, v, v * v, v * v * v };

            double ret = 0;
            for (int m = 0; m < 4; m++)
            {
                for (int n = 0; n < 4; n++)
                {
                    ret += a[m, n] * us[m] * vs[n];
                }
            }
            return ret;
        }
    }
}
