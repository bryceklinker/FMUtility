using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using FMUtility.Models;

namespace FMUtility.Converters
{
    public class AttributeColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var attribute = value as AttributeModel;
            if (attribute == null)
                return Brushes.Black;

            if (attribute.IsNegative)
                return GetNegativeBrush(attribute.Value);

            return GetPositveBrush(attribute.Value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private Brush GetNegativeBrush(int value)
        {
            if (value >= 17)
                return Brushes.Red;

            if (value >= 13)
                return Brushes.Orange;

            if (value >= 9)
                return Brushes.Black;

            if (value >= 5)
                return Brushes.DarkGreen;

            return Brushes.LimeGreen;
        }

        private Brush GetPositveBrush(int value)
        {
            if (value >= 17)
                return Brushes.LimeGreen;

            if (value >= 13)
                return Brushes.DarkGreen;

            if (value >= 9)
                return Brushes.Black;

            if (value >= 5)
                return Brushes.Orange;

            return Brushes.Red;
        }
    }
}