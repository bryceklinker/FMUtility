using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace FMUtility.Converters
{
    public class InverseVisibilityToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility)
                return (Visibility) value != Visibility.Visible;
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
