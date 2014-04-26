using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoundaryValue
{
    abstract class GetterListOfValues
    {
        abstract public List<double> getValues(BoundaryValue boundaryValue, int numberOfIntervals);
    }
}
