using Page_Navigation_App.Model;


namespace Page_Navigation_App.ViewModel
{
    class ErrorVM : Utilities.ViewModelBase
    {
        private readonly PageModel _pageModel;
        public bool Error
        {
            get;
            set;
        }

        public ErrorVM()
        {
            _pageModel = new PageModel();
        }
    }
}
