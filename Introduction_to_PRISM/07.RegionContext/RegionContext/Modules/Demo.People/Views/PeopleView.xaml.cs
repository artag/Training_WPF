using Demo.Infrastructure;
using System.Windows.Controls;
using Demo.People.ViewModels;

namespace Demo.People.Views
{
    /// <summary>
    /// Interaction logic for PeopleView.xaml
    /// </summary>
    public partial class PeopleView : UserControl, IPeopleView
    {
        public PeopleView()
        {
            InitializeComponent();
        }

        public IViewModel ViewModel
        {
            get => (IPeopleViewModel)DataContext;
            set => DataContext = value;
        }
    }
}
