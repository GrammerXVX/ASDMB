using Microsoft.EntityFrameworkCore;
using Page_Navigation_App.Model.DataBaseModel;
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
        private readonly BeltelecomDirectoryContext context;

        private object _currentView;
        public object CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView,value, nameof(CurrentView)); 
        }

        public string LoginStr { private get; set; }
        public string PasswordStr { private get; set; }

        public ICommand ErrorMessageCommand { get;}
        public ICommand OpenWindowCommand { get;}
        public ICommand CloseWindowCommand { get;}

        private void OnOpenWindow()
        {
            if (context.Users.Any(x => x.Login == LoginStr && x.Password == PasswordStr))
            {
                if (context.Users.FirstAsync(x => x.Login == LoginStr && x.Password == PasswordStr).Result.Role == "User")
                    ConfigureSettings.SetParametr("CurrentRole", "1");
                else
                    ConfigureSettings.SetParametr("CurrentRole", "0");
                _windowService.OpenWindow(new MainWindow(),true);
                context.Dispose();
            }
                
            else
                CurrentView = new ErrorViewModel(new Exception(), "Incorrect login or password");
        }
        private void OnError() => CurrentView = new ErrorViewModel(new Exception(), "Error");
        public LoginViewModel()
        {
            context = new BeltelecomDirectoryContext();

            ErrorMessageCommand = new RelayCommand(OnError);
            _windowService = new WindowService();
            
            OpenWindowCommand = new RelayCommand(() => OnOpenWindow());
        }
    }
}
