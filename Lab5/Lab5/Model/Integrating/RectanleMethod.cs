using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Model.Integrating
{
    class RectanleMethod : IntegrateDecorator
    {
        public RectanleMethod(Function function)
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
                double x = begin + dx * (i + 0.5d);
                double y = GetValue(x);
                res += y * dx;
            }

            return res;
        }
    }
}
