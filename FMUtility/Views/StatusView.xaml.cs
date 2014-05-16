using System.Windows.Controls;
using FMUtility.ViewModels;

namespace FMUtility.Views
{
    /// <summary>
    ///     Interaction logic for StatusView.xaml
    /// </summary>
    public partial class StatusView : UserControl
    {
        public StatusView() : this(new StatusViewModel())
        {
        }

        public StatusView(StatusViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}