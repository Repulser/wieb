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
        private static int _indexOfCombo = 0;
        public int IndexOfCombo
        {
            get { return _indexOfCombo;}
            set { _indexOfCombo = value; OnPropertyChanged(); }
        }

        private static bool _isColorCrazed;
        public bool IsColorCrazed
        {
            get
            {
                return _isColorCrazed;
            }
            set
            {
                _isColorCrazed = value;
                OnPropertyChanged();
                
            }
        }

        public static DependencyProperty ColorCrazeProperty;

        static ColorCraze()
        {
            ColorCrazeProperty = DependencyProperty.RegisterAttached("IsColorCrazing", typeof(bool), typeof(ColorCraze));   
        }

        public static void DoColorCraze()
        {
            switch (_isColorCrazed)
            {
                case true:
                    _indexOfCombo = 0;
                    for (int i = 0; i > 20; i++)
                    {
                        _indexOfCombo ++;
                    }
                    break;
            }
        }

        public static bool GetIsColorCrazing(UIElement element)
        {
            return (bool)element.GetValue(ColorCrazeProperty);
        }

        public static void SetIsColorCrazing(UIElement element, bool value)
        {
            element.SetValue(ColorCrazeProperty, value);
        }
    }
}
