using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Model
{
    public class ChartPoint
    {
        public double X { get; set; }
        public double Y { get; set; }

        public ChartPoint(double x = 0, double y = 0)
        {
            X = x;
            Y = y;
        }
    }
}
