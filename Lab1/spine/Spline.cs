using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace spine
{
    class Spline : Function
    {
        SplineTuple[] splines;

        struct SplineTuple
        {
            //s(x)=a+b(x-xi)+c/2 *(x-xi)^2 + d/6 *(x-xi)^3
            public double a, b, c, d, x;
        }

        public double getCoef(char a, int i)
        {
            SplineTuple s = splines[i];
            
            switch (a)
            {
                case 'a':
                    return s.a;
                case 'b':
                    return s.b;
                case 'c':
                    return s.c;
                case 'd':
                    return s.d;
                case 'x':
                    return s.x;
            }
            return -1;
        }

        public void BuildSpline(double[] x, double[] y, int n, double secondDifferentialBegin = 0.0, double secondDifferentialEnd = 0.0)
        {
            splines = new SplineTuple[n];
            for (int i = 0; i < n; ++i)
            {
                splines[i].x = x[i];
                splines[i].a = y[i];
            }
            splines[0].c = secondDifferentialBegin;
            splines[n - 1].c = secondDifferentialEnd;

            double[] alpha = new double[n - 1];
            double[] beta = new double[n - 1];
            alpha[0] = 0.0;
            beta[0] = splines[0].c;
            for (int i = 1; i < n - 1; ++i)
            {
                double hi = x[i] - x[i - 1];
                double hi1 = x[i + 1] - x[i];
                double A = hi;
                double C = 2.0 * (hi + hi1);
                double B = hi1;
                double F = 6.0 * ((y[i + 1] - y[i]) / hi1 - (y[i] - y[i - 1]) / hi);
                double z = (A * alpha[i - 1] + C);
                alpha[i] = -B / z;
                beta[i] = (F - A * beta[i - 1]) / z;
            }

            for (int i = n - 2; i > 0; --i)
            {
                splines[i].c = alpha[i] * splines[i + 1].c + beta[i];
            }

            for (int i = n - 1; i > 0; --i)
            {
                double hi = x[i] - x[i - 1];
                splines[i].d = (splines[i].c - splines[i - 1].c) / hi;
                splines[i].b = hi * (2.0 * splines[i].c + splines[i - 1].c) / 6.0 + (y[i] - y[i - 1]) / hi;
            }
        }

        int getNumberOfSplineTurple(double x)
        {
            int n = splines.Length;

            if (x <= splines[0].x)
            {
                return 0;
            }
            else if (x >= splines[n - 1].x)
            {
                return n - 1;
            }
            else
            {
                int i = 0;
                int j = n - 1;
                while (i + 1 < j)
                {
                    int k = i + (j - i) / 2;
                    if (x <= splines[k].x)
                    {
                        j = k;
                    }
                    else
                    {
                        i = k;
                    }
                }
                return j;
            }
        }

        public override double getValue(double x)
        {
            int number = getNumberOfSplineTurple(x);
            SplineTuple s = splines[number];

            double dx = x - s.x;

            return s.a + (s.b + (s.c / 2.0 + s.d * dx / 6.0) * dx) * dx;
            //s(x)=a+b(x-xi)+c/2 *(x-xi)^2 + d/6 *(x-xi)^3
            //s(x) = b +c
        } 

        public override double getFirstDifferential(double x)
        {
            int number = getNumberOfSplineTurple(x);
            SplineTuple s = splines[number];

            double dx = x - s.x;

            return s.b + (s.c + (s.d / 2.0) * dx) * dx;
            //s(x)=a+b(x-xi)+c/2 *(x-xi)^2 + d/6 *(x-xi)^3
            //s'(x)=b+c*(x-xi) + d/2 *(x-xi)^2
        }

        public override double getSecondDifferential(double x)
        {
            int number = getNumberOfSplineTurple(x);
            SplineTuple s = splines[number];

            double dx = x - s.x;
            return s.c + s.d * dx;
            //s(x)=a+b(x-xi)+c/2 *(x-xi)^2 + d/6 *(x-xi)^3
            //s'(x)=b+c*(x-xi) + d/2 *(x-xi)^2
            //s''(x)=c + d *(x-xi)
        }
    }
}
