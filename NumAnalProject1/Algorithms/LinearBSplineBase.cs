using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumAnalProject1.Algorithms
{
    class LinearBSplineBase : BSplineBase
    {
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
