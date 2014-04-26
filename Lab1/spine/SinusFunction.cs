using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace spine
{
    class SinusFunction : Function
    {
        public override double getValue(double x)
        {
            return Math.Sin(x);
        }

        public override double getFirstDifferential(double x)
        {
            return Math.Cos(x);
        }

        public override double getSecondDifferential(double x)
        {
            return -Math.Sin(x);
        }
    }
}
