using System.ComponentModel;
using System.Windows;
using Demo.Business;
using Demo.Infrastructure;
using Demo.People.Views;
using Prism.Commands;
using Prism.Events;

namespace Demo.People.ViewModels
{
    public class PersonViewModel : ViewModelBase, IPersonViewModel
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IPersonRepository _personRepository;

        private Person _person;

        public PersonViewModel(
            IPersonView view,
            IEventAggregator eventAggregator,
            IPersonRepository personRepository)
            : base(view)
        {
            _eventAggregator = eventAggregator;
            _personRepository = personRepository;

            SaveCommand = new DelegateCommand(Save, CanSave);
            GlobalCommands.SaveAllCommand.RegisterCommand(SaveCommand);
        }

        public DelegateCommand SaveCommand { get; }

        public string ViewName => $"{Person.LastName} {Person.FirstName}";

        public Person Person
        {
            get => _person;
            set
            {
                if (_person != null)
                    _person.PropertyChanged -= Person_PropertyChanged;

                _person = value;
                _person.PropertyChanged += Person_PropertyChanged;

                OnPropertyChanged();
            }
        }

        public void CreatePerson(string firstName, string lastName, int age)
        {
            Person = new Person
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age,
            };
        }

        private void Person_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        private void Save()
        {
            var savedCount = _personRepository.Save(Person);

            // Для демонстрации, что сервис создается только один раз.
            MessageBox.Show(
                $"Saved: {savedCount}", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

            var fullName = $"{Person.LastName}, {Person.FirstName}";
            _eventAggregator.GetEvent<PersonUpdatedEvent>().Publish(fullName);
        }

        private bool CanSave()
        {
            return Person != null && Person.Error == null;
        }
    }
}
