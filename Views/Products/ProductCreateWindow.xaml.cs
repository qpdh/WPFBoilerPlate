using System.Windows;
using WPFBoilerPlate.ViewModels.Interfaces;

namespace WPFBoilerPlate.Views
{
    /// <summary>
    /// ProductCreateWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ProductCreateWindow : Window
    {
        public ProductCreateWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is IInitializable vm)
            {
                _ = vm.InitializeAsync();
            }
        }
    }
}