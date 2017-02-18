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
using wiebApp.ViewModels;

namespace wiebApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public bool IsChecked;
        private CheckBoxAndLabelsEvents _vm;

        public MainWindow()
        {
            InitializeComponent();
            _vm = FindResource("CheckBoxEvents") as CheckBoxAndLabelsEvents;
        }

        private void MainBtn1_Click(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 1;
        }

        private void DropGlowLabel_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _vm.
        }
    }
}
