using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoundaryValue
{
    abstract class Equation : GetterListOfValues
    {
        public Function f { get; protected set; }
        public Function k { get; protected set; }
        public Function q { get; protected set; }

        public override List<double> getValues(BoundaryValue boundaryValue, int numberOfIntervals)
        {
            double[] x = new double[numberOfIntervals + 1];
            double[] y = new double[numberOfIntervals + 1];

            double[] a = new double[numberOfIntervals + 1];
            double[] d = new double[numberOfIntervals + 1];
            double[] fi = new double[numberOfIntervals + 1];

            double[] alpha = new double[numberOfIntervals + 1];
            double[] beta = new double[numberOfIntervals + 1];

            double step = (boundaryValue.endX - boundaryValue.beginX) / numberOfIntervals;
            for (int i = 0; i <= numberOfIntervals; i++)
            {
                x[i] = boundaryValue.beginX + i * step;
            }

            for (int i = 1; i < numberOfIntervals; i++)
            {
                d[i] = (q.integrateFuncton(x[i] - (step / 2), x[i] + (step / 2)) ) / step;
                fi[i] = (f.integrateFuncton(x[i] - (step / 2), x[i] + (step / 2)) ) / step;
                a[i] = step / (k.integrateDevidedOneIntoFunction(x[i - 1], x[i]));
            }
            a[numberOfIntervals] = step / (k.integrateDevidedOneIntoFunction(x[numberOfIntervals - 1], x[numberOfIntervals]));

            ////////
            y[0] = boundaryValue.beginY;
            y[numberOfIntervals] = boundaryValue.endY;

            for (int i = 2; i <= numberOfIntervals; i++)
            {
                alpha[i] = (-a[i]) / (-a[i] - a[i - 1] - d[i - 1] * step * step + alpha[i - 1] * a[i - 1]);
                beta[i] = (-fi[i - 1] * step * step - a[i - 1] * beta[i - 1]) / (-a[i] - a[i - 1] - d[i - 1] * step * step + alpha[i - 1] * a[i - 1]);
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