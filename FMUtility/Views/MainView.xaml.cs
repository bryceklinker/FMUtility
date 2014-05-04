using System.Windows;
using FMUtility.ViewModels;

namespace FMUtility.Views
{
    public partial class MainView : Window
    {
        public MainView() : this(new MainViewModel())
        {
            
        }

        public MainView(MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
