using Demo.Infrastructure;
using Demo.People.ViewModels;
using Demo.People.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Demo.People
{
    public class PeopleModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            var vm = containerProvider.Resolve<IPeopleViewModel>();
            regionManager.AddToRegion(RegionNames.ContentRegion, vm.View);

            regionManager.RegisterViewWithRegion(RegionNames.PersonDetailsRegion, typeof(PersonDetailsView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IPeopleViewModel, PeopleViewModel>();
            containerRegistry.Register<IPeopleView, PeopleView>();

            containerRegistry.Register<IPersonDetailsViewModel, PersonDetailsViewModel>();
            containerRegistry.Register<IPersonDetailsView, PersonDetailsView>();
        }
    }
}
