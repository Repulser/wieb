using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace wiebApp.ViewModels
{
    class ColorCraze : NotifyPropertyChanged
    {
        private int _indexOfCombo;
        private bool _isColorCrazed;

        public static DependencyProperty ColorCrazeProperty;

        static ColorCraze()
        {
            ColorCrazeProperty = DependencyProperty.RegisterAttached("IsColorCrazing", typeof(bool), typeof(ColorCraze));
        }

        public static int GetIsColorCrazing(System.Windows.UIElement element)
        {
            return (int)element.GetValue(ColorCrazeProperty);
        }

        public static void SetIsColorCrazing(System.Windows.UIElement element, int value)
        {
            element.SetValue(ColorCrazeProperty, value);
        }
    }
}
