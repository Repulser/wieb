using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace wiebApp.Converters
{
    class DropShadowCheckBoxConverter : IValueConverter
    {
        public  object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool valueAsBool = (bool) value;
            switch (valueAsBool)
            {
                case true:
                    value = Brushes.Black;
                    break;
                case false:
                    value = Brushes.Transparent;
                    break;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush valueAsBrush = (SolidColorBrush) value;
            if (Equals(valueAsBrush, Brushes.Black))
            {
                value = true;
            }
            else
            {
                value = false;
            }
            return value;
        }
    }
}
