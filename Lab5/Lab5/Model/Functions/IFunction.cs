using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Model
{
    interface IFunction
    {
        double GetValue(double x);
        double IntegrateAnalitical(double begin, double end);
        double IntegrateNumerically(double begin, double end);
    }
}