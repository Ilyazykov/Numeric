using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Model
{
    class SecondOscillatingFunction : IFunction
    {
        public double GetValue(double x)
        {
            var temp = new MyFunction();
            return temp.GetValue(x) + Math.Cos(100 * x);
        }

        public double IntegrateAnalitical(double begin, double end)
        {
            var temp = new MyFunction();
            return temp.IntegrateAnalitical(begin, end) + (Math.Sin(100 * end) - Math.Sin(100 * begin)) / 100;
        }

        public double IntegrateNumerically(double begin, double end)
        {
            return 10; //TODO change
        }
    }
}
