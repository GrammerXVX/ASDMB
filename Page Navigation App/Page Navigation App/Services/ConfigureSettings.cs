using System.Configuration;

namespace Page_Navigation_App.Services
{
    public record ConfigureSettings
    {
        public static object GetParametr(string Parametr) =>
            ConfigurationManager.AppSettings[Parametr];
        public static void SetParametr(string Parametr, object value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[Parametr].Value = value.ToString();
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}