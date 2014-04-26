using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoundaryValue
{
    class FunctionK : Function
    {
        double ksi;
        double numberOfIntervals;

        public FunctionK(double ksi, double numberOfStep = 5)
        {
            this.ksi = ksi;
            this.numberOfIntervals = numberOfStep;
        }

        public override double getValue(double x)
        {
            if (x < ksi) return Math.Exp(-x * x);
            else return x + 1;
        }

        public override double integrateFuncton(double from, double to)
        {
            throw new NotImplementedException();
        }

        double k1(double x)
        {
            return Math.Exp(x * x);
        }

        public override double integrateDevidedOneIntoFunction(double from, double to)
        {
            if (to <= ksi)
            {
                double dx = (to - from) / numberOfIntervals;

                double sum = 0;
                for (double x = from; x < to-dx+dx/2; x += dx)
                {
                    sum += (k1(x) + k1(x+dx)) * dx / 2;
                }
                return sum;
            }
            else if (from >= ksi)
            {
                return Math.Log((to + 1) / (from + 1), Math.E);
            }
            else
            {
                double dx = (ksi - from) / numberOfIntervals;

                double sum = 0;
                for (double x = from; x <= ksi - dx+dx/2; x += dx)
                {
                    sum += (k1(x) + k1(x + dx)) * dx / 2;
                }

                sum += Math.Log((to + 1) / (ksi + 1), Math.E);

                return sum;
            }
        }
    }
}
