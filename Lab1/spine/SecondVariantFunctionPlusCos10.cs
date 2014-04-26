using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace spine
{
    class SecondVariantFunctionPlusCos10 : Function
    {
        public override double getValue(double x)
        {
            SecondVariantFunction temp = new SecondVariantFunction();
            return temp.getValue(x) + Math.Cos(10*x);
        }

        public override double getFirstDifferential(double x)
        {
            SecondVariantFunction temp = new SecondVariantFunction();
            return temp.getFirstDifferential(x) - 10 * Math.Sin(10 * x);
        }

        public override double getSecondDifferential(double x)
        {
            SecondVariantFunction temp = new SecondVariantFunction();
            return temp.getSecondDifferential(x) - 100 * Math.Cos(10*x);
        }
    }
}
