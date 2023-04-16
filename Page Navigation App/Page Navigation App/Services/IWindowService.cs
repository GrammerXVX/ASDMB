using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Page_Navigation_App
{
    public interface IWindowService
    {
        void OpenWindow(object ExecWindow);
        void CloseWindow();
    }
}
