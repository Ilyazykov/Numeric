using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoundaryValue
{
    class FunctionKStar : Function
    {
        double ksi;

        public FunctionKStar(double ksi)
        {
            this.ksi = ksi;
        }

        public override double getValue(double x)
        {
            if (x < ksi) return Math.Exp(-ksi * ksi);
            else return ksi + 1;
        }

        public override double integrateFuncton(double from, double to)
        {
            throw new NotImplementedException();
        }

        public override double integrateDevidedOneIntoFunction(double from, double to)
        {
            if (to < ksi)
            {
                return Math.Exp(ksi * ksi) * (to - from);
            }
            else if (from > ksi)
            {
                return (to - from)/(ksi + 1);
            }
            else 
            {
                return Math.Exp(ksi * ksi) * (ksi - from) + (to - ksi) / (ksi + 1);
            }
        }
    }
}
