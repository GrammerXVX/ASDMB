using Page_Navigation_App.Utilities;
using System.Windows.Input;
using System.Windows;
using Page_Navigation_App.Services;
using Page_Navigation_App.View.Page;
using Page_Navigation_App.View.Window;
using Page_Navigation_App.Services.Interfaces;
using Page_Navigation_App.ViewModel.PageModel;

namespace Page_Navigation_App.ViewModel.WindowModel
{
    class MainWindowViewModel : ViewModelBase
    {
        private object _currentView;
        public object CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView,value, nameof(CurrentView)); 
        }

        private readonly IWindowService _windowService;

        public ICommand OpenWindowCommand { get;}
        public ICommand HomeCommand { get; }
        public ICommand ServiceCommand { get; }
        public ICommand SearchCommand { get; }
        public ICommand InfoCommand { get; }
        public ICommand SettingsCommand { get; }


        private void Home() => CurrentView = new HomeVM();
        private void Service() => CurrentView = new ServiceViewModel();
        private void OnOpenWindow(Window Exec) =>
           _windowService.OpenWindow(Exec);

        public MainWindowViewModel()
        {
            HomeCommand = new RelayCommand(Home);
            ServiceCommand = new RelayCommand(Service);
            _windowService = new WindowService();
            OpenWindowCommand = new RelayCommand(()=>OnOpenWindow(new Login()));
            // Startup Page
            //CurrentView = new HomeVM();
        }
    }
}
