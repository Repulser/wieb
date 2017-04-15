using System;
using System.Globalization;
using System.Windows.Data;

namespace Dictionary.Converters
{
    public class ToggleButtonsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var valueBool = (bool) value;
            return value = !valueBool;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var valueBool = (bool) value;
            return value = !valueBool;
        }
    }
}