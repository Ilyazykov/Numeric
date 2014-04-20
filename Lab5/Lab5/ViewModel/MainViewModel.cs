using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Lab5.Model;

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

        #endregion

        #region Fields

        private double begin = 0.0;
        private double end = 1.0;
        private Function _function = new MyFunction();
         

        #endregion

        #region Comands

        public RelayCommand MyFunctionCommand { get; set; }
        private void MyFunctionCommandExecutor()
        {
            _function = new MyFunction();
            GetValues();
        }

        public object FirstOscillatingFunctionCommand { get; set; }
        private void FirstOscillatingFunctionCommandExecutor()
        {
            _function = new FirstOscillatingFunction();
            GetValues();
        }

        public object SecondOscillatingFunctionCommand { get; set; }

        private void SecondOscillatingFunctionCommandExecutor()
        {
            _function = new SecondOscillatingFunction();
            GetValues();
        }

        #endregion

        #region Constructor

        public MainViewModel()
        {
            GettedValueRectangles = 0; //TODO change

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
            GettedValueRectangles = _function.IntegrateNumericallyRectangles(begin, end);
            RaisePropertyChanged("GettedValueRectangles");
        }

        private void GetNumericalTrapezoidal()
        {
            GettedValueTrapezoidal = _function.IntegrateNumericallyTrapezoidal(begin, end);
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