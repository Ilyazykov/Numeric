using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoundaryValue
{
    class FunctionQStar2 : Function
    {
        public FunctionQStar2()
        {
        }

        public override double getValue(double x)
        {
            return 1;
        }

        public override double integrateFuncton(double from, double to)
        {
            return (to - from);
        }

        public override double integrateDevidedOneIntoFunction(double from, double to)
        {
            throw new NotImplementedException();
        }
    }
}
