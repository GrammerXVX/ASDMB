using Page_Navigation_App.Services.Interfaces;
using Page_Navigation_App.View.Window;
using System.Linq;
using System.Windows;

namespace Page_Navigation_App.Services
{
    public class WindowService : IWindowService
    {
        public void OpenWindow(Window ExecWindow,bool CloseToken)
        {
            ExecWindow.Show();
            if(CloseToken)
            foreach (Window CloseWindow in Application.Current.Windows)
            {
                if (CloseWindow != ExecWindow)
                    CloseWindow?.Close();
            }
        }
        public void CloseWindow()
        {
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(x=> x.IsActive);
            window?.Close();
        }
    }
}
