using System;
using System.Windows.Data;

namespace Page_Navigation_App.Services
{
    public class ScrollLimitConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values.Length == 2 && values[0] is double && values[1] is double)
                return (double)values[0] == (double)values[1];
            return false;
        }
        public object[] ConvertBack(object value, Type[] targetType, object parameter, System.Globalization.CultureInfo culture)=>
            throw new NotImplementedException();
    }
}
