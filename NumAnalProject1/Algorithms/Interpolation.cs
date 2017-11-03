using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumAnalProject1.Algorithms
{
    public class Interpolation
    {
        public Interpolation(double[][] mat)
        {
            this.mat = mat;
            this.nrow = mat.Length;
            this.ncol = mat[0].Length;
        }
        public virtual double FromMatrix(double x, double y)
        {
            return 0;
        }

        protected double[][] mat;
        protected int nrow;
        protected int ncol;
    }
}
