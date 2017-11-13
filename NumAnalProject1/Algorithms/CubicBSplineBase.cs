using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumAnalProject1.Algorithms
{
    /// <summary>
    /// Base function of a cubic B-spline
    /// </summary>
    class CubicBSplineBase : BSplineBase
    {
        /// <summary>
        /// Calculate the base function of order 3
        /// </summary>
        /// <param name="i">should range from 0 to 3 (inclusive)</param>
        /// <param name="t">should range from 0 and 1</param>
        /// <returns>the value of the base function, which serces as the weights of neighboring control points</returns>
        public override double CalcBase(int i, double t)
        {
            switch (i)
            {
                case 0:
                    return (1 + t * (-3 + t * (3 + t * (-1)))) / 6;
                case 1:
                    return (4 + t * t * (-6 + t * 3)) / 6;
                case 2:
                    return (1 + t * (3 + t * (3 + t * (-3)))) / 6;
                case 3:
                    return t * t * t / 6;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }
}
