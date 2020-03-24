using System.Collections.ObjectModel;
using Demo.Business;
using Demo.Infrastructure;
using Demo.People.Views;

namespace Demo.People.ViewModels
{
    public class PeopleViewModel : ViewModelBase, IPeopleViewModel
    {
        public PeopleViewModel(IPeopleView view) : base(view)
        {
            CreatePeoples();
        }

        public ObservableCollection<Person> Peoples { get; } = new ObservableCollection<Person>();

        public void CreatePeoples()
        {
            for (int i = 0; i < 10; i++)
            {
                Peoples.Add(new Person
                {
                    FirstName = $"First {i}",
                    LastName = $"Last {i}"
                });
            }
        }
    }
}
