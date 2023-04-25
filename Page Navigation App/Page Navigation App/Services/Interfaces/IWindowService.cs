using System.Windows;

namespace Page_Navigation_App.Services.Interfaces
{
    public interface IWindowService
    {
        void OpenWindow(Window ExecWindow);
        void CloseWindow();
    }
}
