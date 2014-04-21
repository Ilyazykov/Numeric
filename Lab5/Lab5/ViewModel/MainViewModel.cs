using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Lab5.Model;
using Lab5.Model.Functions;
using Lab5.Model.Integrating;

namespace Lab5.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region Constructor

        public MainViewModel()
        {
            //First
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

            //Second
            _terribleFunction = new GeneratedFunctions();
            _numericFunction = new RectanleMethod(_terribleFunction);
            _quadrature = new AdaptiveQuadrature(_numericFunction);
            FillInTheTable();

            GenerateFunctionCommand = new RelayCommand(GenerateFunctionCommandExecutor);

            SecondRectangleCommand = new RelayCommand(SecondRectangleCommandExecutor);
            SecondTrapezoidalCommand = new RelayCommand(SecondTrapezoidalCommandExecutor);
            SecondSimpsonsCommand = new RelayCommand(SecondSimpsonsCommandExecutor);
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

        #region Fields

        private GeneratedFunctions _terribleFunction;
        private Function _numericFunction;
        private AdaptiveQuadrature _quadrature;
        private int _functionPartitions = 10;
        public int FunctionPartitions
        {
            get { return _functionPartitions; }
            set
            {
                _functionPartitions = value;
                RaisePropertyChanged("FunctionPartitions");
            }
        }

        private int _numberOfPointsTerribleFunction = 10;
        public int NumberOfPointsTerribleFunction
        {
            get { return _numberOfPointsTerribleFunction; }
            set
            {
                _numberOfPointsTerribleFunction = value;
                RaisePropertyChanged("NumberOfPointsTerribleFunction");
            }
        }

        private double _eps = 0.001;
        public double Eps
        {
            get { return _eps; }
            set
            {
                _eps = value;
                RaisePropertyChanged("Eps");
            }
        }

        #endregion

        #region Properties

        

        public ObservableCollection<DataForTable> Table { get; set; }
        public double Alpha { get; set; }

        public ObservableCollection<ChartPoint> ChartTerribleFunction { get; set; }

        #endregion

        #region Commands

        public RelayCommand GenerateFunctionCommand { get; set; }
        private void GenerateFunctionCommandExecutor()
        {
            _terribleFunction = new GeneratedFunctions();
            FillInTheTable();
        }

        public RelayCommand SecondRectangleCommand { get; set; }
        private void SecondRectangleCommandExecutor()
        {
            _numericFunction = new RectanleMethod(_terribleFunction);
            _quadrature = new AdaptiveQuadrature(_numericFunction);
            GetTerribleChart(NumberOfPointsTerribleFunction);
        }

        public RelayCommand SecondTrapezoidalCommand { get; set; }
        private void SecondTrapezoidalCommandExecutor()
        {
            _numericFunction = new TrapezoidalMethod(_terribleFunction);
            _quadrature = new AdaptiveQuadrature(_numericFunction);
            GetTerribleChart(NumberOfPointsTerribleFunction);
        }

        public RelayCommand SecondSimpsonsCommand { get; set; }

        private void SecondSimpsonsCommandExecutor()
        {
            _numericFunction = new SimpsonsMethod(_terribleFunction);
            _quadrature = new AdaptiveQuadrature(_numericFunction);
            GetTerribleChart(NumberOfPointsTerribleFunction);
        }

        #endregion

        #region Common functions

        void FillInTheTable()
        {
            Table = new ObservableCollection<DataForTable>();
            for (int i = 0; i < 14; i++)
            {
                var temp = new DataForTable(_terribleFunction.A[i], _terribleFunction.B[i]);
                Table.Add(temp);
            }
            Alpha = _terribleFunction.Alpha;
            RaisePropertyChanged("Alpha");
            RaisePropertyChanged("Table");
        }

        private void GetTerribleChart(int stepNumber)
        {
            ChartTerribleFunction = new ObservableCollection<ChartPoint>();

            var dx = (end - begin) / stepNumber;
            for (int i = 0; i < stepNumber; i++)
            {
                int numberOfCalls = 0;

                double x = begin + i * dx;
                _quadrature.X = x;
                double y = _quadrature.GetValue(-Math.PI/2, Math.PI/2, Eps, FunctionPartitions, ref numberOfCalls);
                ChartTerribleFunction.Add(new ChartPoint(x, y));
            }
            //ChartData.Add(new ChartPoint(end, _function.GetValue(end)));

            RaisePropertyChanged("ChartTerribleFunction");
        }

        #endregion

        #endregion
    }
}