using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using System.Windows;
using System.Windows.Media;

namespace OxyplotCrosshair
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// View Model Instance
        /// </summary>
        private readonly MainWindowViewModel _viewModel;

        private OxyPlot.Wpf.LineAnnotation crosshair_v;
        private OxyPlot.Wpf.LineAnnotation crosshair_h;

        public MainWindow()
        {
            InitializeComponent();

            _viewModel = new MainWindowViewModel();
            this.DataContext = _viewModel;

            InitializeCrossHair();
            BindMouseClick();
        }

        private void InitializeCrossHair()
        {
            // Add Cross hair to each plot
            crosshair_v = new OxyPlot.Wpf.LineAnnotation
            {
                Type = LineAnnotationType.Vertical,
                Color = Color.FromRgb(135, 206, 250),
                StrokeThickness = 1.05,
                LineStyle = LineStyle.Solid,
                X = 0.5,
                Y = 0
            };
            crosshair_h = new OxyPlot.Wpf.LineAnnotation
            {
                Type = LineAnnotationType.Horizontal,
                Color = Color.FromRgb(135, 206, 250),
                StrokeThickness = 1.05,
                LineStyle = LineStyle.Solid,
                X = 0,
                Y = 0.5
            };
            CrossHairPlot.Annotations.Add(crosshair_v);
            CrossHairPlot.Annotations.Add(crosshair_h);
        }

        private void BindMouseClick()
        {
            var controller = CrossHairPlot.ActualController;
            var handleClick = new DelegatePlotCommand<OxyMouseDownEventArgs>(
                (v, c, e) =>
                {
                    var args = new HitTestArguments(e.Position, 0);

                    Axis yAxis = CrossHairPlot.ActualModel.Axes[1];
                    DataPoint dataPoint = CrossHairPlot.ActualModel.DefaultXAxis.InverseTransform(args.Point.X, args.Point.Y, yAxis);

                    // Update cross hair position according to new click
                    crosshair_v.X = dataPoint.X;
                    crosshair_v.Y = 0;
                    crosshair_h.X = 0;
                    crosshair_h.Y = dataPoint.Y;
                    CrossHairPlot.InvalidatePlot(false);

                    e.Handled = true;
                });
            controller.Bind(new OxyMouseDownGesture(OxyMouseButton.Left), handleClick);
        }        
    }
}
