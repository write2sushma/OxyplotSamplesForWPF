using System.Collections.Generic;
using System.Windows;
using OxyPlot;
using OxyPlot.Axes;

namespace LogarithmicAxis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var largeDataPoints = new List<DataPoint>
            {
                new DataPoint(410.8070281, 4943000.0000000),
                new DataPoint(432.7935746, 5041000.0000000),
                new DataPoint(436.8319199, 5059000.0000000),
                new DataPoint(9918.193582, 47320000.0000000),
                new DataPoint(10099.91912, 48130000.0000000),
                new DataPoint(10216.58243, 48650000.0000000),
                new DataPoint(104904.5616, 470700000.0000000),
                new DataPoint(107282.6983, 481300000.0000000),
                new DataPoint(108337.1551, 486000000.0000000),
                new DataPoint(991388.6853, 4422000128.0000000),
                new DataPoint(1000362.786, 4462000128.0000000),
                new DataPoint(1006195.923, 4488000000)
            };

            var logAxisX = new OxyPlot.Axes.LogarithmicAxis() { Position = AxisPosition.Bottom, Title = "Log(x)", UseSuperExponentialFormat = false, Base = 10 };
            var linearAxisY = new LinearAxis() { Position = AxisPosition.Left, Title = "Y", UseSuperExponentialFormat = false };

            PlotModel chartPlot = new PlotModel(); 

            chartPlot.Axes.Add(linearAxisY);
            chartPlot.Axes.Add(logAxisX);

            var lineSeriesLargeData = new OxyPlot.Series.LineSeries();
            lineSeriesLargeData.Points.AddRange(largeDataPoints);

            chartPlot.Series.Clear();
            chartPlot.Annotations.Clear();
            chartPlot.Series.Add(lineSeriesLargeData);

            // Set the Plot Model
            PlotView1.Model = chartPlot;
        }
    }
}
