using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Model.Functions
{
    public class GeneratedFunctions : Function
    {
        public GeneratedFunctions()
        {
            var random = new Random();

            //A = new List<double>();
            A = new List<double>();
            B = new List<double>();
            
            Alpha = random.NextDouble();
            for (int i = 0; i < 14; i++)
            {
                A.Add(random.NextDouble()*2 - 1);
                B.Add(random.NextDouble()*2 - 1);
            }
            X = 0; //TODO изменение x
        }

        public override double GetValue(double t)
        {
            double res = 0;

            for (int i = 0; i < 14; i++)
            {
                res += A[i]*Math.Sin(2*Math.PI*(i + 1)*(Alpha - X)*t)
                       + B[i]*Math.Cos(2*Math.PI*(i + 1)*(Alpha - X)*t);
            }

            return res;
        }

        public override double IntegrateAnalitical(double begin, double end)
        {
            throw new NotImplementedException();
        }

        public override double IntegrateNumerical(double begin, double end, int numberOfSteps)
        {
            throw new NotImplementedException();
        }

        public override void ChangeFunction(Function function)
        {
            throw new NotImplementedException();
        }
    }
}
