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

        public RelayCommand<int> ChangeFunctionCommand { get; set; }

        private void ChangeFunctionCommandExecutor(int selectedItem)
        {
            switch (selectedItem)
            {
                case 0:
                    _function = new MyFunction();
                    break;
                case 1:
                    _function = new FirstOscillatingFunction();
                    break;
                case 2:
                    _function = new SecondOscillatingFunction();
                    break;
            }

            GetRealValue();
            GetChart();
        }

        #endregion

        #region Constructor

        public MainViewModel()
        {
            GettedValue = 0; //TODO change
            ChartData = new ObservableCollection<ChartPoint>();

            GetChart();
            GetRealValue();

            ChangeFunctionCommand = new RelayCommand<int>(ChangeFunctionCommandExecutor);
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
            ChartData.Clear();

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