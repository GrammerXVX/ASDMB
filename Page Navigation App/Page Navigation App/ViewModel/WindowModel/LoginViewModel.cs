using Page_Navigation_App.Services;
using Page_Navigation_App.Services.Interfaces;
using Page_Navigation_App.Utilities;
using Page_Navigation_App.View.Window;
using Page_Navigation_App.ViewModel.HelperPageModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Page_Navigation_App.ViewModel.WindowModel
{
    class LoginViewModel : ViewModelBase
    {
        private readonly IWindowService _windowService;

        private object _currentView;
        public object CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView,value, nameof(CurrentView)); 
        }

        public string LoginStr { private get; set; }
        public string PasswordStr { private get; set; }

        public ICommand ErrorMessageCommand { get; set; }
        public ICommand OpenWindowCommand { get; set; }
        public ICommand CloseWindowCommand { get; set; }

        private void OnOpenWindow(Window Exec)
        {

            //if (UserDbModel.GetUser(new User() { Password = PasswordStr, UserName = LoginStr }))
               _windowService.OpenWindow(Exec);
            //else
            //    CurrentView = new ErrorVM();
        }

        private void OnError() => CurrentView = new ErrorViewModel(new Exception(), "Error");
        //private void OnCloseWindow()=>
        //    _windowService.CloseWindow();

        public LoginViewModel()
        {
            ErrorMessageCommand = new RelayCommand(OnError);
            _windowService = new WindowService();
            
            OpenWindowCommand = new RelayCommand(() => OnOpenWindow(new MainWindow()));
            //_windowService.CloseWindow();
        }
    }
}
