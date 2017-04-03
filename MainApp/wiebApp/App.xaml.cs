using System;
using System.Threading;
using System.Windows;
using wiebApp.SharedResources;

namespace wiebApp
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri(AppSettings.Default.SelectedAccentColor.Path)
            });

            Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri(AppSettings.Default.SelectedThemeColor.Path)
            });

            new Mutex(true, "wieb", out bool aIsNewInstance);
            if (!aIsNewInstance)
            {
                MessageBox.Show("wieb is already running!", "wieb", MessageBoxButton.OKCancel,
                    MessageBoxImage.Exclamation, MessageBoxResult.OK,
                    MessageBoxOptions.DefaultDesktopOnly);
                Shutdown();
            }

            base.OnStartup(e);
        }

    }
}