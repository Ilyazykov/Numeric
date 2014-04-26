using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoundaryValue
{
    class FunctionQStar : Function
    {
        double ksi;

        public FunctionQStar(double ksi)
        {
            this.ksi = ksi;
        }

        public override double getValue(double x)
        {
            if (x < ksi) return (ksi * ksi + 1);
            else return ksi * ksi;
        }

        public override double integrateFuncton(double from, double to)
        {
            if (to < ksi)
            {
                return (ksi * ksi + 1) * (to - from);
            }
            else if (from > ksi)
            {
                return ksi * ksi * (to - from);
            }
            else
            {
                return (ksi * ksi + 1) * (ksi - from) + ksi * ksi * (to - ksi);
            }
        }

        public override double integrateDevidedOneIntoFunction(double from, double to)
        {
            throw new NotImplementedException();
        }
    }
}
