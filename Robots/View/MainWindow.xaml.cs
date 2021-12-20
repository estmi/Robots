using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Robots.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel.ViewModelClass viewModelClass = new();
        public MainWindow()
        {
            InitializeComponent();
            grd.Children.Add(viewModelClass.esc);
            Grid.SetRow(viewModelClass.esc, 0);
            Grid.SetColumn(viewModelClass.esc, 1);
        }
    }
}
