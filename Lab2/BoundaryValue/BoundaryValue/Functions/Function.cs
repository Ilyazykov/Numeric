using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoundaryValue
{
    abstract class Function
    {
        abstract public double getValue(double x);
        abstract public double integrateFuncton(double from, double two);
        abstract public double integrateDevidedOneIntoFunction(double from, double to);
    }
}