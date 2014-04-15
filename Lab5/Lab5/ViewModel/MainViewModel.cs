using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using Lab5.Model;

namespace Lab5.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<ChartPoint> ChartData { get; set; }
        public object gettedValue { get; set; }
        public object realValue { get; set; }

        public MainViewModel()
        {
            gettedValue = 10;
            realValue = 10;

            ChartData = new ObservableCollection<ChartPoint>
            {
                new ChartPoint(1,2),
                new ChartPoint(2,3),
                new ChartPoint(3,2),
            };
        }
    }
}