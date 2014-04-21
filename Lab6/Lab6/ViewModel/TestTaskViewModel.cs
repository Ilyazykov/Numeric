using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using Lab6.Model;

namespace Lab6.ViewModel
{
    public class TestTaskViewModel : ViewModelBase
    {
        public ObservableCollection<ChartPoint> ChartData { get; set; }
        public ObservableCollection<TestTableData> ResultTable { get; set; }

        public TestTaskViewModel()
        {
            GetFakeChartData();
            GetFakeTable();
        }

        private void GetFakeChartData()
        {
            ChartData = new ObservableCollection<ChartPoint>();

            ChartData.Add(new ChartPoint(1, 1));
            ChartData.Add(new ChartPoint(2, 2));
            ChartData.Add(new ChartPoint(3, 3));
            ChartData.Add(new ChartPoint(4, 4));

            RaisePropertyChanged("ChartData");
        }

        private void GetFakeTable()
        {
            ResultTable = new ObservableCollection<TestTableData>();

            ResultTable.Add(new TestTableData(1, 1, 1, 1, 1, 1, 1, 1, 1, 1));
            ResultTable.Add(new TestTableData(1, 1, 1, 1, 1, 1, 1, 1, 1, 1));

            RaisePropertyChanged("ResultTable");
        }
    }
}
