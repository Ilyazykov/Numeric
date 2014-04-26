using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoundaryValue
{
    class FunctionTestTwo : GetterListOfValues
    {
        public FunctionTestTwo() { }

        public double getValue(double x)
        {
            return x * x;
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
