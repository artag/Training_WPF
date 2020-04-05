using System.Windows;
using Demo.Infrastructure;
using System.Windows.Controls;
using ModuleA.ViewModels;

namespace ModuleA.Views
{
    /// <summary>
    /// Interaction logic for ContentAView.xaml
    /// </summary>
    public partial class ContentAView : UserControl, IContentAView
    {
        public ContentAView()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        public IViewModel ViewModel
        {
            get => (IContentAViewModel)DataContext;
            set => DataContext = value;
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            var vm = (IContentAViewModel) ViewModel;
            await vm.LoadPeople();
        }
    }
}
