using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using Lab6.Model;

namespace Lab6.ViewModel
{
    public class FirstTaskViewModel : ViewModelBase
    {
        public ObservableCollection<ChartPoint> ChartData { get; set; }
        public ObservableCollection<MajorTableData> ResultTable { get; set; } 

        public FirstTaskViewModel()
        {
            GetFakeChartData();
            GetFakeTable();
        }

        private void GetFakeChartData()
        {
            ChartData = new ObservableCollection<ChartPoint>();

            ChartData.Add(new ChartPoint(1, 1));
            ChartData.Add(new ChartPoint(2, 4));
            ChartData.Add(new ChartPoint(3, 1));
            ChartData.Add(new ChartPoint(4, 4));

            RaisePropertyChanged("AnaliticalChartData");
        }

        private void GetFakeTable()
        {
            ResultTable = new ObservableCollection<MajorTableData>();

            ResultTable.Add(new MajorTableData(1, 1, 1, 1, 1, 1, 1, 1));
            ResultTable.Add(new MajorTableData(2, 2, 2, 2, 2, 2, 2, 2));

            RaisePropertyChanged("ResultTable");
        }
    }
}
