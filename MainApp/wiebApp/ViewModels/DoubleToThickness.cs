using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace wiebApp.ViewModels
{
    public class DoubleToThickness : ValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var ValueAsDouble = (double) value;
            var Thickness = new Thickness(ValueAsDouble);

            return Thickness;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var ValueAsThickness = (Thickness) value;
            var Double = ValueAsThickness.Top;

            return Double;
        }
    }
}
