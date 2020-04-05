using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Demo.Business;
using Demo.Infrastructure;
using Demo.Infrastructure.Services;
using ModuleA.Views;
using Prism.Commands;
using Xceed.Wpf.Toolkit;

namespace ModuleA.ViewModels
{
    public class ContentAViewModel : ViewModelBase, IContentAViewModel
    {
        private readonly IPersonService _personService;
        private ObservableCollection<Person> _people;
        private bool _isBusy;
        private Person selectedPerson;
        private WindowState windowState;

        public ContentAViewModel(IContentAView view, IPersonService personService)
            : base(view)
        {
            _personService = personService;

            EditPersonCommand = new DelegateCommand(EditPerson, CanEditPerson);
        }

        public DelegateCommand EditPersonCommand { get; }

        public ObservableCollection<Person> People
        {
            get => _people;
            private set
            {
                _people = value;
                OnPropertyChanged();
            }
        }

        public Person SelectedPerson
        {
            get => selectedPerson;
            set
            {
                selectedPerson = value;
                EditPersonCommand.RaiseCanExecuteChanged();
                OnPropertyChanged();
            }
        }

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public async Task LoadPeople()
        {
            IsBusy = true;
            var people = await _personService.GetPeopleAsync();
            IsBusy = false;

            People = new ObservableCollection<Person>(people);
        }

        public WindowState WindowState
        {
            get => windowState;
            set
            {
                windowState = value;
                OnPropertyChanged();
            }
        }

        private void EditPerson()
        {
            WindowState = WindowState.Open;
        }

        private bool CanEditPerson()
        {
            return SelectedPerson != null;
        }
    }
}
