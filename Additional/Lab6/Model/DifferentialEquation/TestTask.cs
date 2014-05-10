using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.Model.DifferentialEquation
{
    class TestTask : DiferentialEquation
    {
        //dy/dx = -(a1*u + a3*u^3)/m 

        public double A1 { get; set; }
        public double A3 { get; set; }
        public double M { get; set; }

        public TestTask(double y0, double a1, double a3, double m) : base(y0)
        {
            A1 = a1;
            A3 = a3;
            M = m;
        }

        public override double F(double x, double y)
        {
            return -(A1*y + A3*y*y*y)/M;
        }

        public override double GetAnaliticalValue(double x)
        {
            throw new NotImplementedException();
        }
    }
}
