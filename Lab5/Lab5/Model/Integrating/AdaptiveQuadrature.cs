using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Model.Integrating
{
    public class AdaptiveQuadrature
    {
        private Function _func;

        private double _x;
        public double X
        {
            get { return _x; }
            set
            {
                _x = value;
                _func.ChangeX(value);
            }
        }

        public AdaptiveQuadrature(Function func)
        {
            _func = func;
        }

        public double GetValue(double begin, double end, double eps, int n, ref int numberOfCalls)
        {
            double middle = (begin + end) / 2;

            double I = _func.IntegrateNumerical(begin, end, n);
            double Ia = _func.IntegrateNumerical(begin, middle, n);
            double Ib = _func.IntegrateNumerical(middle, end, n);
            numberOfCalls++;

            if (Math.Abs(Ia + Ib - I) < eps) return I;

            return GetValue(begin, middle, eps/2, n, ref numberOfCalls) +
                   GetValue(middle, end, eps/2, n, ref numberOfCalls);
        }
    }
}
