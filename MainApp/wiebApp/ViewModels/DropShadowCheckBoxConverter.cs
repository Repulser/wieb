using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using wiebApp.Views;


namespace wiebApp.ViewModels
{
    class DropShadowCheckBoxConverter : ValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
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

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
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
