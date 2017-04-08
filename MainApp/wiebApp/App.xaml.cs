using System;
using System.Threading;
using System.Windows;
using System.Runtime.InteropServices;


namespace wiebApp
{
    public partial class App : Application
    {
        [DllImport("user32", CharSet = CharSet.Unicode)]
        static extern IntPtr FindWindow(string cls, string win);
        [DllImport("user32")]
        static extern IntPtr SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32")]
        static extern bool IsIconic(IntPtr hWnd);
        [DllImport("user32")]
        static extern bool OpenIcon(IntPtr hWnd);

        protected override void OnStartup(StartupEventArgs e)
        {
            var mutex = new Mutex(true, "MyWindowsMutext", out bool isNew);
            if (!isNew)
            {
                MessageBox.Show("The program is already running!", "wieb", MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
                Shutdown();
            }

            base.OnStartup(e);
        }
    }
}