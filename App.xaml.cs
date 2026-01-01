using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using WPFBoilerPlate.ViewModels;

namespace WPFBoilerPlate
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public new static App Current => (App)Application.Current;

        public IServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            ServiceProvider = ConfigureService();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private IServiceProvider ConfigureService()
        {
            var services = new ServiceCollection();

            services.AddTransient<MainViewModel>();

            services.AddTransient<MainWindow>();

            return services.BuildServiceProvider();
        }
    }

}
