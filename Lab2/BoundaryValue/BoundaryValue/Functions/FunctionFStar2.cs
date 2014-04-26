using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoundaryValue
{
    class FunctionFStar2 : Function
    {
        public FunctionFStar2()
        {
        }

        public override double getValue(double x)
        {
            return x * x - 2;
        }

        public override double integrateFuncton(double from, double to)
        {
            return (to * (to * to - 6) - from * (from * from - 6)) / 3;
        }

        public override double integrateDevidedOneIntoFunction(double from, double to)
        {
            throw new NotImplementedException();
        }
    }
}
