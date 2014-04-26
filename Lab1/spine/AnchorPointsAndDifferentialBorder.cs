using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace spine
{
    class AnchorPointsAndDifferentialBorder : AnchorPoints
    {
        public AnchorPointsAndDifferentialBorder(int n) : base(n)
        {
        }

        public override void getAnchorPoints(double begin, double end, Function function)
        {
            x = new double[number];
            y = new double[number];

            double interval = (end - begin) / (number - 1);

            for (int i = 0; i < number; i++)
            {
                x[i] = begin + i * interval;
                y[i] = function.getValue(x[i]);
            }

            secondDifferentialBegin = function.getSecondDifferential(begin);
            secondDifferentialEnd = function.getSecondDifferential(end);
        }
    }
}