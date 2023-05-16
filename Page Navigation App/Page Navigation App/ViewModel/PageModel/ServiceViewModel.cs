using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Page_Navigation_App.Model;
using Page_Navigation_App.Model.DataBaseModel;
using Page_Navigation_App.Services;
using Page_Navigation_App.Utilities;

namespace Page_Navigation_App.ViewModel.PageModel
{
    public class ServiceViewModel : ViewModelBase
    {
        private readonly BeltelecomDirectoryContext _context;
        private ObservableCollection<Model.Button> _buttons;

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
                    GetService();
                }
            } 
        }
        public ObservableCollection<Model.Button> Buttons
        {
            get => _buttons;
            set => SetProperty(ref _buttons, value, nameof(Buttons));
        }
        public ServiceViewModel()
        {
            _context = new BeltelecomDirectoryContext();
            GetService();
        }
        private void SearchCategory(string substring)
        {
            ObservableCollection<Model.Button> TempButton = Buttons;
            Buttons = new ObservableCollection<Model.Button>();
            foreach (var button in TempButton)
            {
                if (button.ServiceName.Contains(substring))
                    Buttons.Add(button);
            }
        }
        private async void GetService()
        {
            Buttons = new ObservableCollection<Model.Button>();
            int index = 0;
            foreach (var button in await _context.Categories.ToListAsync())
            {
                Buttons.Add(new Model.Button() { Row = index++, ServiceName = button.CategoryType, ServiceCount = _context.Services.Select(count => count).Where(count => count.CategoryId == button.CategoryId).Count().ToString() });
            }
            Buttons.Add(new Model.Button() { Row = index++, ServiceName = "+" });
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
