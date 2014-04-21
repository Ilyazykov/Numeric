using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using Lab6.Model;

namespace Lab6.ViewModel
{
    public class TestTaskViewModel : ViewModelBase
    {
        public ObservableCollection<ChartPoint> ChartData { get; set; }

        public TestTaskViewModel()
        {
            ChartData = new ObservableCollection<ChartPoint>();

            ChartData.Add(new ChartPoint(1, 1));
            ChartData.Add(new ChartPoint(2, 2));
            ChartData.Add(new ChartPoint(3, 3));
            ChartData.Add(new ChartPoint(4, 4));
        }
    }
}
