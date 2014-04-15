using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<ChartPoint> ChartData;
        private Random Rand;
        private DateTime CurTime;

        public MainWindow()
        {
            InitializeComponent();
            CurTime = DateTime.Now;
            Rand = new Random();
            ChartData = new ObservableCollection<ChartPoint>
            {
                new ChartPoint{ Value = 10, Time = CurTime + TimeSpan.FromSeconds(10) },
                new ChartPoint{ Value = 20, Time = CurTime + TimeSpan.FromSeconds(20) },
                new ChartPoint{ Value = 30, Time = CurTime + TimeSpan.FromSeconds(30) },
                new ChartPoint{ Value = 10, Time = CurTime + TimeSpan.FromSeconds(40) },
                new ChartPoint{ Value = 40, Time = CurTime + TimeSpan.FromSeconds(50) },
            };
            ChartOne.ItemsSource = ChartData;
        }

        private void btnAddChart_Click(object sender, RoutedEventArgs e)
        {
            LineSeries NewChart = new LineSeries();
            NewChart.ItemsSource = new ObservableCollection<ChartPoint>
            {
                new ChartPoint{ Value = Rand.Next(5,45), Time = CurTime + TimeSpan.FromSeconds(10) },
                new ChartPoint{ Value = Rand.Next(5,45), Time = CurTime + TimeSpan.FromSeconds(20) },
                new ChartPoint{ Value = Rand.Next(5,45), Time = CurTime + TimeSpan.FromSeconds(30) },
                new ChartPoint{ Value = Rand.Next(5,45), Time = CurTime + TimeSpan.FromSeconds(40) },
                new ChartPoint{ Value = Rand.Next(5,45), Time = CurTime + TimeSpan.FromSeconds(50) },
            };
            NewChart.DependentValuePath = "Value";
            NewChart.IndependentValuePath = "Time";
            NewChart.Title = "New Chart!";
            Charts.Series.Add(NewChart);
        }
    }

    public class ChartPoint
    {
        public int Value { get; set; }
        public DateTime Time { get; set; }
    }
}
