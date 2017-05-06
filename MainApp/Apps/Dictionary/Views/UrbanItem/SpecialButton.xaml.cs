using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dictionary.Views
{
    /// <summary>
    /// Interaction logic for SpecialButton.xaml
    /// </summary>
    public partial class SpecialButton : UserControl
    {
        public static readonly DependencyProperty ButtonContentProperty
            = DependencyProperty.Register("ButtonContent", typeof(object), typeof(SpecialButton));

        public object ButtonContent
        {
            get => GetValue(ButtonContentProperty);
            set => SetValue(ButtonContentProperty, value);
        }

        public static readonly DependencyProperty ButtonClickProperty
            = DependencyProperty.Register("ButtonClick", typeof(RoutedEventHandler), typeof(SpecialButton));

        public RoutedEventHandler ButtonClick
        {
            get => GetValue(ButtonClickProperty) as RoutedEventHandler;
            set => SetValue(ButtonClickProperty, value);
        }

        public SpecialButton()
        {
            InitializeComponent();
        }
    }
}
