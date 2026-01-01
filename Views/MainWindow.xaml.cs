using System.Windows;
using WPFBoilerPlate.ViewModels;

namespace WPFBoilerPlate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();

            this.DataContext = viewModel;
        }
    }
}