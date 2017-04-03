using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using wiebApp.Properties;
using wiebApp.ViewModels;

namespace wiebApp.SharedResources
{
    internal class AppSettings : NotifyPropertyChanged
    {
        //Private Fields
        private static AppSettings _defaultInstance;

        private string _accentColor;
        private string _themeColor;

        private ColorPath _selectedAccentColor;
        private ColorPath _selectedThemeColor;


        //Public Properties
        public static AppSettings Default => _defaultInstance;

        public ObservableCollection<ColorPath> AccentColors { get; set; }
        public ObservableCollection<ColorPath> ThemeColors { get; set; }

        public ICollectionView CollectionAccentView { get; set; }
        public ICollectionView CollectionThemeView { get; set; }

        public ColorPath SelectedAccentColor
        {
            get { return _selectedAccentColor; }
            set
            {
                _selectedAccentColor = value;
                PropertyHolder.Settings.AccentColor = value;
                OnPropertyChanged();
            }
        }
        public ColorPath SelectedThemeColor
        {
            get { return _selectedThemeColor; }
            set
            {
                _selectedThemeColor = value;
                PropertyHolder.Settings.ThemeColor = value;
                OnPropertyChanged();
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


        //Methods
        public AppSettings()
        {
            _defaultInstance = this;

            AccentColors = new ObservableCollection<ColorPath>
            {
                new ColorPath
                {
                    Name = "Amber",
                    Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/amber.xaml"
                },
                new ColorPath
                {
                    Name = "Blue",
                    Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/blue.xaml"
                },
                new ColorPath
                {
                    Name = "Brown",
                    Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/brown.xaml"
                },
                new ColorPath
                {
                    Name = "Cobalt",
                    Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/cobalt.xaml"
                },
                new ColorPath
                {
                    Name = "Crimson",
                    Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/crimson.xaml"
                },
                new ColorPath
                {
                    Name = "Cyan",
                    Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/cyan.xaml"
                },
                new ColorPath
                {
                    Name = "Emerald",
                    Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/cobalt.xaml"
                },
                new ColorPath
                {
                    Name = "Green",
                    Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/green.xaml"
                },
                new ColorPath
                {
                    Name = "Indigo",
                    Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/indigo.xaml"
                },
                new ColorPath
                {
                    Name = "Lime",
                    Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/lime.xaml"
                },
                new ColorPath
                {
                    Name = "Magenta",
                    Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/magenta.xaml"
                },
                new ColorPath
                {
                    Name = "Mauve",
                    Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/mauve.xaml"
                },
                new ColorPath
                {
                    Name = "Olive",
                    Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/olive.xaml"
                },
                new ColorPath
                {
                    Name = "Orange",
                    Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/orange.xaml"
                },
                new ColorPath
                {
                    Name = "Pink",
                    Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/pink.xaml"
                },
                new ColorPath
                {
                    Name = "Purple",
                    Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/purple.xaml"
                },
                new ColorPath
                {
                    Name = "Red",
                    Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/red.xaml"
                },
                new ColorPath
                {
                    Name = "Sienna",
                    Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/sienna.xaml"
                },
                new ColorPath
                {
                    Name = "Steel",
                    Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/steel.xaml"
                },
                new ColorPath
                {
                    Name = "Taupe",
                    Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/taupe.xaml"
                },
                new ColorPath
                {
                    Name = "Violet",
                    Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/violet.xaml"
                },
                new ColorPath
                {
                    Name = "Yellow",
                    Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/yellow.xaml"
                }
            };
            ThemeColors = new ObservableCollection<ColorPath>
            {
                new ColorPath
                {
                    Name = "BaseDark",
                    Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/basedark.xaml"
                },
                new ColorPath
                {
                    Name = "BaseLight",
                    Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/baselight.xaml"
                }
            };

            _selectedAccentColor = PropertyHolder.Settings.AccentColor;
            _selectedThemeColor = PropertyHolder.Settings.ThemeColor;

            CollectionAccentView = CollectionViewSource.GetDefaultView(AccentColors);
            CollectionAccentView.CurrentChanged += CollectionAccentView_Changed;

            CollectionThemeView = CollectionViewSource.GetDefaultView(ThemeColors);
            CollectionThemeView.CurrentChanged += CollectionThemeView_Changed;
        }

        private void CollectionAccentView_Changed(object sender, EventArgs e)
        {
            CheckIfDeletable(ThemeColors, CollectionAccentView,
                out ResourceDictionary last, out bool isDeletable, out _accentColor);

            CreateResourceDictionary(isDeletable, last, AccentColor,
                PropertyHolder.Settings.AccentColor.Path, CollectionAccentView);
        }

        public void CollectionThemeView_Changed(object sender, EventArgs eventArgs)
        {
            CheckIfDeletable(AccentColors, CollectionThemeView,
                out ResourceDictionary last, out bool isDeletable, out _themeColor);

            CreateResourceDictionary(isDeletable, last, ThemeColor,
                PropertyHolder.Settings.ThemeColor.Path, CollectionThemeView);
        }

        private void CheckIfDeletable(
            ObservableCollection<ColorPath> collection,
            ICollectionView view, out ResourceDictionary last, out bool isDeletable, out string colorPath)
        {
            ColorPath item = view.CurrentItem as ColorPath;
            colorPath = item?.Path;
            last = Application.Current.Resources.MergedDictionaries
                .Last();
            isDeletable = false;
            foreach (ColorPath color in collection)
            {
                string _colorPath = color.Path;
                isDeletable = last.ToString() == _colorPath;
                if (!isDeletable)
                {
                    break;
                }
            }
        }

        private void CreateResourceDictionary(bool isDeletable, ResourceDictionary last,
            string colorPath, string settingsColor, ICollectionView view)
        {
            if (isDeletable)
            {
                try
                {
                    last.Source = new Uri(colorPath);
                }
                catch (Exception)
                {
                    last.Source = new Uri(settingsColor);
                }
            }

            else
            {
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
                {
                    Source = new Uri(colorPath)
                });
            }
        }
    }
}