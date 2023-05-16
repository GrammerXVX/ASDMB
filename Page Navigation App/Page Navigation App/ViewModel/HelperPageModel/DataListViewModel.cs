using Page_Navigation_App.ViewModel.PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Page_Navigation_App.ViewModel.HelperPageModel
{
    public class DataListViewModel
    {
        public DataPageType PageType { get; set; }
        public DataListViewModel() 
        {
            
        }
        public DataListViewModel(DataPageType type)
        {
            switch (type)
            {
                case DataPageType.ListPage:
                    {
                        //_ = new ListPageViewModel();
                        break;
                    }
                case DataPageType.ChangePage:
                    {
                        _ = new ChangePageViewModel();
                        break;
                    }
            }
        }
        public enum DataPageType
        {
            ListPage,
            ChangePage
        }
    }
}
