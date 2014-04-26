using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoundaryValue
{
    class BoundaryValue
    {
        public double beginX { get; private set; }
        public double beginY { get; private set; }

        public double endX { get; private set; }
        public double endY { get; private set; }

        public BoundaryValue(double beginX, double beginY, double endX, double endY)
        {
            this.beginX = beginX;
            this.beginY = beginY;
            this.endX = endX;
            this.endY = endY;
        }
    }
}
