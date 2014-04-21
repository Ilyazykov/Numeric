using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Model
{
    class SecondOscillatingFunction : Function
    {
        public override double GetValue(double x)
        {
            var temp = new MyFunction();
            return temp.GetValue(x) + Math.Cos(100 * x);
        }

        public override double IntegrateAnalitical(double begin, double end)
        {
            var temp = new MyFunction();
            return temp.IntegrateAnalitical(begin, end) + (Math.Sin(100 * end) - Math.Sin(100 * begin)) / 100;
        }

        public override double IntegrateNumerical(double begin, double end, int numberOfSteps)
        {
            throw new NotImplementedException();
        }

        public override void ChangeFunction(Function function)
        {
            throw new NotImplementedException();
        }

        public override void ChangeX(double x)
        {
            throw new NotImplementedException();
        }
    }
}
