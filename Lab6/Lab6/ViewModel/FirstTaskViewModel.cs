using System;
using System.Collections.ObjectModel;
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
                    else if (estimationOfLocalError > EpsilonUp)
                    {
                        dx /= 2;
                        c1++;
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

            for (int i = 0; i < MaximumNumberOfIteration; i++)
            {
                if (double.IsInfinity(ResultTable[i].V)) break;

                NumericalChartData.Add(new ChartPoint(ResultTable[i].X, ResultTable[i].V));
            }

            RaisePropertyChanged("NumericalChartData");
        }
    }
}
