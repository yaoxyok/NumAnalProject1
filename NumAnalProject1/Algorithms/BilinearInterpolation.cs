using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumAnalProject1.Algorithms
{
    class BilinearInterpolation : Interpolation
    {
        public BilinearInterpolation(double[][] mat) : base(mat)
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

            if (i < 0)
            {
                i = 0;
                u = 0;
            }

            if (j < 0)
            {
                j = 0;
                v = 0;
            }

            if (i > X - 2)
            {
                i = X - 2;
                u = 1;
            }

            if (j > Y - 2)
            {
                j = Y - 2;
                v = 1;
            }

            double a00 = mat[i][j];
            double a10 = mat[i + 1][j] - a00;
            double a01 = mat[i][j + 1] - a00;
            double a11 = mat[i + 1][j + 1] - a10 - a01 - a00;

            return a00 + a10 * u + a01 * v + a11 * u * v;
        }
    }
}
