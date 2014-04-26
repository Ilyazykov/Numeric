using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace spine
{
    class FunctionOnInterval
    {
        double begin;
        double end;
        Function function;

        FunctionOnInterval(Function function, double begin, double end)
        {
            this.function = function;
            this.begin = begin;
            this.end = end;
        }

        public double getMaximumDifferenceWith(Function function, double interval)
        {
            double res = 0;

            for (double x = begin; x < end; x += interval)
            {
                double dy = this.function.getValue(x);
                double secondFunction_dy = function.getValue(x);

                double currentMax = Math.Abs(dy - secondFunction_dy);
                if (currentMax > res) res = currentMax;
            }

            return res;
        }

        public double getMaximumFirstDifferentialDifferenceWith(Function function, double interval)
        {
            double res = 0;

            for (double x = begin; x < end; x += interval)
            {
                double dy = this.function.getFirstDifferential(x);
                double secondFunction_dy = function.getFirstDifferential(x);

                double currentMax = Math.Abs(dy - secondFunction_dy);
                if (currentMax > res) res = currentMax;
            }

            return res;
        }

        public double getMaximumSecondDifferentialDifferenceWith(Function function, double interval)
        {
            double res = 0;

            for (double x = begin; x < end; x += interval)
            {
                double dy = this.function.getSecondDifferential(x);
                double realFunction_dy = function.getSecondDifferential(x);

                double currentMax = Math.Abs(dy - realFunction_dy);
                if (currentMax > res) res = currentMax;
            }

            return res;
        }
    }
}