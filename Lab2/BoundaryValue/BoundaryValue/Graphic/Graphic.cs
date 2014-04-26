using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoundaryValue
{
    class Graphic
    {
        public List<double> x;
        public List<double> y;

        public int numberOfIntervals { get; private set; }

        
        public Graphic(int numberOfIntervals)
        {
            this.numberOfIntervals = numberOfIntervals;
            x = new List<double>();
            y = new List<double>();
        }

        public void getFrom(GetterListOfValues getter, BoundaryValue boundaryValue)
        {
            double step = (boundaryValue.endX - boundaryValue.beginX) / numberOfIntervals;
            for (int i = 0; i <= numberOfIntervals; i++)
            {
                x.Add(boundaryValue.beginX + i * step);
            }

            y = getter.getValues(boundaryValue, numberOfIntervals);
        }

        public Tuple<double,double> getMax(Graphic g2)
        {
            if (this.numberOfIntervals == g2.numberOfIntervals)
            {
                double max = 0;
                double pointOfMax = 0;

                for (int i = 1; i < numberOfIntervals; i++)
                {
                    if (Math.Abs(this.y[i] - g2.y[i]) > max)
                    {
                        max = Math.Abs(this.y[i] - g2.y[i]);
                        pointOfMax = x[i];
                    }
                }
                Tuple<double, double> res = new Tuple<double, double>(pointOfMax, max);
                return res;
            }
            else if (this.numberOfIntervals == g2.numberOfIntervals * 2)
            {
                double max = 0;
                double pointOfMax = 0;

                for (int i = 1; i < g2.numberOfIntervals; i++)
                {
                    if (Math.Abs(this.y[2*i] - g2.y[i]) > max)
                    {
                        max = Math.Abs(this.y[2*i] - g2.y[i]);
                        pointOfMax = x[2*i];
                    }
                }
                Tuple<double, double> res = new Tuple<double, double>(pointOfMax, max);
                return res;
            }
            else if (this.numberOfIntervals * 2 == g2.numberOfIntervals)
            {
                double max = 0;
                double pointOfMax = 0;

                for (int i = 1; i < numberOfIntervals; i++)
                {
                    if (Math.Abs(this.y[i] - g2.y[i*2]) > max)
                    {
                        max = Math.Abs(this.y[i] - g2.y[i*2]);
                        pointOfMax = x[i];
                    }
                }
                Tuple<double, double> res = new Tuple<double, double>(pointOfMax, max);
                return res;
            }
            else throw new NotImplementedException();
        }
    }
}