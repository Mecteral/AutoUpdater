using System.Windows;
using AutoUpdater.Logic;

namespace AutoUpdaterWpfApplication
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        void Application_Startup(object sender, StartupEventArgs e)
        {
            var versionChecker = new VersionChecker();
            try
            {
                versionChecker.GetVersionFromUpdateServer();
                var mainWindow = new MainWindow();
                mainWindow.Show();
            }
            catch 
            {
                var updater = new Updater();
                updater.StartCalculator();
            }
        }
    }
}