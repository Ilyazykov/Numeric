using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.Model.DifferentialEquation
{
    class SecondTask : SecondOrderDifferentialEquation
    {
        
        public SecondTask(double y0, double y1, double a, double b) : base(y0, y1)
        {
            A = a;
            B = b;
        }

        public override double F(double x, double y)
        {
            throw new NotImplementedException();
        }

        public override double GetAnaliticalValue(double x)
        {
            throw new NotImplementedException();
        }

        public override double F1(double x, double y, double y1)
        {
            return y1;
        }

        public override double F2(double x, double y, double y1)
        {
            return -(A*A*Math.Sin(y) + B*Math.Sin(x));
        }
    }
}
