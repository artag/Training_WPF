using Demo.Infrastructure.Services;
using Prism.Ioc;
using Prism.Modularity;

namespace Demo.PersonService
{
    public class PersonServiceModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IPersonService, PersonService>();
        }
    }
}
