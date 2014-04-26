using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoundaryValue
{
    class TestOneEquation : Equation
    {
        public TestOneEquation(double ksi)
        {
            f = new FunctionFStar(ksi);
            k = new FunctionKStar(ksi);
            q = new FunctionQStar(ksi);
        }
    }
}
