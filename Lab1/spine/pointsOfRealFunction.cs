using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace spine
{
    class PointsOfRealFunction : GraphPoints
    {
        public void getRealFunction(double begin, double end, Function function, double interval = 0.1)
        {
            x.Clear();
            y.Clear();

            for (double i = begin; i < end; i += interval)
            {
                x.Add(i);
                y.Add(function.getValue(i));
            }

            x.Add(end);
            y.Add(function.getValue(end));
        }
    }
}
