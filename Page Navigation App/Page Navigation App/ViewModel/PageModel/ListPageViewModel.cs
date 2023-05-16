using Microsoft.EntityFrameworkCore.Infrastructure;
using Page_Navigation_App.Model.DataBaseModel;
using Page_Navigation_App.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Page_Navigation_App.ViewModel.PageModel
{
    class ListPageViewModel : ViewModelBase
    {

        private ObservableCollection<object> _DataSource;

        public ObservableCollection<object> DataSource
        {
            get => _DataSource;
            set=>SetProperty(ref  _DataSource, value, nameof(DataSource));
        }

        public ListPageViewModel(List<object> values)
        {
            DataSource = new ObservableCollection<object>(values);
        }
    }
}
