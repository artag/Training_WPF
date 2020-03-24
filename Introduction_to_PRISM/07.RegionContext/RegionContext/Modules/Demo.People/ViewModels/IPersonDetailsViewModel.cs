using Demo.Business;
using Demo.Infrastructure;

namespace Demo.People.ViewModels
{
    public interface IPersonDetailsViewModel : IViewModel
    {
        Person SelectedPerson { get; set; }
    }
}
