using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using Lab6.Model;

namespace Lab6.ViewModel
{
    public class FirstTaskViewModel : ViewModelBase
    {
        public ObservableCollection<ChartPoint> ChartData { get; set; }

        public FirstTaskViewModel()
        {
            ChartData = new ObservableCollection<ChartPoint>();

            ChartData.Add(new ChartPoint(1, 4));
            ChartData.Add(new ChartPoint(2, 1));
            ChartData.Add(new ChartPoint(3, 2));
            ChartData.Add(new ChartPoint(4, 4));
        }
    }
}
