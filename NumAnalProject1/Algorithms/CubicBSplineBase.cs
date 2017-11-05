using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumAnalProject1.Algorithms
{
    class CubicBSplineBase : BSplineBase
    {
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
