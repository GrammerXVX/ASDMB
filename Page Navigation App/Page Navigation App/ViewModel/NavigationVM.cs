using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Page_Navigation_App.Utilities;
using System.Windows.Input;
using System.Windows;
using Page_Navigation_App.Services;
using Page_Navigation_App.View.Page;
using Page_Navigation_App.View.Window;

namespace Page_Navigation_App.ViewModel
{
    class NavigationVM : ViewModelBase
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }
        private readonly IWindowService _windowService;
        public ICommand OpenWindowCommand { get; set; }
        public ICommand HomeCommand { get; set; }
        public ICommand ServiceCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand InfoCommand { get; set; }
        
        public ICommand SettingsCommand { get; set; }

        private void Home(object obj) => CurrentView = new HomeVM();
        private void Service(object obj) => CurrentView = new ServiceVM();
        private void Search(object obj) => CurrentView = new SearchVM();
        private void Info(object obj) => CurrentView = new Info();
        private void Setting(object obj) => CurrentView = new SettingViewModel();
        private void OnOpenWindow(Window Exec) =>
           _windowService.OpenWindow(Exec);

        public NavigationVM()
        {
            HomeCommand = new RelayCommand(Home);
            ServiceCommand = new RelayCommand(Service);
            SearchCommand = new RelayCommand(Search);
            InfoCommand = new RelayCommand(Info);
            _windowService = new WindowService();
            SettingsCommand = new RelayCommand(Setting);
            OpenWindowCommand = new RelayCommand(param => OnOpenWindow(new Login()));
            // Startup Page
            CurrentView = new HomeVM();
        }
    }
}
