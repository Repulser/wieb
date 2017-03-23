using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using wiebApp.ViewModels;

namespace wiebApp.SharedResources
{
    class AppSettings : NotifyPropertyChanged
    {
        
        private string _accentColor;
        private string _themeColor;
        private ICollectionView _collectionAccentView;
        private ICollectionView _collectionThemeView;
        
        public ObservableCollection<ColorPath> AccentColors { get; set; }
        public ObservableCollection<ColorPath> ThemeColors { get; set; }
        public ResourceDictionary lastResourceDictionary { get; set; }

        public AppSettings()
        {
            AccentColors = new ObservableCollection<ColorPath>
            {
                new ColorPath { Name = "Amber",   Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/amber.xaml"},
                new ColorPath { Name = "Blue",    Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/blue.xaml"},
                new ColorPath { Name = "Brown",   Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/brown.xaml"},
                new ColorPath { Name = "Cobalt",  Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/cobalt.xaml"},
                new ColorPath { Name = "Crimson", Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/crimson.xaml"},
                new ColorPath { Name = "Cyan",    Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/cyan.xaml"},
                new ColorPath { Name = "Emerald", Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/cobalt.xaml"},
                new ColorPath { Name = "Green",   Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/green.xaml"},
                new ColorPath { Name = "Indigo",  Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/indigo.xaml"},
                new ColorPath { Name = "Lime",    Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/lime.xaml"},
                new ColorPath { Name = "Magenta", Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/magenta.xaml"},
                new ColorPath { Name = "Mauve",   Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/mauve.xaml"},
                new ColorPath { Name = "Olive",   Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/olive.xaml"},
                new ColorPath { Name = "Orange",  Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/orange.xaml"},
                new ColorPath { Name = "Pink",    Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/pink.xaml"},
                new ColorPath { Name = "Purple",  Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/purple.xaml"},
                new ColorPath { Name = "Red",     Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/red.xaml"},
                new ColorPath { Name = "Sienna",  Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/sienna.xaml"},
                new ColorPath { Name = "Steel",   Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/steel.xaml"},
                new ColorPath { Name = "Taupe",   Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/taupe.xaml"},
                new ColorPath { Name = "Violet",  Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/voilet.xaml"},
                new ColorPath { Name = "Yellow",  Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/yellow.xaml"}
            };
            ThemeColors = new ObservableCollection<ColorPath>
            {
                new ColorPath { Name = "BaseDark",  Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/basedark.xaml"},
                new ColorPath { Name = "BaseLight", Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/baselight.xaml"}
            };

            _collectionAccentView = CollectionViewSource.GetDefaultView(AccentColors);
            _collectionAccentView.CurrentChanged += CollectionAccentView;

            _collectionThemeView = CollectionViewSource.GetDefaultView(ThemeColors);
            _collectionThemeView.CurrentChanged += CollectionThemeView;
        }

        private void CollectionThemeView(object sender, EventArgs eventArgs)
        {
            if (_collectionThemeView.CurrentItem is ColorPath item)
            {
                _themeColor = item.Path;
            }
            if (_themeColor != null)
            {
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
                {
                    Source = new Uri(_themeColor)
                });
            }
        }

        private void CollectionAccentView(object sender, EventArgs e)
        {
            var item = _collectionAccentView.CurrentItem as ColorPath;
            if (item != null)
            {
                _accentColor = item.Path;
            }
            if (_accentColor != null)
            {
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
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

        private void ColorCraze()
        {
            
        }
    }
}