using System.Windows.Controls;
using Demo.Business;
using Demo.Infrastructure;
using Demo.People.ViewModels;
using Prism.Common;
using Prism.Regions;

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

            RegionContext.GetObservableContext(this).PropertyChanged += (sender, args) =>
            {
                var context = (ObservableObject<object>)sender;
                var selectedPerson = (Person)context.Value;
                (ViewModel as IPersonDetailsViewModel).SelectedPerson = selectedPerson;
            };
        }

        public IViewModel ViewModel
        {
            get => (IPersonDetailsViewModel)DataContext;
            set => DataContext = value;
        }
    }
}
