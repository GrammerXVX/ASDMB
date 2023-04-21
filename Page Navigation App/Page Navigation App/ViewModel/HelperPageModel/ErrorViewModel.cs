using Page_Navigation_App.Model;
using Page_Navigation_App.Utilities;
using System;

namespace Page_Navigation_App.ViewModel.HelperPageModel
{
    public class ErrorViewModel : ViewModelBase
    {
        public string ExceptionMessage
        {
            get;
            set;
        }
        public Exception Exception { get; set; }

        public ErrorViewModel(Exception exception,string exceptionMessage=null)
        {
            Exception = exception;
            ExceptionMessage = exceptionMessage;
        }
        public ErrorViewModel()
        {
        }
    }
}
