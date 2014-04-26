using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace spine
{
    class RealSplineImagine
    {
        public double borderLeft {get; set;}
        public double borderRight {get; set;}
        public Spline spline { get; set; }

        public RealSplineImagine()
        {}

        public RealSplineImagine(double begin, double end)
        {
            borderLeft = begin;
            borderRight = end;
            spline = new Spline();
        }

        public Point getMaximumFirstDifferentialDifferenceWith(Function function, double begin, double end, double interval)
        {
            double res = 0;
            double resX = 0;

            for (double x = begin+interval; x < end-interval; x+=interval)
            {
                double dy = spline.getFirstDifferential(x);
                double realFunction_dy = function.getFirstDifferential(x);

                double currentMax = Math.Abs(dy - realFunction_dy);
                if (currentMax > res) 
                {
                    resX = x;
                    res = currentMax;
                }
            }

            return new Point(resX,res);
        }

        public Point getMaximumSecondDifferentialDifferenceWith(Function function, double begin, double end, double interval)
        {
            double res = 0;
            double resX = 0;

            for (double x = begin+interval; x < end-interval; x += interval)
            {
                double dy = spline.getSecondDifferential(x);
                double realFunction_dy = function.getSecondDifferential(x);

                double currentMax = Math.Abs(dy - realFunction_dy);
                if (currentMax > res)
                {
                    resX = x;
                    res = currentMax;
                }
            }

            return new Point(resX, res);
        }
    }
}
