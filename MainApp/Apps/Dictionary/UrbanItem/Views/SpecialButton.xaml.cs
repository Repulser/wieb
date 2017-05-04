using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Dictionary.Views
{
    /// <summary>
    ///     Interaction logic for SpecialButton.xaml
    /// </summary>
    public partial class SpecialButton : UserControl
    {
        public static readonly DependencyProperty ButtonContentProperty
            = DependencyProperty.Register("ButtonContent", typeof (object), typeof (SpecialButton));

        public static readonly DependencyProperty ButtonClickProperty
            = DependencyProperty.Register("ButtonClick", typeof (RoutedEventHandler), typeof (SpecialButton));

        public static readonly DependencyProperty ButtonForegroundProperty
            = DependencyProperty.Register("ButtonForeground", typeof (SolidColorBrush), typeof (SpecialButton));

        public SpecialButton()
        {
            InitializeComponent();
        }

        public object ButtonContent
        {
            get => GetValue(ButtonContentProperty);
            set => SetValue(ButtonContentProperty, value);
        }

        public RoutedEventHandler ButtonClick
        {
            get => GetValue(ButtonClickProperty) as RoutedEventHandler;
            set => SetValue(ButtonClickProperty, value);
        }

        public SolidColorBrush ButtonForeground
        {
            get => GetValue(ButtonForegroundProperty) as SolidColorBrush;
            set => SetValue(ButtonForegroundProperty, value);
        }
    }
}