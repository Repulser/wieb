using System.Windows;
using MahApps.Metro.Controls;
using wiebApp.ViewModels;

namespace wiebApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TitlebarControl_BackButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void DictionaryTile_Click(object sender, RoutedEventArgs e)
        {
            TabControlProperties.TabControlIndex = 2;
        }
    }
}
