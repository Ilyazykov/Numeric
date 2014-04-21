using System;
using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
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
        public double Y0 { get; set; }
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
            if (IsFixedStep) GetChartDataWithFixedStep();
            else GetChartData();
            GetFakeTable();
        }

        private DiferentialEquation _equation;

        public TestTaskViewModel()
        {
            Y0 = 1;
            MaximumNumberOfIteration = 10;
            IsFixedStep = true;
            StepSize = 1;
            EpsilonUp = 0.001;
            
            _equation  = new TestTask(Y0);

            СalculationCommandExecutor();

            СalculationCommand = new RelayCommand(СalculationCommandExecutor);
        }

        private void GetChartDataWithFixedStep()
        {
            AnaliticalChartData = new ObservableCollection<ChartPoint>();
            NumericalChartData = new ObservableCollection<ChartPoint>();

            var dx = StepSize;
            double xPrev = 0;
            double yPrev = Y0;
            for (int i = 0; i < MaximumNumberOfIteration; i++)
            {
                double x = xPrev + dx;
                double y = _equation.GetNumericalValue(x, xPrev, yPrev);

                AnaliticalChartData.Add(new ChartPoint(x, _equation.GetAnaliticalValue(x)));
                NumericalChartData.Add(new ChartPoint(x, y));

                xPrev = x;
                yPrev = y;

            }
            RaisePropertyChanged("AnaliticalChartData");
            RaisePropertyChanged("NumericalChartData");
        }

        private void GetChartData()
        {
            AnaliticalChartData = new ObservableCollection<ChartPoint>();
            NumericalChartData = new ObservableCollection<ChartPoint>();

            var dx = StepSize;
            double xPrev = 0;
            double yPrev = Y0;
            for (int i = 0; i < MaximumNumberOfIteration; i++)
            {
                double x = xPrev + dx;
                double y = _equation.GetNumericalValue(x, xPrev, yPrev);

                double x2 = xPrev + dx/2;
                double y2 = _equation.GetNumericalValue(x2, xPrev, yPrev);

                double estimationOfLocalError = Math.Abs(y2 - y)/15;

                if (estimationOfLocalError >= EpsilonUp/32 && estimationOfLocalError < EpsilonUp)
                    { }
                else if (estimationOfLocalError < EpsilonUp/32)
                    { dx *= 2; }
                else
                    { dx /= 2; }

                AnaliticalChartData.Add(new ChartPoint(x, _equation.GetAnaliticalValue(x)));
                NumericalChartData.Add(new ChartPoint(x, y));

                xPrev = x;
                yPrev = y;

            }
            RaisePropertyChanged("AnaliticalChartData");
            RaisePropertyChanged("NumericalChartData");
        }

        private void GetFakeTable()
        {
            /*
            ResultTable = new ObservableCollection<TestTableData>();

            for (int i = 1; i < NumberOfPartitions; i++)
            {
                var temp = new TestTableData();
                temp.X = NumericalChartData[i].X;
                temp.V = NumericalChartData[i].Y;
                //temp.V2 = NumericalChartData[i].Y;
                //temp.ErrorVv2 = temp.V - temp.V2;
                //temp.Ele =
                temp.H = temp.X - AnaliticalChartData[i-1].X;
                //temp.C1
                //temp.C2
                temp.U = AnaliticalChartData[i].Y;
                temp.ErrorUv = temp.V - temp.U;

                ResultTable.Add(temp);
            }

            RaisePropertyChanged("ResultTable");*/
        }
    }
}
