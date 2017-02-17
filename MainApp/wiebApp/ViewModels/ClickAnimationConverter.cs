using System;
using System.Globalization;
using System.Windows;
using wieb.SharedResources;
using wieb.Views;

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
<<<<<<< HEAD

            var main = App.Current.MainWindow as MainWindow;
            var style = main.Style.BasedOn;
            if (true)
=======
>>>>>>> 5c127f193ce565970226f8240ec7df2fbc09adbf
            return value;
        }

 
    }
}