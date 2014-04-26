using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace spine
{
    class TestFunction : Function
    {
        public override double getValue(double x)
        {
            if (x < 0) return (x * x * x + 3 * x * x);
            else return (-x * x * x + 3 * x * x);
        }

        public override double getFirstDifferential(double x)
        {
            if (x < 0) return 3 * x * (x + 2);
            else return -3 * x * (x - 2);
        }

        public override double getSecondDifferential(double x)
        {
            if (x < 0) return 6 * (x + 1);
            else return 6 - 6 * x;
        }
    }
}
