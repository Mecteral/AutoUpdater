using System.Windows;
using AutoUpdater.Logic;

namespace AutoUpdaterWpfApplication
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly Updater mUpdater;

        public MainWindow()
        {
            mUpdater = new Updater();
            InitializeComponent();
        }

        void Ok_OnClick(object sender, RoutedEventArgs e)
        {
            mUpdater.Update();
        }

        void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            mUpdater.StartCalculator();
        }
    }
}