using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumAnalProject1.Algorithms
{
    /// <summary>
    /// Base function of a linear B-spline
    /// </summary>
    class LinearBSplineBase : BSplineBase
    {
        /// <summary>
        /// Calculate the base function of order 1
        /// </summary>
        /// <param name="i">should range from 0 to 1 (inclusive)</param>
        /// <param name="t">should range from 0 and 1</param>
        /// <returns>the value of the base function, which serces as the weights of neighboring control points</returns>
        public override double CalcBase(int i, double t)
        {
            switch (i)
            {
                case 0:
                    return 1 - t;
                case 1:
                    return t;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }
}
