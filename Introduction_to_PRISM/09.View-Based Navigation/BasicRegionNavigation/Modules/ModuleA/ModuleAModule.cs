using Demo.Infrastructure;
using ModuleA.Navigation;
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
            regionManager.RegisterViewWithRegion(RegionNames.ToolbarRegion, typeof(ViewAButton));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Такой вид регистрации View не позволяет выполнить навигацию
            // containerRegistry.Register<ViewA>();

            // Можно регистрировать View для навигации или так:
            // containerRegistry.Register<object, ViewA>(typeof(ViewA).FullName);

            // Или с использованием самописного метода расширения RegisterTypeForNavigation
            // (через контейнер):
            // container.RegisterTypeForNavigation<ViewA>();

            // Или так:
            containerRegistry.RegisterForNavigation<ViewA>(typeof(ViewA).FullName);
        }
    }
}
