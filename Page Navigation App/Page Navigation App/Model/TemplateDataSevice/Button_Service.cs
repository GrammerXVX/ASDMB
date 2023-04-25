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

namespace Page_Navigation_App.Model.TemplateDataSevice
{
    public class Button_Service : ViewModelBase
    {
        private readonly Dictionary<string, string> strings;
        public int Row { get; set; }
        public Button_Service(Dictionary<string, string> keyValuePairs)
        {
            strings = keyValuePairs;
        }
        public Button_Service() { }
        public string Param { get => strings.GetValueOrDefault(strings.First().Key); }
        public void SetParametrs(string key, string value) =>
            strings.Add(key, value);
        public string GetParametrs(string key) =>
            strings.GetValueOrDefault(key);
    }
}
