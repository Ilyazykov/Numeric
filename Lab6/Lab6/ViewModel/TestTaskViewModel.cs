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
        public ObservableCollection<ChartPoint> AnaliticalChartData { get; set; }
        public ObservableCollection<ChartPoint> NumericalChartData { get; set; }
        public ObservableCollection<TestTableData> ResultTable { get; set; }

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

        private DiferentialEquation _equation;

        public TestTaskViewModel()
        {
            _equation = new TestTask(1);

            Y0 = 1;
            MaximumNumberOfIteration = 10;
            IsFixedStep = false;
            StepSize = 1;
            EpsilonUp = 0.001;
            RightBorder = 20.0;

            СalculationCommandExecutor();

            СalculationCommand = new RelayCommand(СalculationCommandExecutor);
        }

        private void GetTable()
        {
            ResultTable = new ObservableCollection<TestTableData>();

            var dx = StepSize;
            double xPrev = 0;
            double yPrev = Y0;

            int c1 = 0;
            int c2 = 0;
            ResultTable.Add(new TestTableData(0,Y0,Y0,0,0,dx,0,0,Y0,0));

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
                    else if (estimationOfLocalError > EpsilonUp)
                    {
                        dx /= 2;
                        c1++;
                    }
                }

                double u = _equation.GetAnaliticalValue(x);
                ResultTable.Add(new TestTableData(x, y, y2, Math.Abs(y-y2), estimationOfLocalError, dx, c1, c2, u, Math.Abs(u-y)));

                xPrev = x;
                yPrev = y;

            }
            RaisePropertyChanged("ResultTable");
        }

        private void GetCharts()
        {
            AnaliticalChartData = new ObservableCollection<ChartPoint>();
            NumericalChartData = new ObservableCollection<ChartPoint>();

            for (int i = 0; i < ResultTable.Count; i++)
            {
                AnaliticalChartData.Add(new ChartPoint(ResultTable[i].X, ResultTable[i].U));
                NumericalChartData.Add(new ChartPoint(ResultTable[i].X, ResultTable[i].V));
            }

            RaisePropertyChanged("AnaliticalChartData");
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

                if (Math.Abs(testTableData.U - testTableData.V) > Res.MaxError)
                {
                    Res.MaxError = Math.Abs(testTableData.U - testTableData.V);
                    Res.MaxErrorX = testTableData.X;
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
