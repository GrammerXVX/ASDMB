using Microsoft.EntityFrameworkCore;
using Page_Navigation_App.Model.DataBaseModel;
using Page_Navigation_App.Utilities;
using Page_Navigation_App.ViewModel.HelperPageModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using static Page_Navigation_App.ViewModel.HelperPageModel.DataListViewModel;

namespace Page_Navigation_App.ViewModel.PageModel
{
    class AdminPanelViewModel : ViewModelBase
    {
        private ObservableCollection<object> listTable; 
        public ObservableCollection<object> ListTable
        {
            get => listTable;
            set =>SetProperty(ref listTable, value,nameof(ListTable));
        }

        private object selectedItem;
        private object selectedView;
        public object SelectedView
        {
            get => selectedView;
            set=>SetProperty(ref selectedView, value, nameof(SelectedView));
        }
        public object SelectedItem
        {
            get => selectedItem;
            set
            {
                SelectedView = new ListPageViewModel(DataValues.GetValueOrDefault(value.ToString()));
                SetProperty(ref selectedItem, value, nameof(SelectedItem));
            }
        }
        private Dictionary<string, List<object>> DataValues;
        public AdminPanelViewModel()
        {
            BeltelecomDirectoryContext Context = new BeltelecomDirectoryContext();
            ListTable = new ObservableCollection<object>();
            DataValues = new Dictionary<string, List<object>>();
            foreach (PropertyInfo obj in typeof(BeltelecomDirectoryContext).GetProperties())
                if (obj.Name != "Database" && obj.Name != "ChangeTracker" && obj.Name != "ContextId" && obj.Name != "Model")
                {
                    ListTable.Add(obj.Name);
                    switch (obj.Name.ToString())
                    {
                        case "Categories":
                            {
                                DataValues.Add(obj.Name, new List<object>(Context.Categories.ToList()));
                                continue;
                            }
                        case "Departments":
                            {
                                DataValues.Add(obj.Name, new List<object>(Context.Departments.ToList()));
                                continue;
                            }
                        case "Employees":
                            {
                                DataValues.Add(obj.Name, new List<object>(Context.Employees.ToList()));
                                continue;
                            }
                        case "Positions":
                            {
                                DataValues.Add(obj.Name, new List<object>(Context.Positions.ToList()));
                                continue;
                            }
                        case "Services":
                            {
                                DataValues.Add(obj.Name, new List<object>(Context.Services.ToList()));
                                continue;
                            }
                        case "Users":
                            {
                                DataValues.Add(obj.Name, new List<object>(Context.Users.ToList()));
                                continue;
                            }
                        case "Units":
                            {
                                DataValues.Add(obj.Name, new List<object>(Context.Units.ToList()));
                                continue;
                            }
                    }
                }
                    
        }
    }
}
