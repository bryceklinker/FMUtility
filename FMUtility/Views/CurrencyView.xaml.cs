using System.Windows.Controls;
using FMUtility.ViewModels;

namespace FMUtility.Views
{
    /// <summary>
    /// Interaction logic for CurrencyView.xaml
    /// </summary>
    public partial class CurrencyView : UserControl
    {
        public CurrencyView() : this(new CurrencyViewModel())
        {
        }

        public CurrencyView(CurrencyViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
