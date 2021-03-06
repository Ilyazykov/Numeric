﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Lab6.Model;
using Lab6.Model.DifferentialEquation;

namespace Lab6.ViewModel
{
    public class FirstTaskViewModel : ViewModelBase
    {
        public ObservableCollection<ChartPoint> NumericalChartData { get; set; }
        public ObservableCollection<MajorTableData> ResultTable { get; set; }
        public Result Res { get; set; }

        public double RightBorder { get; set; }

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

        public FirstTaskViewModel()
        {
            _equation = new FirstTask(1);

            Y0 = 1;
            MaximumNumberOfIteration = 10;
            IsFixedStep = false;
            StepSize = 0.1;
            EpsilonUp = 0.001;

            RightBorder = 1;

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
            ResultTable.Add(new MajorTableData(0, Y0, Y0, 0, 0, dx, 0, 0));

            for (int i = 1; i < MaximumNumberOfIteration; i++)
            {
                double x = xPrev + dx;
                if (x > RightBorder) break;
                double y = _equation.GetNumericalValue(x, xPrev, yPrev);

                double x2 = xPrev + dx / 2;
                double y2 = _equation.GetNumericalValue(x2, xPrev, yPrev);
                y2 = _equation.GetNumericalValue(x, x2, y2);

                double estimationOfLocalError = Math.Abs(y2 - y) / 15;

                if (!IsFixedStep)
                {
                    if (estimationOfLocalError < EpsilonUp / 32)
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

                ResultTable.Add(new MajorTableData(x, y, y2, Math.Abs(y - y2), estimationOfLocalError, dx, c1, c2));

                xPrev = x;
                yPrev = y;

            }
            RaisePropertyChanged("ResultTable");
        }

        private void GetCharts()
        {
            NumericalChartData = new ObservableCollection<ChartPoint>();
            
            foreach (MajorTableData t in ResultTable)
            {
                if (double.IsInfinity(t.V)) break;

                NumericalChartData.Add(new ChartPoint(t.X, t.V));
            }

            RaisePropertyChanged("NumericalChartData");
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
