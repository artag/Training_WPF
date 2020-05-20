using Demo.Infrastructure;
using ModuleB.Navigation;
using ModuleB.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ModuleB
{
    public class ModuleBModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion(RegionNames.ToolbarRegion, typeof(ViewBButton));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Такой вид регистрации View не позволяет выполнить навигацию
            // containerRegistry.Register<ViewB>();

            // Можно регистрировать View для навигации или так:
            // containerRegistry.Register<object, ViewB>(typeof(ViewB).FullName);

            // Или с использованием самописного метода расширения RegisterTypeForNavigation
            // (через контейнер):
            // container.RegisterTypeForNavigation<ViewB>();

            // Или так:
            containerRegistry.RegisterForNavigation<ViewB>(typeof(ViewB).FullName);
        }
    }
}
