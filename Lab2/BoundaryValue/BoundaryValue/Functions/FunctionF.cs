using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoundaryValue
{
    class FunctionF : Function
    {
        double ksi;

        public FunctionF(double ksi)
        {
            this.ksi = ksi;
        }

        public override double getValue(double x)
        {
            if (x < ksi) return Math.Sin(x);
            else return Math.Cos(x);
        }

        public override double integrateFuncton(double from, double to)
        {
            if (to < ksi)
            {
                return Math.Cos(from) - Math.Cos(to);
            }
            else if (from > ksi)
            {
                return Math.Sin(to) - Math.Sin(from);
            }
            else
            {
                return Math.Cos(from) - Math.Cos(ksi) +
                    Math.Sin(to) - Math.Sin(ksi);
            }
        }

        public override double integrateDevidedOneIntoFunction(double from, double to)
        {
            throw new NotImplementedException();
        }
    }
}
