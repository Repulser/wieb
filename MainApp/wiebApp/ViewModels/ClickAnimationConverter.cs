using System;
using System.Globalization;
using wieb.SharedResources;

namespace wieb.ViewModels
{
    internal class ClickAnimationConverter : ValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double result = (double) value;
            if (result == -1)
            {
                value = AppSettings._MainColor;
            }

            if (result == 0)
            {
                value = AppSettings._DarkMainColor;
            }

            if (result == 1)
            {
                value = AppSettings._White;
            }
            return value;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}