using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumAnalProject1.Algorithms
{
    class NearestNeighborInterpolation : Interpolation
    {
        public NearestNeighborInterpolation(double[][] mat) : base(mat)
        {
        }

        public override double FromMatrix(double x, double y)
        {
            int i = (int)Math.Round(x);
            int j = (int)Math.Round(y);
            i = Math.Max(0, Math.Min(nrow - 1, i));
            j = Math.Max(0, Math.Min(ncol - 1, j));
            return mat[i][j];
        }
    }
}
