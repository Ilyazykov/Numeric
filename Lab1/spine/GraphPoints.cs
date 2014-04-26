using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace spine
{
    class GraphPoints
    {
        public List<double> x { get; set; }
        public List<double> y { get; set; }

        public GraphPoints()
        {
            x = new List<double>();
            y = new List<double>();
        }

        public Point getMaximumDifferenceWith(GraphPoints secondGraph)
        {
            double res = 0;
            int resI = 0;

            for (int i = 0; i < y.Count; i++)
            {
                double currentMax = Math.Abs(this.y[i] - secondGraph.y[i]);
                if (currentMax > res)
                {
                    res = currentMax;
                    resI = i;
                }
            }

            return new Point(x[resI], res);
        }

        public double getMaximumFirstDifferentialDifferenceWith(Function realFunction)
        {
            double res = 0;

            for (int i = 1; i < y.Count - 1; i++)
            {
                double dy = (y[i + 1] - y[i - 1]) / (x[i + 1] - x[i - 1]);
                double realFunction_dy = realFunction.getFirstDifferential(x[i]);

                double currentMax = Math.Abs(dy - realFunction_dy);
                if (currentMax > res) res = currentMax;
            }

            return res;
        }
        public double getMaximumFirstDifferentialDifferenceWith(GraphPoints secondGraph)
        {
            double res = 0;

            for (int i = 1; i < y.Count - 1; i++)
            {
                double dy = (y[i + 1] - y[i - 1]) / (x[i + 1] - x[i - 1]);
                double secondGraph_dy = (secondGraph.y[i + 1] - secondGraph.y[i - 1]) / 
                    (secondGraph.x[i + 1] - secondGraph.x[i - 1]);

                double currentMax = Math.Abs(dy - secondGraph_dy);
                if (currentMax > res) res = currentMax;
            }

            return res;
        }

        public double getMaximumSecondDifferentialDifferenceWith(Function realFunction)
        {
            double res = 0;

            for (int i = 1; i < y.Count - 1; i++)
            {
                double dy = (y[i + 1] - 2 * y[i] + y[i - 1]) / ((x[i + 1] - x[i]) * (x[i + 1] - x[i]));
                double realFunction_dy = realFunction.getSecondDifferential(x[i]);

                double currentMax = Math.Abs(dy - realFunction_dy); //TODO разница слишком велика
                if (currentMax > res) res = currentMax;
            }

            return res;
        }
        public double getMaximumSecondDifferentialDifferenceWith(GraphPoints secondGraph)
        {
            double res = 0;

            for (int i = 1; i < y.Count - 1; i++)
            {
                double dy = 4 * (y[i + 1] - 2 * y[i] + y[i - 1]) / Math.Pow((x[i + 1] - x[i - 1]), 2.0);
                double secondGraph_dy = 4 * (secondGraph.y[i + 1] - 2 * secondGraph.y[i] + secondGraph.y[i - 1]) /
                    Math.Pow((secondGraph.x[i + 1] - secondGraph.x[i - 1]), 2.0);

                double currentMax = Math.Abs(dy - secondGraph_dy);
                if (currentMax > res) res = currentMax;
            }

            return res;
        }
    }
}
