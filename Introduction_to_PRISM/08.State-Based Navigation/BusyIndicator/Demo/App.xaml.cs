using System.Windows;
using Demo.PersonService;
using ModuleA;
using Prism.Ioc;
using Prism.Modularity;
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

        protected override IModuleCatalog CreateModuleCatalog()
        {
            var catalog = new ModuleCatalog();
            catalog.AddModule<PersonServiceModule>();
            catalog.AddModule<ModuleAModule>();

            return catalog;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}