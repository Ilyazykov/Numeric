using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoundaryValue
{
    class MainEquation : Equation
    {
        public MainEquation(double ksi)
        {
            f = new FunctionF(ksi);
            k = new FunctionK(ksi);
            q = new FunctionQ(ksi);
        }
    }
}
