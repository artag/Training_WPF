using System.Windows;
using System.Windows.Controls;
using Demo.Infrastructure;
using ModuleA;
using ModuleB;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;

namespace Demo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);

            // Регистрация кастомного Region адаптера для StackPanel.
            regionAdapterMappings.RegisterMapping(
                typeof(StackPanel), Container.Resolve<StackPanelRegionAdapter>());
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            var catalog = new ModuleCatalog();
            catalog.AddModule<ModuleAModule>();
            catalog.AddModule<ModuleBModule>();

            return catalog;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IShellViewModel, ShellViewModel>();
            containerRegistry.Register<IShellView, Shell>();
        }
    }
}
