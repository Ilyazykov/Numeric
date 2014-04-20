using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Model.Integrating
{
    class TrapezoidalMethod : IntegrateDecorator
    {
        public Function MyFunction { get; set; }

        public TrapezoidalMethod(Function function)
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
            double x = begin;
            double y2 = GetValue(x);
            for (int i = 1; i < numberOfSteps + 1; i++)
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
