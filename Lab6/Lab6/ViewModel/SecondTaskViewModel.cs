using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using Lab6.Model;

namespace Lab6.ViewModel
{
    public class SecondTaskViewModel : ViewModelBase
    {
        public ObservableCollection<ChartPoint> ChartData { get; set; }

        public SecondTaskViewModel()
        {
            ChartData = new ObservableCollection<ChartPoint>();

            ChartData.Add(new ChartPoint(1, 4));
            ChartData.Add(new ChartPoint(2, 3));
            ChartData.Add(new ChartPoint(3, 2));
            ChartData.Add(new ChartPoint(4, 1));
        }
    }
}
