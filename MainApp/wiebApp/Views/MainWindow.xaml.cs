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
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace wiebApp
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

        private void MainBtn1_Click(object sender, RoutedEventArgs e)
        {
            //MainTabControl.SelectedIndex = 1;
        }

        private void SettingsItemTile_Click(object sender, RoutedEventArgs e)
        {
            // temp code for ui demo
            // i hope it is temp
            MainTabGrid.Visibility = Visibility.Collapsed;
            DictionaryAppGrid.Visibility = Visibility.Visible;
            TitlebarControl.BackButtonVisibility = Visibility.Visible;
        }

        private void TitlebarControl_BackButton_Click(object sender, RoutedEventArgs e)
        {
            // temp code for ui demo
            MainTabGrid.Visibility = Visibility.Visible;
            DictionaryAppGrid.Visibility = Visibility.Collapsed;
            TitlebarControl.BackButtonVisibility = Visibility.Collapsed;
        }
    }
}
