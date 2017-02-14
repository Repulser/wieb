using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wieb.SharedResources;

namespace wieb.ViewModels
{
    class ClickAnimationConverter : ValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            if (value != null)
            {
                var result = (double)value;
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
            }
            return value;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
