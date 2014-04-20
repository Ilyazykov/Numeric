using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Model
{
    public class DataForTable
    {
        private double _a;
        private double _b;

        public double A
        {
            get { return _a; }
            set { _a = value; }
        }

        public double B
        {
            get { return _b; }
            set { _b = value; }
        }

        public DataForTable(double a = 0, double b = 0)
        {
            A = a;
            B = b;
        }
    }
}
