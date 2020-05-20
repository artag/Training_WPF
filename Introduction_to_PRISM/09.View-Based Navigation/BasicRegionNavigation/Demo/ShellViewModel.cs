using System.Windows;
using Demo.Infrastructure;
using Prism.Commands;
using Prism.Regions;

namespace Demo
{
    public class ShellViewModel : ViewModelBase, IShellViewModel
    {
        private readonly IRegionManager _regionManager;

        public ShellViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            NavigateCommand = new DelegateCommand<object>(Navigate);
            ApplicationCommands.NavigateCommand.RegisterCommand(NavigateCommand);
        }

        public DelegateCommand<object> NavigateCommand { get; }

        private void Navigate(object navigatePath)
        {
            if (navigatePath == null)
                return;

            // Можно выполнить навигацию без обратного вызова делегата NavigationCallback
            // _regionManager.RequestNavigate(RegionNames.ContentRegion, navigatePath.ToString());

            // Навигация с обратным вызовом делегата NavigationCallback
            _regionManager.RequestNavigate(
                RegionNames.ContentRegion, navigatePath.ToString(), NavigateComplete);
        }

        private void NavigateComplete(NavigationResult result)
        {
            var viewName = result.Context.Uri;
            var message = $"Navigation to {viewName} complete";
            var caption = "Information";
            var button = MessageBoxButton.OK;
            var messageType = MessageBoxImage.Information;
            MessageBox.Show(message, caption, button, messageType);
        }
    }
}
