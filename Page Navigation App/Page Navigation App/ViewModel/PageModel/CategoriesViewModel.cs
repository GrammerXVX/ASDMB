using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Page_Navigation_App.Model.DataBaseModel;
using Page_Navigation_App.Services;
using Page_Navigation_App.Utilities;
using Page_Navigation_App.View.Window;
using Page_Navigation_App.ViewModel.WindowModel;

namespace Page_Navigation_App.ViewModel.PageModel
{
    public class CategoriesViewModel : ViewModelBase
    {
        private readonly BeltelecomDirectoryContext _context;
        private readonly ObservableCollection<Model.ButtonForCategory> LocalData;

        private ObservableCollection<Model.ButtonForCategory> variableButtons;
        public ObservableCollection<Model.ButtonForCategory> VariableButtons
        {
            get => variableButtons;
            set => SetProperty(ref variableButtons, value, nameof(VariableButtons));
        }

        private object _currentView;
        public object CurrentView
        {
            get => _currentView;
            set
            {
                SetProperty(ref _currentView, value, nameof(CurrentView));
                foreach (Window window in Application.Current.Windows)
                {
                    if(window is MainWindow)
                        ((MainWindowViewModel)window.DataContext).OnOpenPage(value);
                }
            }
        }

        private string searchString;
        public string SearchString 
        {
            get => searchString;
            set
            {
                searchString = value;
                OnPropertyChanged(nameof(SearchString));
                if (value.IsNullOrEmpty())
                    VariableButtons = LocalData;
            }
        }
        public CategoriesViewModel()
        {
            _context = new BeltelecomDirectoryContext();
            LocalData = new ObservableCollection<Model.ButtonForCategory>();
            GetCategories();
        }
        private void SearchCategory(string substring)
        {
            VariableButtons = new ObservableCollection<Model.ButtonForCategory>();
            foreach (var button in LocalData)
                if (button.CategoryName.Contains(substring))
                    VariableButtons.Add(button);
        }
        private  void GetCategories()
        {
            VariableButtons = new ObservableCollection<Model.ButtonForCategory>();
            int index = 1;
            foreach (var button in  _context.Categories.ToList())
            {
                LocalData.Add(new Model.ButtonForCategory()
                {
                    Command = new RelayCommand<int>((int id) => CurrentView = new ServicesViewModel(id)),
                    Row = index++,
                    CategoryName = button.CategoryType,
                    ServiceCount = _context.Services
                        .Select(count => count)
                        .Where(count => count.CategoryId == button.CategoryId)
                        .Count().ToString()
                });
            }
            
            VariableButtons = LocalData;
        }
        private void OnPropertyChanged(string propertyName)
        {
            if (propertyName == "SearchString")
                SearchCategory(searchString);
        }
    }
}