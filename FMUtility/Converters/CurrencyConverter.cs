using System;
using System.Globalization;
using System.Windows.Data;
using FMUtility.Models;

namespace FMUtility.Converters
{
    public class CurrencyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var currency = value as CurrencyValueModel;
            if (currency == null)
                return null;

            return string.Format("{0} {1:N}", currency.Symbol, currency.Value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
