using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace spine
{
    abstract class Function
    {
        abstract public double getValue(double x);
        abstract public double getFirstDifferential(double x);
        abstract public double getSecondDifferential(double x);
    }
}