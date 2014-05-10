using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.Model
{
    public class Result
    {
        public int NumberOfStep { get; set; }
        public double DistanceToBorder { get; set; }
        public double MaxEle { get; set; }
        public int StepIncrement { get; set; }
        public int StepDecrement { get; set; }
        public double MaxStep { get; set; }
        public double MaxStepX { get; set; }
        public double MinStep { get; set; }
        public double MinStepX { get; set; }
        public double MaxError { get; set; }
        public double MaxErrorX { get; set; }
    }
}
