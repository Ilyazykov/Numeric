using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Model.Integrating
{
    public class IntegrateDecorator : Function
    {
        public Function MyFunction { get; set; }

        public override double GetValue(double x)
        {
            throw new NotImplementedException();
        }

        public override double IntegrateAnalitical(double begin, double end)
        {
            throw new NotImplementedException();
        }

        public override double IntegrateNumerical(double begin, double end, int numberOfSteps)
        {
            throw new NotImplementedException();
        }

        public override void ChangeFunction(Function function)
        {
            MyFunction = function;
        }

        public override void ChangeX(double x)
        {
            MyFunction.ChangeX(x);
        }
    }
}