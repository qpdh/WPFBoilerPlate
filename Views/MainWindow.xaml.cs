using System.Windows;
using WPFBoilerPlate.ViewModels.Interfaces;

namespace WPFBoilerPlate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is IInitializable vm)
            {
                _ = vm.InitializeAsync(); // await 안 함
            }
        }
    }
}