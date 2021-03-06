﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.Model
{
    public class TestTableData
    {
        public double X { get; set; }
        public double V { get; set; }
        public double V2 { get; set; }
        public double ErrorVv2 { get; set; }
        public double Ele { get; set; }
        public double H { get; set; }
        public int C1 { get; set; }
        public int C2 { get; set; }
        public double U { get; set; }
        public double ErrorUv { get; set; }

        public TestTableData() { }

        public TestTableData(double x, double v, double v2, double errorVv2, double ele, double h, int c1, int c2, double u,
            double errorUv)
        {
            X = x;
            V = v;
            V2 = v2;
            ErrorVv2 = errorVv2;
            Ele = ele;
            H = h;
            C1 = c1;
            C2 = c2;
            U = u;
            ErrorUv = errorUv;
        }
    }
}
