using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Page_Navigation_App.Model.TemplateDataSevice
{
    public class ComboBox_Service : Button_Service
    {
        private object _items;
        private object _selectedItem;
        public object Items 
        {
            get => _items; 
            set => _items = value;
        }
        public object SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem,value,nameof(SelectedItem));
        }

    }
}
