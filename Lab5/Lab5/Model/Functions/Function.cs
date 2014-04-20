using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Model
{
    public abstract class Function
    {
        public List<double> A { get; protected set; }
        public List<double> B { get; protected set; }
        public double Alpha { get; protected set; }

        public double X { get; set; }


        public abstract double GetValue(double x);
        public abstract double IntegrateAnalitical(double begin, double end);
        public abstract double IntegrateNumerical(double begin, double end, int numberOfSteps);

        public abstract void ChangeFunction(Function function);
    }
}