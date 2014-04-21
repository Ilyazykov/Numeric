using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.Model.DifferentialEquation
{
    class FirstTask : DiferentialEquation
    {
        public FirstTask(double y0) : base(y0) { }

        public override double F(double x, double y)
        {
            double y2 = y*y;
            double y3 = y2*y;
            return (x*y2)/(1 + x*x) + y - y3*Math.Sin(10*x);
        }

        public override double GetAnaliticalValue(double x)
        {
            throw new NotImplementedException();
        }
    }
}
