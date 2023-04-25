using Page_Navigation_App.Utilities;
using Page_Navigation_App.View.Window;
using Page_Navigation_App.ViewModel.PageModel;
using Page_Navigation_App.ViewModel.WindowModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Page_Navigation_App.Model
{
    public class ButtonForCategory : ViewModelBase
    {
        private string categoryName;
        public int Id { get; set; }
        public string CategoryName 
        {
            get => categoryName;
            set=> categoryName = value
                .Split(' ').Length == 2 ? value.Replace(" ", "\n") : value+"\n";
        }
        public ICommand Command { get; set; }
        
        private string serviceCount;
        public string ServiceCount
        {
            get => serviceCount;
            set => serviceCount = "\nУслуг: "+value;
        }
        public int Row { get; set; }
        public int Column { get; set; }
    }
}
