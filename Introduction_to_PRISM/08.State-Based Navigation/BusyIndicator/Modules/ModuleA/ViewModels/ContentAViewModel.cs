using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Demo.Business;
using Demo.Infrastructure;
using Demo.Infrastructure.Services;
using ModuleA.Views;

namespace ModuleA.ViewModels
{
    public class ContentAViewModel : ViewModelBase, IContentAViewModel
    {
        private readonly IPersonService _personService;
        private ObservableCollection<Person> _people;

        public ContentAViewModel(IContentAView view, IPersonService personService)
            : base(view)
        {
            _personService = personService;
        }

        public ObservableCollection<Person> People
        {
            get => _people;
            private set
            {
                _people = value;
                OnPropertyChanged();
            }
        }

        public async Task LoadPeople()
        {
            var people = await _personService.GetPeopleAsync();
            People = new ObservableCollection<Person>(people);
        }
    }
}
