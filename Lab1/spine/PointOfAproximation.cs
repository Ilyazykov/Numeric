using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace spine
{
    class PointsOfAproximation : GraphPoints
    {
        public void getAproximation(AnchorPoints anchorPoints, double begin, double end, double interval = 0.1)
        {
            x.Clear();
            y.Clear();

            RealSplineImagine spline = new RealSplineImagine(begin, end);
            spline.spline.BuildSpline(anchorPoints.x, anchorPoints.y, anchorPoints.number, anchorPoints.secondDifferentialBegin, anchorPoints.secondDifferentialEnd);

            getPointsFromSpline(spline, interval);
        }

        public void getAproximation(RealSplineImagine spline, double interval = 0.1)
        {
            x.Clear();
            y.Clear();

            getPointsFromSpline(spline, interval);
        }

        public void getPointsFromSpline(RealSplineImagine spline, double interval)
        {
            double x1 = spline.borderLeft;
            double xN = spline.borderRight;
            for (double i = x1; i < xN; i += interval)
            {
                x.Add(i);
                y.Add(spline.spline.getValue(i));
            }

            x.Add(xN);
            y.Add(spline.spline.getValue(xN));
        }
    }
}
