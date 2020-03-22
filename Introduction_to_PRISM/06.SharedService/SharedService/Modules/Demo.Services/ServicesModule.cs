using Demo.Infrastructure;
using Prism.Ioc;
using Prism.Modularity;

namespace Demo.Services
{
    public class ServicesModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IPersonRepository, PersonRepository>();
        }
    }
}
