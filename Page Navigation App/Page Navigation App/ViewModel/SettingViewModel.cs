using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Page_Navigation_App.Model;

namespace Page_Navigation_App.ViewModel
{
    class SettingViewModel : Utilities.ViewModelBase
    {
        private readonly PageModel _pageModel;
        public bool Settings
        {
            get;
            set;
        }

        public SettingViewModel()
        {
            _pageModel = new PageModel();
            Settings = true;
        }
    }
}
