using System.Threading.Tasks;
using Demo.Infrastructure;

namespace ModuleA.ViewModels
{
    public interface IContentAViewModel : IViewModel
    {
        Task LoadPeople();
    }
}
