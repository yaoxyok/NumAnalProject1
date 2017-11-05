using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumAnalProject1.Algorithms
{
    class QuardricBSplineBase : BSplineBase
    {
        public override double CalcBase(int i, double t)
        {
            switch (i)
            {
                case 0:
                    return (1 - t) * (1 - t) / 2;
                case 1:
                    return ((-2 * t + 2) * t + 1) / 2;
                case 2:
                    return t * t / 2;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }
}
