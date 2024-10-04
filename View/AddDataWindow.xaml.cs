using DemoProject.ViewModel;
using Microsoft.Windows.Themes;
using System.Windows;

namespace DemoProject.View
{
    /// <summary>
    /// Interaction logic for AddDataWindow.xaml
    /// </summary>
    public partial class AddDataWindow : Window
    {
        public AddDataWindow()
        {
            InitializeComponent();
            AddDataWindowViewModel vm = new AddDataWindowViewModel();
            DataContext = vm;
        }
    }
}
