using System;
using System.IO.Pipes;
using System.Threading;
using System.Windows;
using MahApps.Metro.Controls;
using wiebApp.Properties;
using wiebApp.SharedResources;
using wiebApp.ViewModels;

namespace wiebApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
    public TabControlProperties _TabControlProperties { get; set; }
        = new TabControlProperties();

    public MainWindow()
        {
            InitializeComponent();
            
            App.Current.Exit += (sender, args) =>
            {
                PropertyHolder.Settings.Save();
            };

            App.Current.Startup += AppStartup;

            MainTabControl.SelectionChanged += (sender, args) =>
            {
                if (MainTabControl.SelectedIndex != 0)
                {
                    TitlebarControl.BackButtonVisibility = Visibility.Visible;
                }
            };
        }

        private void AppStartup(object sender, StartupEventArgs startupEventArgs)
        {
            PropertyHolder.Settings.Reload();

            new Mutex(true, "wieb", out bool aIsNewInstance);
            if (!aIsNewInstance)
            {
                MessageBox.Show("wieb is already running!", "wieb", MessageBoxButton.OKCancel,
                    MessageBoxImage.Exclamation, defaultResult: MessageBoxResult.OK, options: MessageBoxOptions.DefaultDesktopOnly);
                App.Current.Shutdown();
            }
        }

        private void TitlebarControl_BackButton_Click(object sender, RoutedEventArgs e)
        {
            _TabControlProperties.TabControlIndex = 0;
        }

        private void DictionaryTile_Click(object sender, RoutedEventArgs e)
        {
            _TabControlProperties.TabControlIndex = 2;
        }

        private void SettingsTile_Click(object sender, RoutedEventArgs e)
        {
            _TabControlProperties.TabControlIndex = 1;
        }
    }
}
