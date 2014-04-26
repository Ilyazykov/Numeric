using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoundaryValue
{
    class TestTwoEquation : Equation
    {
        public TestTwoEquation()
        {
            f = new FunctionFStar2();
            k = new FunctionKStar2();
            q = new FunctionQStar2();
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

            double[] alpha = new double[numberOfIntervals + 1];
            double[] beta = new double[numberOfIntervals + 1];

            y[0] = boundaryValue.beginY;
            y[numberOfIntervals] = boundaryValue.endY;
            alpha[1] = beta[1] = 0;

            for (int i = 2; i <= numberOfIntervals; i++)
            {
                double t = ( alpha[i - 1] - (2 + step * step) );
                alpha[i] = -1 / t;
                beta[i] = ( (2 - x[i-1] * x[i-1]) * step * step - beta[i-1]) / t;
            }

            for (int i = numberOfIntervals - 1; i > 0; i--)
            {
                y[i] = alpha[i + 1] * y[i + 1] + beta[i + 1];
            }

            List<double> res = new List<double>(y);
            return res;
        }
    }
}
