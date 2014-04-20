using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Lab5.Model;
using Lab5.Model.Integrating;

namespace Lab5.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region Properties

        public ObservableCollection<ChartPoint> ChartData { get; set; }
        public object GettedValueRectangles { get; set; }
        public object GettedValueTrapezoidal { get; set; }
        public object GettedValueSimpsons { get; set; }
        public object RealValue { get; set; }

        private int _numberOfPartitions;
        public int NumberOfPartitions
        {
            get { return _numberOfPartitions; }
            set
            {
                _numberOfPartitions = value;
                RaisePropertyChanged("NumberOfPartitions");
            }
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

        #region Comands

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

        #endregion

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
        }

        #endregion

        #region Common functions

        private void GetValues(int stepNumber = 400)
        {
            GetChart(stepNumber);
            GetRealValue();
            GetNumericalRectanglesValue();
            GetNumericalTrapezoidal();
            GetNumericalSimpsons();
        }

        private void GetNumericalSimpsons()
        {
            GettedValueSimpsons = 0;
            //TODO
        }

        private void GetRealValue()
        {
            RealValue = _function.IntegrateAnalitical(begin, end);
            RaisePropertyChanged("RealValue");
        }

        private void GetNumericalRectanglesValue()
        {
            GettedValueRectangles = _function.IntegrateNumerical(begin, end, NumberOfPartitions);
            RaisePropertyChanged("GettedValueRectangles");
        }

        private void GetNumericalTrapezoidal()
        {
            //GettedValueTrapezoidal = _function.IntegrateNumericallyTrapezoidal(begin, end);
            RaisePropertyChanged("GettedValueTrapezoidal");
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
    }
}