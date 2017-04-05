using System;
using System.ComponentModel;
using System.IO.Pipes;
using System.Net.Configuration;
using System.Threading;
using System.Windows;
using MahApps.Metro.Controls;
using wiebApp.Properties;
using wiebApp.ViewModels;

namespace wiebApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public TabProperties TabProperties { get; set; }
            = new TabProperties();

        public MainWindow()
        {
            InitializeComponent();

            PropertyHolder.Settings.Upgrade();

            MainTabControl.SelectionChanged += (sender, args) =>
            {
                TabProperties.BackButtonVisibility = TabProperties.TabControlIndex != 0
                    ? Visibility.Visible
                    : Visibility.Collapsed;
            };
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            PropertyHolder.Settings.Save();
            base.OnClosing(e);
        }

        private void TitlebarControl_BackButton_Click(object sender, RoutedEventArgs e)
        {
            TabProperties.TabControlIndex = 0;
        }

        private void DictionaryTile_Click(object sender, RoutedEventArgs e)
        {
            TabProperties.TabControlIndex = 2;
        }

        private void SettingsTile_Click(object sender, RoutedEventArgs e)
        {
            TabProperties.TabControlIndex = 1;
        }
    }
}
