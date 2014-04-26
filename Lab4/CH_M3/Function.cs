using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CH_M3
{
    abstract class Task
    {
        public abstract double [] area();
        public abstract bool test();
        public abstract double m1(double x);
        public abstract double m2(double x);
        public abstract double m3(double x);
        public abstract double m4(double x);
        public abstract double f(double x, double y);
        public abstract double U(double x, double y);
    }



    class MainTask9 : Task
    {
        public override bool test(){return false;}
        public override double[] area() { return new double[]{1,2,1,2};}
        public override double m1(double x)
        {
            return  0;
        }

        public override double m2(double x)
        {
            return 0;
        }

        public override double m3(double x)
        {
            return Math.Sin(x * Math.PI) * Math.Sin(x * Math.PI);
        }

        public override double m4(double x)
        {
            double r = Math.Cosh((x - 1) * (x - 2)) - 1;
            return Math.Cosh((x - 1) * (x - 2)) - 1;
        }

        public override double f(double x, double y)
        {
            return Math.Atan(x / y);
        }

        public override double U(double x, double y)
        {
            return -87;
        }
    }


    class TestTask9 : Task
    {
        public override bool test() { return true; }
        public override double[] area() { return new double[] { 1, 2, 1, 2 }; }
        public override double m1(double x)
        {
            return Math.Exp(1 - x * x);
        }

        public override double m2(double x)
        {
            return Math.Exp(4 - x * x);
        }

        public override double m3(double x)
        {
            return Math.Exp(x * x - 1); 
        }

        public override double m4(double x)
        {
            return Math.Exp(x * x - 4); 
        }

        public override double f(double x, double y)
        {
            return -4 * (x*x + y*y ) * Math.Exp(x * x - y * y);
        }

        public override double U(double x, double y)
        {
            return Math.Exp(x * x - y * y);
        }
    }


    class MainTask2 : Task
    {
        public override bool test() { return false; }
        public override double[] area() { return new double[] { -1, 1, -1, 1 }; }
        public override double m1(double x)
        {
            return 1 - x * x;
        }

        public override double m2(double x)
        {
            return 1 - x * x;
        }

        public override double m3(double x)
        {
            return Math.Abs(Math.Sin(x * Math.PI));
        }

        public override double m4(double x)
        {
            return Math.Abs(Math.Sin(x * Math.PI));
        }

        public override double f(double x, double y)
        {
            double s = Math.Abs(Math.Sin(x * y * Math.PI));
            return s*s*s;
        }

        public override double U(double x, double y)
        {
            return -988;
        }
    }

        class TestTask2 : Task
        {
            public override bool test() { return true; }
            public override double[] area() { return new double[] { -1, 1, -1, 1 }; }
            public override double m1(double x)
        {
            return  - x * x;
        }

        public override double m2(double x)
        {
            return - x * x;
        }

        public override double m3(double x)
        {
            return -x * x;
        }

        public override double m4(double x)
        {
            return -x * x;
        }

        public override double f(double x, double y)
        {
            return 4;
        }

        public override double U(double x, double y)
        {
            return 1 - x * x - y * y;
        }
    }

}
