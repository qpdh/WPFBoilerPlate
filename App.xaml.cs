using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WPFBoilerPlate.Models;
using WPFBoilerPlate.Repositories;
using WPFBoilerPlate.Repositories.Interfaces;
using WPFBoilerPlate.Services;
using WPFBoilerPlate.Services.Interfaces;
using WPFBoilerPlate.Utils;
using WPFBoilerPlate.ViewModels;
using WPFBoilerPlate.Views;

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

            var db = ServiceProvider.GetRequiredService<AppDBContext>();
            db.Database.Migrate();

#if DEBUG
            DebugDataSeeder.Seed(db);
#endif
            var windowService = ServiceProvider.GetRequiredService<IWindowService>();
            windowService.ShowWindow<MainWindow, MainViewModel>();
        }

        private IServiceProvider ConfigureService()
        {
            var services = new ServiceCollection();

            // Utils
            services.AddSingleton<AppDBContext>();

            // Repositories
            services.AddSingleton<IBaseRepository<Category>, CategoryRepository>();
            services.AddSingleton<IBaseRepository<Product>, ProductRepository>();

            // Services
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<ICategoryService, CategoryService>();
            services.AddSingleton<IWindowService, WindowService>();

            // ViewModels
            services.AddTransient<MainViewModel>();
            services.AddTransient<ProductViewModel>();
            services.AddTransient<ProductCreateViewModel>();

            // Views
            services.AddTransient<MainWindow>();
            services.AddTransient<ProductWindow>();
            services.AddTransient<ProductCreateWindow>();

            return services.BuildServiceProvider();
        }
    }

}

