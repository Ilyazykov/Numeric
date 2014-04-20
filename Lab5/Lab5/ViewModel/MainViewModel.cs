using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Lab5.Model;
using Lab5.Model.Integrating;

namespace Lab5.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region Constructor

        public MainViewModel()
        {
            _beginFunction = new MyFunction();
            _function = new RectanleMethod(_beginFunction);

            NumberOfPartitions = 300;
            GetValues(200);

            MyFunctionCommand = new RelayCommand(MyFunctionCommandExecutor);
            FirstOscillatingFunctionCommand = new RelayCommand(FirstOscillatingFunctionCommandExecutor);
            SecondOscillatingFunctionCommand = new RelayCommand(SecondOscillatingFunctionCommandExecutor);

            RectangleCommand = new RelayCommand(RectangleCommandExecutor);
            TrapezoidalCommand = new RelayCommand(TrapezoidalCommandExecutor);
            SimpsonsCommand = new RelayCommand(SimpsonsCommandExecutor);
        }

        #endregion

        #region FirstTask

        #region Properties

        public ObservableCollection<ChartPoint> ChartData { get; set; }

        private double _gettedValue;
        public double GettedValue
        {
            get { return _gettedValue; }
            set
            {
                _gettedValue = value; 
                RaisePropertyChanged("Error");
            }
        }

        public double RealValue { get; set; }

        private int _numberOfPartitions;
        public int NumberOfPartitions
        {
            get { return _numberOfPartitions; }
            set
            {
                _numberOfPartitions = value;
                GetNumericalValue();
                RaisePropertyChanged("NumberOfPartitions");
            }
        }

        public object Error
        {
            get { return Math.Abs(GettedValue - RealValue); }
        }

        #endregion

        #region Fields

        private double begin = 0.0;
        private double end = 1.0;
        private Function _beginFunction;
        private Function _function;
        

        public Function ChangeFunction
        {
            set
            {
                _beginFunction = value;
                _function.ChangeFunction(value);
                GetValues();
            }
        }

        #endregion

        #region Commands

        public RelayCommand MyFunctionCommand { get; set; }
        private void MyFunctionCommandExecutor()
        {
            ChangeFunction = new MyFunction();
        }

        public object FirstOscillatingFunctionCommand { get; set; }
        private void FirstOscillatingFunctionCommandExecutor()
        {
            ChangeFunction = new FirstOscillatingFunction();
        }

        public object SecondOscillatingFunctionCommand { get; set; }
        private void SecondOscillatingFunctionCommandExecutor()
        {
            ChangeFunction = new SecondOscillatingFunction();
        }

        public RelayCommand RectangleCommand { get; set; }
        private void RectangleCommandExecutor()
        {
            _function = new RectanleMethod(_beginFunction);

            GetRealValue();
            GetNumericalValue();
        }

        public RelayCommand TrapezoidalCommand { get; set; }
        private void TrapezoidalCommandExecutor()
        {
            _function = new TrapezoidalMethod(_beginFunction);

            GetRealValue();
            GetNumericalValue();
        }

        public RelayCommand SimpsonsCommand { get; set; }

        private void SimpsonsCommandExecutor()
        {
            _function = new SimpsonsMethod(_beginFunction);

            GetRealValue();
            GetNumericalValue();
        }

        #endregion

        #region Common functions

        private void GetValues(int stepNumber = 400)
        {
            GetChart(stepNumber);
            GetRealValue();
            GetNumericalValue();
        }

        private void GetRealValue()
        {
            RealValue = _function.IntegrateAnalitical(begin, end);
            RaisePropertyChanged("RealValue");
        }

        private void GetNumericalValue()
        {
            GettedValue = _function.IntegrateNumerical(begin, end, NumberOfPartitions);
            RaisePropertyChanged("GettedValue");
        }

        private void GetChart(int stepNumber)
        {
            ChartData = new ObservableCollection<ChartPoint>();

            var dx = (end - begin) / stepNumber;
            for (int i=0; i<stepNumber; i++)
            {
                double x = begin + i*dx;
                ChartData.Add(new ChartPoint(x, _function.GetValue(x)));
            }
            ChartData.Add(new ChartPoint(end, _function.GetValue(end)));

            RaisePropertyChanged("ChartData");
        }



        #endregion

        #endregion

        #region SecondTask



        #endregion
    }
}