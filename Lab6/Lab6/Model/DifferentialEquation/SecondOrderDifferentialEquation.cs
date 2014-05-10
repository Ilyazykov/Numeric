using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.Model.DifferentialEquation
{
    public class SecondOrderSolution
    {
        public double Y { get; set; }
        public double Y1 { get; set; }

        public SecondOrderSolution(double y, double y1)
        {
            Y = y;
            Y1 = y1;
        }
    }

    abstract class SecondOrderDifferentialEquation : DiferentialEquation
    {
        //y''=F(x,y,y')
        //y(x0)=y0
        //y'(x0)=y1
        public double Y1 { get; set; }

        public double A { get; set; }
        public double B { get; set; }

        protected SecondOrderDifferentialEquation(double y0, double y1) : base(y0)
        {
            Y1 = y1;
        }

        public abstract double F1(double x, double y, double y1);
        public abstract double F2(double x, double y, double y1);

        public SecondOrderSolution GetNumericalValue(double x, double xPrev, double yPrev, double y1Prev)
        {
            double dx = x - xPrev;

            double k1 = F1(xPrev, yPrev, y1Prev);
            double m1 = F2(xPrev, yPrev, y1Prev);

            double k2 = F1(xPrev + dx / 2, yPrev + dx * k1 / 2, y1Prev + dx * m1 / 2);
            double m2 = F2(xPrev + dx / 2, yPrev + dx * k1 / 2, y1Prev + dx * m1 / 2);

            double k3 = F1(xPrev + dx / 2, yPrev + dx * k2 / 2, y1Prev + dx * m2 / 2);
            double m3 = F2(xPrev + dx / 2, yPrev + dx * k2 / 2, y1Prev + dx * m2 / 2);

            double k4 = F1(xPrev + dx / 2, yPrev + dx * k3, y1Prev + dx * m3);
            double m4 = F2(xPrev + dx / 2, yPrev + dx * k3, y1Prev + dx * m3);

            double y1 = y1Prev + dx * (m1 + 2 * m2 + 2 * m3 + m4) / 6;
            double y = yPrev + dx * (k1 + 2 * k2 + 2 * k3 + k4) / 6;
            
            var res = new SecondOrderSolution(y, y1);
            return res;
        }
    }
}
