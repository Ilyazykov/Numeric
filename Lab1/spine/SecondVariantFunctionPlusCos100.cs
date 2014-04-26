using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace spine
{
    class SecondVariantFunctionPlusCos100 : Function
    {
        public override double getValue(double x)
        {
            SecondVariantFunction temp = new SecondVariantFunction();
            return temp.getValue(x) + Math.Cos(100 * x);
        }

        public override double getFirstDifferential(double x)
        {
            SecondVariantFunction temp = new SecondVariantFunction();
            return temp.getFirstDifferential(x) - 100 * Math.Sin(100 * x);
        }

        public override double getSecondDifferential(double x)
        {
            SecondVariantFunction temp = new SecondVariantFunction();
            return temp.getSecondDifferential(x) - 10000 * Math.Cos(100 * x);
        }
    }
}
