using Demo.Business;
using Demo.Infrastructure;

namespace Demo.People.ViewModels
{
    public class PersonDetailsViewModel : ViewModelBase, IPersonDetailsViewModel
    {
        private Person _selectedPerson;

        public PersonDetailsViewModel()
        {
        }

        public Person SelectedPerson
        {
            get => _selectedPerson;
            set
            {
                _selectedPerson = value;
                OnPropertyChanged();
            }
        }
    }
}
