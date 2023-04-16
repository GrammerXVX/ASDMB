using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Page_Navigation_App.Model;

namespace Page_Navigation_App.ViewModel
{
    class SearchVM : Utilities.ViewModelBase
    {
        private readonly PageModel _pageModel;
        //public string SearchAvailability
        //{
        //    get { return _pageModel; }
        //   // set { _pageModel.SearchStatus = value; OnPropertyChanged(); }
        //}

        public SearchVM()
        {
            _pageModel = new PageModel();
            //SearchAvailability = "Out of Stock";
        }
    }
}
