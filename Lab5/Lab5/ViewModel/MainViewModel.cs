using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using Lab5.Model;

namespace Lab5.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public string Title = "test";
        public ObservableCollection<ChartPoint> ChartData;

        public MainViewModel()
        {
            Title = "test";

            ChartData = new ObservableCollection<ChartPoint>
            {
                new ChartPoint(1,2),
                new ChartPoint(2,3),
                new ChartPoint(3,2),
            };
        }
    }
}