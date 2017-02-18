using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Data;
using wiebApp.ViewModels;

namespace wiebApp.SharedResources
{
    class AppSettings : NotifyPropertyChanged
    {
        private static string _accentColor;
        private static string _themeColor;
        private ICollectionView _collectionAccentView;
        private ICollectionView _collectionThemeView;
        
        public ObservableCollection<ColorPath> AccentColors { get; set; }
        public ObservableCollection<ColorPath> ThemeColors { get; set; }

        public AppSettings()
        {
            AccentColors = new ObservableCollection<ColorPath>
            {
                new ColorPath { Name = "amber",   Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/amber.xaml"},
                new ColorPath { Name = "blue",    Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/blue.xaml"},
                new ColorPath { Name = "brown",   Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/brown.xaml"},
                new ColorPath { Name = "cobalt",  Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/cobalt.xaml"},
                new ColorPath { Name = "crimson", Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/crimson.xaml"},
                new ColorPath { Name = "cyan",    Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/cyan.xaml"},
                new ColorPath { Name = "emerald", Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/cobalt.xaml"},
                new ColorPath { Name = "green",   Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/green.xaml"},
                new ColorPath { Name = "indigo",  Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/indigo.xaml"},
                new ColorPath { Name = "lime",    Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/lime.xaml"},
                new ColorPath { Name = "magenta", Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/magenta.xaml"},
                new ColorPath { Name = "mauve",   Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/mauve.xaml"},
                new ColorPath { Name = "olive",   Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/olive.xaml"},
                new ColorPath { Name = "orange",  Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/orange.xaml"},
                new ColorPath { Name = "pink",    Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/pink.xaml"},
                new ColorPath { Name = "purple",  Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/purple.xaml"},
                new ColorPath { Name = "red",     Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/red.xaml"},
                new ColorPath { Name = "sienna",  Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/sienna.xaml"},
                new ColorPath { Name = "steel",   Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/steel.xaml"},
                new ColorPath { Name = "taupe",   Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/taupe.xaml"},
                new ColorPath { Name = "violet",  Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/voilet.xaml"},
                new ColorPath { Name = "yellow",  Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/yellow.xaml"}
            };
            ThemeColors = new ObservableCollection<ColorPath>
            {
                new ColorPath { Name = "basedark",  Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/basedark.xaml"},
                new ColorPath { Name = "baselight", Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/baselight.xaml"}
            };

            _collectionAccentView = CollectionViewSource.GetDefaultView(AccentColors);
            _collectionAccentView.CurrentChanged += CollectionAccentView;

            _collectionThemeView = CollectionViewSource.GetDefaultView(ThemeColors);
            _collectionThemeView.CurrentChanged += CollectionThemeView;
        }

        private void CollectionThemeView(object sender, EventArgs eventArgs)
        {
            var item = _collectionThemeView.CurrentItem as ColorPath;
            if (item != null)
            {
                _themeColor = item.Path;
            }
            if (_themeColor != null)
            {
                App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                {
                    Source = new Uri(_themeColor)
                });
            }
        }

        private void CollectionAccentView(object sender, System.EventArgs e)
        {
            var item = _collectionAccentView.CurrentItem as ColorPath;
            if (item != null)
            {
                _accentColor = item.Path;
            }
            if (_accentColor != null)
            {
                App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                {
                    Source = new Uri(_accentColor)
                });
            }
        }

        public string AccentColor
        {
            get { return _accentColor; }
            set
            {
                _accentColor = value;
                OnPropertyChanged();
            }
        }

        public string ThemeColor
        {
            get { return _themeColor; }
            set
            {
                _themeColor = value;
                OnPropertyChanged();
            }
        }
    }
}