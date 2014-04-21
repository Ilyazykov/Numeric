using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Model
{
    class FirstOscillatingFunction : Function
    {
        public override double GetValue(double x)
        {
            var temp = new MyFunction();
            return temp.GetValue(x) + Math.Cos(10*x);
        }

        public override double IntegrateAnalitical(double begin, double end)
        {
            var temp = new MyFunction();
            return temp.IntegrateAnalitical(begin, end) + (Math.Sin(10*end)-Math.Sin(10*begin))/10;
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
