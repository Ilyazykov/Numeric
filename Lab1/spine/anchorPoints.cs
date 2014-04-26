using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace spine
{
    class AnchorPoints
    {
        public double[] x;
        public double[] y;

        public int number;

        public double secondDifferentialBegin;
        public double secondDifferentialEnd;

        public AnchorPoints(int n)
        {
            x = new double[n];
            y = new double[n];
            number = n;

            secondDifferentialBegin = 0;
            secondDifferentialEnd = 0;
        }

        virtual public void getAnchorPoints(double begin, double end, Function function)
        {
            x = new double[number];
            y = new double[number];

            double interval = (end - begin) / (number - 1);

            double q = begin;
            for (int i = 0; i < number; i++)
            {
                x[i] = begin + i * interval;
                y[i] = function.getValue(x[i]);
            }
        }
    }
}
