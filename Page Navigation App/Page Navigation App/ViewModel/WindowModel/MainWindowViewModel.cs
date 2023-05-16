using Page_Navigation_App.Utilities;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;
using Page_Navigation_App.Services;
using Page_Navigation_App.View.Window;
using Page_Navigation_App.Services.Interfaces;
using Page_Navigation_App.ViewModel.PageModel;
using System.Collections.Generic;
using Page_Navigation_App.View.Page;
using System.Threading;

namespace Page_Navigation_App.ViewModel.WindowModel
{
    class MainWindowViewModel : ViewModelBase
    {
        private readonly IWindowService _windowService;
        private bool _disposed;
        private readonly Stack<object> StackView;
        private object currentView;
        private bool _IsPanelVisible;
        public bool IsPanelVisible
        {
            get => _IsPanelVisible;
            set => SetProperty(ref _IsPanelVisible, value, nameof(IsPanelVisible));
        }
        public object CurrentView
        {
            get=>currentView;
            set=>SetProperty(ref currentView, value, nameof(CurrentView));
        } 
        public Dictionary<string,ICommand> Commands { get; private set; }
        private void OnOpenWindow(Window Exec, bool CloseToken) =>
           _windowService.OpenWindow(Exec, CloseToken);

        public MainWindowViewModel()
        {
            _disposed = true;
            StackView = new Stack<object>();
            _windowService = new WindowService();
            Commands = new Dictionary<string, ICommand>()
            {
                {"Home", new RelayCommand(()=>OnOpenPage(new HomeVM()))},
                {"Exit", new RelayCommand(()=>OnOpenWindow(new Login(),true))},
                {"Category", new RelayCommand(()=>OnOpenPage(new CategoriesViewModel()))},
                {"AdminPanel", new RelayCommand(()=> OnOpenWindow(new AdminPanel(),false))},
                {"Back",new RelayCommand(OnBackPage)},
            };
            // Startup Page
            if (ConfigureSettings.GetParametr("CurrentRole").Equals("0"))
                IsPanelVisible = true;
            else
                IsPanelVisible = false;
                

            OnOpenPage(new HomeVM());
        }
        public void OnOpenPage(object Parametr)
        {
            CurrentView = Parametr;
            StackView.Push(Parametr);
        }
        private void OnBackPage()
        {
            if (_disposed&&StackView.Count > 1)
            {
                StackView.Pop();
                _disposed = false;
            }
            if (StackView.Count == 1)
            {
                CurrentView = StackView.Peek();
                _disposed = true;
                return;
            }
            else 
                CurrentView = StackView.Pop();
        }
    }
}
