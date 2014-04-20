using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Model.Integrating
{
    class SimpsonsMethod : IntegrateDecorator
    {
        public SimpsonsMethod(Function function)
        {
            this.MyFunction = function;
        }

        public override double GetValue(double x)
        {
            return MyFunction.GetValue(x);
        }

        public override double IntegrateAnalitical(double begin, double end)
        {
            return MyFunction.IntegrateAnalitical(begin, end);
        }

        public override double IntegrateNumerical(double begin, double end, int numberOfSteps)
        {
            double dx = (end - begin) / numberOfSteps;
            double res = 0;

            for (int i = 0; i < numberOfSteps; i++)
            {
                res += dx*(GetValue(begin + i*dx) + GetValue(begin + (i + 1)*dx) + 4*GetValue(begin + i*dx + dx/2))/6;
            }
            return res;
        }
    }
}