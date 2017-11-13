using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumAnalProject1.Algorithms
{
    /// <summary>
    /// Base class of all interpolations
    /// </summary>
    class Interpolation
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mat">one-channel image</param>
        public Interpolation(double[][] mat)
        {
            this.mat = mat;
            this.nrow = mat.Length;
            this.ncol = mat[0].Length;
        }

        /// <summary>
        /// (virtual) Calculate the interpolated value in the matrix
        /// </summary>
        /// <param name="x">row-coordinate of the intermediate point</param>
        /// <param name="y">column-coordinate of the intermediate point</param>
        /// <returns>result of the interpolation</returns>
        public virtual double FromMatrix(double x, double y)
        {
            return 0;
        }

        /// <summary>
        /// the image stored in two-dimensional matrix
        /// </summary>
        protected double[][] mat;

        /// <summary>
        /// Number of rows
        /// </summary>
        protected int nrow;

        /// <summary>
        /// Number of columns
        /// </summary>
        protected int ncol;
    }
}
