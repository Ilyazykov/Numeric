using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Model
{
    class MyFunction : Function
    {
        public override double GetValue(double x)
        {
            return 1/(1 + x);
        }

        public override double IntegrateAnalitical(double begin, double end)
        {
            return Math.Log(end+1) - Math.Log(begin+1);
        }

        public override double IntegrateNumerical(double begin, double end, int numberOfSteps)
        {
            throw new NotImplementedException();
        }

        public override void ChangeFunction(Function function)
        {
            throw new NotImplementedException();
        }
    }
}