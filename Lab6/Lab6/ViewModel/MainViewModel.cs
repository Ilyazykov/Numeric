using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using Lab6.Model;

namespace Lab6.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<ChartPoint> ChartData { get; set; } 

        public MainViewModel()
        {
            ChartData = new ObservableCollection<ChartPoint>();

            ChartData.Add(new ChartPoint(1,1));
            ChartData.Add(new ChartPoint(2,3));
            ChartData.Add(new ChartPoint(3,2));
        }
    }
}