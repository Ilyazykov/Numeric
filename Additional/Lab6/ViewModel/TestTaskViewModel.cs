using System;
using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Lab6.Model;
using Lab6.Model.DifferentialEquation;
using Xceed.Wpf.Toolkit;

namespace Lab6.ViewModel
{
    public class TestTaskViewModel : ViewModelBase
    {
        public ObservableCollection<ChartPoint> NumericalChartData { get; set; }
        public ObservableCollection<MajorTableData> ResultTable { get; set; }

        public double RightBorder { get; set; }

        public Result Res { get; set; } //TODO посчитать
        
        private double _y0;
        public double Y0
        {
            get { return _y0; }
            set
            {
                _y0 = value;
                _equation.Y0 = value;
            }
        }

        private double _a1;
        public double A1
        {
            get { return _a1; }
            set
            {
                _a1 = value;
                _equation.A1 = value;
            }
        }

        private double _a3;
        public double A3
        {
            get { return _a3; }
            set
            {
                _a3 = value;
                _equation.A3 = value;
            }
        }

        private double _m;
        public double M
        {
            get { return _m; }
            set
            {
                _m = value;
                _equation.M = value;
            }
        }

        public int MaximumNumberOfIteration { get; set; }
        public double EpsilonUp { get; set; }

        private bool _isFixedStep;
        public bool IsFixedStep
        {
            get { return _isFixedStep; }
            set
            {
                _isFixedStep = value;
                RaisePropertyChanged("IsFixedStep");
            }
        }

        public double StepSize { get; set; }
        
        public RelayCommand СalculationCommand { get; set; }


        private void СalculationCommandExecutor()
        {
            GetTable();
            GetCharts();
            GetRes();
        }

        private TestTask _equation;

        public TestTaskViewModel()
        {
            _equation = new TestTask(1,1,1,1);

            Y0 = 1;
            A1 = 1;
            A3 = 1;
            M = 1;

            MaximumNumberOfIteration = 1000;
            IsFixedStep = false;
            StepSize = 0.01;
            EpsilonUp = 0.00001;
            RightBorder = 20.0;

            СalculationCommandExecutor();

            СalculationCommand = new RelayCommand(СalculationCommandExecutor);
        }

        private void GetTable()
        {
            ResultTable = new ObservableCollection<MajorTableData>();

            var dx = StepSize;
            double xPrev = 0;
            double yPrev = Y0;

            int c1 = 0;
            int c2 = 0;
            ResultTable.Add(new MajorTableData(0,Y0,Y0,0,0,dx,0,0));

            for (int i = 1; i < MaximumNumberOfIteration; i++)
            {
                double x = xPrev + dx;
                if (x>RightBorder) break;

                double y = _equation.GetNumericalValue(x, xPrev, yPrev);

                double x2 = xPrev + dx/2;
                double y2 = _equation.GetNumericalValue(x2, xPrev, yPrev);
                y2 = _equation.GetNumericalValue(x, x2, y2);

                double estimationOfLocalError = Math.Abs(y2 - y)/15;

                if (!IsFixedStep)
                {
                    if (estimationOfLocalError < EpsilonUp/32)
                    {
                        dx *= 2;
                        c2++;
                    }
                    else while (estimationOfLocalError > EpsilonUp)
                        {
                            dx /= 2;
                            c1++;

                            x = xPrev + dx;

                            y = _equation.GetNumericalValue(x, xPrev, yPrev);

                            x2 = xPrev + dx / 2;
                            y2 = _equation.GetNumericalValue(x2, xPrev, yPrev);
                            y2 = _equation.GetNumericalValue(x, x2, y2);

                            estimationOfLocalError = Math.Abs(y2 - y) / 15;
                        }
                }

                ResultTable.Add(new MajorTableData(x, y, y2, Math.Abs(y-y2), estimationOfLocalError, dx, c1, c2));

                xPrev = x;
                yPrev = y;

            }
            RaisePropertyChanged("ResultTable");
        }

        private void GetCharts()
        {
            NumericalChartData = new ObservableCollection<ChartPoint>();

            for (int i = 0; i < ResultTable.Count; i++)
            {
                double x = ResultTable[i].X;
                double y = ResultTable[i].V;

                if (double.IsNaN(y) || double.IsInfinity(y)) break;

                NumericalChartData.Add(new ChartPoint(x, y));
            }

            RaisePropertyChanged("NumericalChartData");
        }

        private void GetRes()
        {
            Res = new Result
            {
                MaxEle = 0,
                MaxStep = StepSize,
                MaxStepX = 0,
                MinStep = StepSize,
                MinStepX = 0,
                MaxError = 0,
                MaxErrorX = 0
            };

            foreach (var testTableData in ResultTable)
            {
                if (testTableData.Ele > Res.MaxEle) Res.MaxEle = testTableData.Ele;
                if (testTableData.H > Res.MaxStep)
                {
                    Res.MaxStep = testTableData.H;
                    Res.MaxErrorX = testTableData.X;
                }
                else if (testTableData.H < Res.MinStep)
                {
                    Res.MinStep = testTableData.H;
                    Res.MinStepX = testTableData.X;
                }
            }

            Res.DistanceToBorder = RightBorder - ResultTable[ResultTable.Count - 1].X;
            Res.NumberOfStep = ResultTable.Count;
            Res.StepDecrement = ResultTable[ResultTable.Count - 1].C1;
            Res.StepIncrement = ResultTable[ResultTable.Count - 1].C2;

            RaisePropertyChanged("Res");
        }
    }
}
