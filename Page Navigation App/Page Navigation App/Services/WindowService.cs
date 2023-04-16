using Page_Navigation_App.View.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Page_Navigation_App.Services
{
    public class WindowService : IWindowService
    {
        public void OpenWindow(object ExecWindow)
        {
            if(ExecWindow is MainWindow)
            {
                var window = new MainWindow();
                window.Show();
                foreach(Window CloseWindow in Application.Current.Windows)
                {
                    if(CloseWindow is Login)
                        if (CloseWindow != null)
                        {
                            CloseWindow.Close();
                        }       
                }
            }
            if(ExecWindow == null)
            {

            }
            if (ExecWindow is Login)
            {
                var window = new Login();
                window.Show();
                foreach (Window CloseWindow in Application.Current.Windows)
                {
                    if (CloseWindow is MainWindow)
                        if (CloseWindow != null)
                        {
                            CloseWindow.Close();
                        }
                }
            }
        }
        public void CloseWindow()
        {
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(x=> x.IsActive);

            if(window != null)
            {
                window.Close();
            }
        }
    }
}
