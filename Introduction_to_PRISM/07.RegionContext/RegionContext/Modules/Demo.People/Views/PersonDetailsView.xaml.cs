using System.Windows.Controls;
using Demo.Infrastructure;
using Demo.People.ViewModels;

namespace Demo.People.Views
{
    /// <summary>
    /// Interaction logic for PersonDetailsView.xaml
    /// </summary>
    public partial class PersonDetailsView : UserControl, IPersonDetailsView
    {
        public PersonDetailsView(IPersonDetailsViewModel viewModel)
        {
            InitializeComponent();

            ViewModel = viewModel;
            ViewModel.View = this;
        }

        public IViewModel ViewModel
        {
            get => (IPersonDetailsViewModel)DataContext;
            set => DataContext = value;
        }
    }
}
