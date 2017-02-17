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

namespace wieb.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainBtn1_OnClick(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 1;
        }

        private void MainBtn2_OnClick(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 2;
        }
        private void ClipBtn1_OnClick(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText("<!-- -->");
        }

        private void ClipBtnClear_OnClick(object sender, RoutedEventArgs e)
        {
            Clipboard.Clear();
        }
    }
}
