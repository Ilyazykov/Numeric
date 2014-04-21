using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using Lab6.Model;

namespace Lab6.ViewModel
{
    public class SecondTaskViewModel : ViewModelBase
    {
        public ObservableCollection<ChartPoint> ChartData { get; set; }
        public ObservableCollection<MajorTableData> ResultTable { get; set; } 

        public SecondTaskViewModel()
        {
            GetFakeChartData();
            GetFakeTable();
        }

        private void GetFakeChartData()
        {
            ChartData = new ObservableCollection<ChartPoint>();

            ChartData.Add(new ChartPoint(1, 4));
            ChartData.Add(new ChartPoint(2, 1));
            ChartData.Add(new ChartPoint(3, 3));
            ChartData.Add(new ChartPoint(4, 2));

            RaisePropertyChanged("ChartData");
        }

        private void GetFakeTable()
        {
            ResultTable = new ObservableCollection<MajorTableData>();

            ResultTable.Add(new MajorTableData(2, 2, 2, 2, 2, 2, 2, 2));
            ResultTable.Add(new MajorTableData(2, 2, 2, 2, 2, 2, 2, 2));

            RaisePropertyChanged("ResultTable");
        }
    }
}
