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
            //TODO

            return 0;
        }
    }
}