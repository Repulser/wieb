using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace wiebApp.Converters
{
    class DropGlowCheckBoxConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool valueAsBool = (bool)value;
            switch (valueAsBool)
            {
                case true:
                    value = Brushes.White;
                    break;
                case false:
                    value = Brushes.Transparent;
                    break;
            }

            return value;
        }

        public  object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}