using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumAnalProject1.Algorithms
{
    /// <summary>
    /// Nearest-Neighbor Interpolation
    /// </summary>
    class NearestNeighborInterpolation : Interpolation
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mat">one-channel image</param>
        public NearestNeighborInterpolation(double[][] mat) : base(mat)
        {
        }

        /// <summary>
        /// Calculate the interpolated value in the matrix
        /// </summary>
        /// <param name="x">row-coordinate of the intermediate point</param>
        /// <param name="y">column-coordinate of the intermediate point</param>
        /// <returns>result of the interpolation</returns>
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
