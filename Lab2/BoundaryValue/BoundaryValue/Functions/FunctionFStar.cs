using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoundaryValue
{
    class FunctionFStar : Function
    {
        double ksi;

        public FunctionFStar(double ksi)
        {
            this.ksi = ksi;
        }

        public override double getValue(double x)
        {
            if (x < ksi) return Math.Sin(ksi);
            else return Math.Cos(ksi);
        }

        public override double integrateFuncton(double from, double to)
        {
            if (to < ksi)
            {
                return Math.Sin(ksi) * (to - from);
            }
            else if (from > ksi)
            {
                return Math.Cos(ksi) * (to - from);
            }
            else
            {
                return Math.Sin(ksi) * (ksi - from) + Math.Cos(ksi) * (to - ksi);
            }
        }

        public override double integrateDevidedOneIntoFunction(double from, double to)
        {
            throw new NotImplementedException();
        }
    }
}
