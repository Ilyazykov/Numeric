using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoundaryValue
{
    class FunctionQ : Function
    {
        double ksi;

        public FunctionQ(double ksi)
        {
            this.ksi = ksi;
        }

        public override double getValue(double x)
        {
            if (x < ksi) return (x * x + 1);
            else return x * x;
        }

        public override double integrateFuncton(double from, double to)
        {
            if (to < ksi)
            {
                return (to * (to * to + 3) - from * (from * from + 3)) / 3;
            }
            else if (from > ksi)
            {
                return (to * to * to - from * from * from) / 3;
            }
            else
            {
                return (3 * ksi - from * (from * from + 3) + to * to * to) / 3;
            }
        }

        public override double integrateDevidedOneIntoFunction(double from, double to)
        {
            throw new NotImplementedException();
        }
    }
}
