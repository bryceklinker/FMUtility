using System;
using System.Globalization;
using System.Windows.Data;
using FMUtility.Models;

namespace FMUtility.Converters
{
    public class WageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var wage = value as WageModel;
            if (wage == null)
                return null;

            return string.Format("{0} {1:N} {2}", wage.Symbol, wage.Value, wage.WageType);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
