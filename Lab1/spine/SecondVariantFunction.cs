using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace spine
{
    class SecondVariantFunction : Function
    {
        public override double getValue(double x)
        {
            return Math.Pow((1 + x * x), 1.0 / 3);
        }

        public override double getFirstDifferential(double x)
        {
            return (2 * x) / (3 * Math.Pow((1 + x * x), 2.0 / 3));
        }

        public override double getSecondDifferential(double x)
        {
            return -(2 * (x*x-3)) / (9 * Math.Pow((x * x + 1), 5.0 / 3));
        }
    }
}
