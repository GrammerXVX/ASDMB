using Page_Navigation_App.Model;
using Page_Navigation_App.Utilities;
using Page_Navigation_App.View;
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

namespace Page_Navigation_App.ViewModel
{
    class LoginVM : Utilities.ViewModelBase
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }
        public ICommand ErrorMessageCommand { get; set; }
        private void Error(object obj) => CurrentView = new ErrorVM();
        public string LoginStr { get; set; }
        public string PasswordStr { get; set; }
        private readonly IWindowService _windowService;
        public ICommand OpenWindowCommand { get; set; }
        public ICommand CloseWindowCommand { get; set; }
        private void OnOpenWindow(Window Exec)
        {
            //if (UserDbModel.GetUser(new User() { Password = PasswordStr, UserName = LoginStr }))
                _windowService.OpenWindow(Exec);
            //else
            //    CurrentView = new ErrorVM();

        }
            

        //private void OnCloseWindow()=>
        //    _windowService.CloseWindow();

        public LoginVM(IWindowService windowService, Window Exec)
        {
            ErrorMessageCommand = new RelayCommand(Error);
            //UserDbModel user = new UserDbModel();
            _windowService = windowService;
            
            OpenWindowCommand = new RelayCommand(param => OnOpenWindow(Exec));
            //CloseWindowCommand = new RelayCommand(param => OnCloseWindow());
        }
        public LoginVM()
        {

        }
    }
}
