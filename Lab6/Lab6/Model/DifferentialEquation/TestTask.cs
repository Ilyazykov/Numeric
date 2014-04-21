using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.Model.DifferentialEquation
{
    class TestTask : DiferentialEquation
    {
        //y'=y

        public TestTask(double y0) : base(y0) { }

        public override double F(double x, double y)
        {
            return y;
        }

        public override double GetAnaliticalValue(double x)
        {
            return Y0*Math.Exp(x);
        }
    }
}
