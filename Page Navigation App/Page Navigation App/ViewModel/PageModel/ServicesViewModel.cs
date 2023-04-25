using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Page_Navigation_App.Model.DataBaseModel;
using Page_Navigation_App.Model.TemplateDataSevice;
using Page_Navigation_App.Utilities;
using Page_Navigation_App.View.Window;
using Page_Navigation_App.ViewModel.WindowModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Page_Navigation_App.ViewModel.PageModel
{
    public class ServicesViewModel : ViewModelBase
    {
        private readonly BeltelecomDirectoryContext _context;
        private readonly ObservableCollection<Button_Service> LocalData;
        private readonly int InitCategory;

        private ObservableCollection<Button_Service> variableButtons;
        public ObservableCollection<Button_Service> VariableButtons
        {
            get => variableButtons;
            set => SetProperty(ref variableButtons, value, nameof(VariableButtons));
        }

        private ObservableCollection<Button_Service> variableData;
        public ObservableCollection<Button_Service> VariableData 
        {
            get => variableData;
            set => SetProperty(ref variableData, value, nameof(VariableData));
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
                {
                    VariableButtons = LocalData;
                }
            }
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
                    if (window is MainWindow)
                        ((MainWindowViewModel)window.DataContext).CurrentView = value;
                }
            }
        }

        public ICommand RoleBackCommand { get;}
        public ServicesViewModel()
        {
            _context = new BeltelecomDirectoryContext();
            GetService(InitCategory,ref LocalData);
            VariableButtons = LocalData;
        }
        public ServicesViewModel(int category_id)
        {
            _context = new BeltelecomDirectoryContext();
            LocalData = new ObservableCollection<Button_Service>();
            InitCategory = category_id;
            RoleBackCommand = new RelayCommand(()=> CurrentView= new CategoriesViewModel());
            GetService(InitCategory, ref LocalData);
            VariableButtons = LocalData;
            if (category_id == 1)
            {
                VariableData = new ObservableCollection<Button_Service>()
                {
                    new TextBox_Service()
                    {

                    },

                };
            }
        }
        private void SearchCategory(string substring)
        {
            VariableButtons = new ObservableCollection<Button_Service>();
            int i = 1;
            foreach (var button in LocalData)
            {
                if (button.GetParametrs("ServiceName").Contains(substring))
                {
                    button.Row = i++;
                    VariableButtons.Add(button);
                }
            }
        }
        private void GetService(int category_id,ref ObservableCollection<Button_Service> SetValues)
        {
            SetValues = new ObservableCollection<Button_Service>();
            int index = 0;
            foreach (var service in _context.Services.Select(x => x).Where(x => x.CategoryId == category_id).ToList())
            {
                SetValues.Add(new Button_Service(
                    new Dictionary<string, string>()
                    {
                        {"ServiceName",service.ServiceName }
                    })
                { Row = index++ });
            }
            //Buttons.Add(new Model.Button() { Row = index++, ServiceName = "+" });
        }
        private void OnPropertyChanged(string propertyName)
        {
            if (propertyName == "SearchString")
            {
                SearchCategory(searchString);
            }
        }
    }
}
