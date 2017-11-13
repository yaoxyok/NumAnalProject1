using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumAnalProject1.Algorithms
{
    /// <summary>
    /// Base class of all B-splines
    /// </summary>
    class BSplineBase
    {
        /// <summary>
        /// (virtual) Calculate the base function of some order
        /// </summary>
        /// <param name="i">should range from 0 to the B-spline order (inclusive)</param>
        /// <param name="t">should range from 0 and 1</param>
        /// <returns>the value of the base function, which serces as the weights of neighboring control points</returns>
        public virtual double CalcBase(int i, double t)
        {
            return 0;
        }
    }
}
