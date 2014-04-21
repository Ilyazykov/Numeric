using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.Model
{
    public class MajorTableData
    {
        public double X { get; set; }
        public double V { get; set; }
        public double V2 { get; set; }
        public double ErrorVv2 { get; set; }
        public double Ele { get; set; }
        public double H { get; set; }
        public double C1 { get; set; }
        public double C2 { get; set; }

        public MajorTableData(double x, double v, double v2, double errorVv2, double ele, double h, double c1, double c2)
        {
            X = x;
            V = v;
            V2 = v2;
            ErrorVv2 = errorVv2;
            Ele = ele;
            H = h;
            C1 = c1;
            C2 = c2;
        }
    }
}
