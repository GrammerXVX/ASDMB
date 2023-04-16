using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Page_Navigation_App.Model;

namespace Page_Navigation_App.ViewModel
{
    class ServiceVM : Utilities.ViewModelBase
    {
        private readonly PageModel _pageModel;
        //public int ServiceID
        //{
        //    get { return _pageModel.ServiceCount; }
        //    set { _pageModel.ServiceCount = value; OnPropertyChanged(); }
        //}

        public ServiceVM()
        {
            _pageModel = new PageModel();
            //ServiceID = 100528;
        }
    }
}
