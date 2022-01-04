using Robots.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace Robots.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModelClass viewModelClass = new();
        public MainWindow()
        {
            InitializeComponent();
            grd.Children.Add(viewModelClass.Esc);
            Grid.SetRow(viewModelClass.Esc, 0);
            Grid.SetColumn(viewModelClass.Esc, 1);
        }
    }
}
