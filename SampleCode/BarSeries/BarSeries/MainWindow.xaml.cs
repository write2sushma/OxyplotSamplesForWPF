namespace BarSeries
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        /// <summary>
        /// The view model.
        /// </summary>
        private readonly MainWindowViewModel _viewModel = new MainWindowViewModel();

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
            this.DataContext = this._viewModel;
        }
    }
}
