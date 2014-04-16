using System.Collections.ObjectModel;
using System.Windows.Media.Animation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Lab5.Model;

namespace Lab5.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region Properties

        public ObservableCollection<ChartPoint> ChartData { get; set; }
        public object GettedValue { get; set; }
        public object RealValue { get; set; }

        #endregion

        #region Fields

        private double begin = 0.0;
        private double end = 1.0;
        private IFunction _function = new MyFunction();

        #endregion

        #region Comands

        public RelayCommand MyFunctionCommand { get; set; }
        private void MyFunctionCommandExecutor()
        {
            _function = new MyFunction();

            GetRealValue();
            GetChart();
        }

        public object FirstOscillatingFunctionCommand { get; set; }
        private void FirstOscillatingFunctionCommandExecutor()
        {
            _function = new FirstOscillatingFunction();

            GetRealValue();
            GetChart();
        }

        public object SecondOscillatingFunctionCommand { get; set; }
        private void SecondOscillatingFunctionCommandExecutor()
        {
            _function = new SecondOscillatingFunction();

            GetRealValue();
            GetChart();
        }

        #endregion

        #region Constructor

        public MainViewModel()
        {
            GettedValue = 0; //TODO change

            GetChart();
            GetRealValue();

            MyFunctionCommand = new RelayCommand(MyFunctionCommandExecutor);
            FirstOscillatingFunctionCommand = new RelayCommand(FirstOscillatingFunctionCommandExecutor);
            SecondOscillatingFunctionCommand = new RelayCommand(SecondOscillatingFunctionCommandExecutor);
        }

        #endregion

        #region Common functions

        private void GetRealValue()
        {
            RealValue = _function.IntegrateAnalitical(begin, end);
            RaisePropertyChanged("RealValue");
        }

        private void GetChart()
        {
            ChartData = new ObservableCollection<ChartPoint>();

            var step = (end - begin) / 800;
            for (var x=begin; x<end; x+=step)
            {
                ChartData.Add(new ChartPoint(x, _function.GetValue(x)));
            }

            RaisePropertyChanged("ChartData");
        }

        #endregion
    }
}