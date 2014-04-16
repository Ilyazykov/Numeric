using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Model
{
    class MyFunction : IFunction
    {
        public double GetValue(double x)
        {
            return 1/(1 + x);
        }

        public double IntegrateAnalitical(double begin, double end)
        {
            return Math.Log(end+1) - Math.Log(begin+1);
        }

        public double IntegrateNumerically(double begin, double end)
        {
            return 10; //TODO change
        }
    }
}
