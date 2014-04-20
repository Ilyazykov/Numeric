using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Model
{
    abstract class Function
    {
        public abstract double GetValue(double x);
        public abstract double IntegrateAnalitical(double begin, double end);

        public double IntegrateNumericallyRectangles(double begin, double end, int numberOfStep = 300)
        {
            double dx = (end - begin) / numberOfStep;

            double res = 0;
            for (int i = 0; i < numberOfStep; i++)
            {
                double x = begin + dx * (i + 0.5d);
                double y = GetValue(x);
                res += y * dx;
            }

            return res;
        }

        public double IntegrateNumericallyTrapezoidal(double begin, double end, int numberOfStep = 300)
        {
            double dx = (end - begin) / numberOfStep;

            double res = 0;
            double x = begin;
            double y2 = GetValue(x);
            for (int i = 1; i < numberOfStep + 1; i++)
            {
                double y1 = y2;
                x = begin + dx * i;
                y2 = GetValue(x);
                res += (y1 + y2) * dx / 2;
            }

            return res;
        }
    }
}