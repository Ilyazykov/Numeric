using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Lab6.Model;
using Lab6.Model.DifferentialEquation;
using System.Windows.Controls.DataVisualization.Charting;

namespace Lab6.ViewModel
{
    public class SecondTaskViewModel : ViewModelBase
    {
        public ObservableCollection<ChartPoint> NumericalChartData { get; set; }
        public ObservableCollection<ChartPoint> NumericalChartDataPhasePortrait { get; set; }
        public ObservableCollection<MajorTableData> ResultTable { get; set; }

        public Result Res { get; set; }

        public double RightBorder { get; set; }

        private List<double> _additionalInfo;

        private double _a;
        public double A
        {
            get { return _a; }
            set
            {
                _a = value;
                _equation.A = value;
            }
        }

        private double _b;
        public double B
        {
            get { return _b; }
            set
            {
                _b = value;
                _equation.B = value;
            }
        }

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

        private double _y1;
        public double Y1
        {
            get { return _y1; }
            set
            {
                _y1 = value;
                _equation.Y1 = value;
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

        private SecondOrderDifferentialEquation _equation;

        public SecondTaskViewModel()
        {
            _equation = new SecondTask(1,0,1,1);//TODO A and B at view

            Y0 = 1;
            Y1 = 0;
            A = 1;
            B = 1;
            MaximumNumberOfIteration = 10;
            IsFixedStep = false;
            StepSize = 0.1;
            EpsilonUp = 0.001;
            RightBorder = 5;

            СalculationCommandExecutor();

            СalculationCommand = new RelayCommand(СalculationCommandExecutor);
        }

        private void GetTable()
        {
            ResultTable = new ObservableCollection<MajorTableData>();
            _additionalInfo = new List<double>();

            var dx = StepSize;
            double xPrev = 0;
            double yPrev = Y0;
            double y1Prev = Y1;

            int c1 = 0;
            int c2 = 0;
            ResultTable.Add(new MajorTableData(0, Y0, Y0, 0, 0, dx, 0, 0));
            _additionalInfo.Add(Y1);

            for (int i = 1; i < MaximumNumberOfIteration; i++)
            {
                double x = xPrev + dx;
                if (x > RightBorder) break;
                SecondOrderSolution y = _equation.GetNumericalValue(x, xPrev, yPrev, y1Prev);

                double x2 = xPrev + dx / 2;
                SecondOrderSolution y2 = _equation.GetNumericalValue(x2, xPrev, yPrev, y1Prev);
                y2 = _equation.GetNumericalValue(x, x2, y2.Y, y2.Y1);

                double estimationOfLocalError = Math.Abs(y2.Y - y.Y) / 15;

                if (!IsFixedStep)
                {
                    if (estimationOfLocalError < EpsilonUp / 32)
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

                ResultTable.Add(new MajorTableData(x, y.Y, y2.Y, Math.Abs(y.Y - y2.Y), estimationOfLocalError, dx, c1, c2));
                _additionalInfo.Add(y.Y1);

                xPrev = x;
                yPrev = y.Y;
                y1Prev = y.Y1;

            }
            RaisePropertyChanged("ResultTable");
        }

        private void GetCharts()
        {
            NumericalChartData = new ObservableCollection<ChartPoint>();
            NumericalChartDataPhasePortrait = new ObservableCollection<ChartPoint>();

            for (int i = 0; i < ResultTable.Count; i++)
            {
                if (double.IsInfinity(ResultTable[i].V)) break;

                NumericalChartData.Add(new ChartPoint(ResultTable[i].X, ResultTable[i].V));
                NumericalChartDataPhasePortrait.Add(new ChartPoint(ResultTable[i].V, _additionalInfo[i]));
            }

            RaisePropertyChanged("NumericalChartData");
            RaisePropertyChanged("NumericalChartDataPhasePortrait");
        }

        private void GetRes()
        {
            Res = new Result {MaxEle = 0, MaxStep = StepSize, MaxStepX = 0, MinStep = StepSize, MinStepX = 0};

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
