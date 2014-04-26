using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoundaryValue
{
    class FunctionYStar : GetterListOfValues
    {
        public double ksi { get; private set; }

        private double c1u1, c1u2, c2u1, c2u2;
        private double a1, a2, b1, b2;

        public FunctionYStar(double ksi) 
        {
            this.ksi = ksi;

            getConstants();
        }

        private void getConstants()
        {
            double nu1 = 0;
            double nu2 = 0;

            double k1 = Math.Exp(-ksi * ksi);
            double k2 = ksi + 1;

            double q1 = ksi * ksi + 1;
            double q2 = ksi * ksi;

            double f1 = Math.Sin(ksi);
            double f2 = Math.Cos(ksi);

            a1 = Math.Sqrt(q1 / k1);
            a2 = Math.Sqrt(q2 / k2);

            b1 = f1 / q1;
            b2 = f2 / q2;

            double c2u1t1 = Math.Exp(-a1 * ksi) - Math.Exp(a1 * ksi);
            double c2u2t1 = Math.Exp(-2 * a2) * Math.Exp(a2 * ksi) - Math.Exp(-a2 * ksi);
            double t1 = Math.Exp(a2 * (ksi - 1)) * (1 - b2) + b2 + b1 * (Math.Exp(a1 * ksi) - 1);

            double c2u1t2 = k1*a1 * (Math.Exp(a1 * ksi) + Math.Exp(-a1 * ksi));
            double c2u2t2 = - k2*a2 * (Math.Exp(a2 * (ksi - 2)) + Math.Exp(-a2 * ksi));
            double t2 = k2 * a2 * Math.Exp(a2 * (ksi - 1)) * (b2 - 1) - k1 * a1 * b1 * Math.Exp(a1 * ksi);

            c2u1 = (t1 * c2u2t2 - t2 * c2u2t1) / (c2u1t1 * c2u2t2 - c2u1t2 * c2u2t1);
            c2u2 = (c2u1t1 * t2 - c2u1t2 * t1) / (c2u1t1 * c2u2t2 - c2u1t2 * c2u2t1);

            c1u1 = - b1 - c2u1;
            c1u2 = (1 - b2 - c2u2 * Math.Exp(-a2)) * Math.Exp(-a2);
        }

        public double getValue(double x)
        {
            if (x < ksi)
            {
                return c1u1 * Math.Exp(a1 * x) + c2u1 * Math.Exp(-a1 * x) + b1;
            }
            else
            {
                return c1u2 * Math.Exp(a2 * x) + c2u2 * Math.Exp(-a2 * x) + b2;
            }
        }

        public override List<double> getValues(BoundaryValue boundaryValue, int numberOfIntervals)
        {
            double[] x = new double[numberOfIntervals + 1];
            double[] y = new double[numberOfIntervals + 1];

            double step = (boundaryValue.endX - boundaryValue.beginX) / numberOfIntervals;
            for (int i = 0; i <= numberOfIntervals; i++)
            {
                x[i] = boundaryValue.beginX + i * step;
            }

            for (int i = 0; i <= numberOfIntervals; i++)
            {
                y[i] = getValue(x[i]);
            }

            List<double> res = new List<double>(y);
            return res;
        }
    }
}
