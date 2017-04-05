using System;
using System.Threading;
using System.Windows;

namespace wiebApp
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
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