using Demo.Infrastructure;
using ModuleA.ViewModels;
using ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();

            var vm = containerProvider.Resolve<IContentAViewModel>();
            regionManager.AddToRegion(RegionNames.ContentRegion, vm.View);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IContentAViewModel, ContentAViewModel>();
            containerRegistry.Register<IContentAView, ContentAView>();
        }
    }
}
