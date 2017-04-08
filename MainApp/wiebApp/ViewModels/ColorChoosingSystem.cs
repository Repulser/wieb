using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using wiebApp.Models;
using wiebApp.Properties;

namespace wiebApp.ViewModels
{
    internal class ColorChoosingSystem : NotifyPropertyChanged
    {
        //Private Fields

        private ColorPath _selectedAccentColor;
        private ColorPath _selectedThemeColor;


        //Public Properties
        public static ColorChoosingSystem Instance { get; private set; }

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
                PropertyHolder.Settings.SelectedAccentColor = value;
                OnPropertyChanged();
            }
        }

        public ColorPath SelectedThemeColor
        {
            get { return _selectedThemeColor; }
            set
            {
                _selectedThemeColor = value;
                PropertyHolder.Settings.SelectedThemeColor = value;
                OnPropertyChanged();
            }
        }


        //Methods
        public ColorChoosingSystem()
        {
            Instance = this;

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
                    Name = "Dark",
                    Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/basedark.xaml"
                },
                new ColorPath
                {
                    Name = "Light",
                    Path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/baselight.xaml"
                }
            };

            CollectionAccentView = CollectionViewSource.GetDefaultView(AccentColors);
            CollectionAccentView.CurrentChanged += CollectionAccentView_Changed;

            CollectionThemeView = CollectionViewSource.GetDefaultView(ThemeColors);
            CollectionThemeView.CurrentChanged += CollectionThemeView_Changed;
            if (PropertyHolder.Settings.SelectedAccentColor != null)
            {
                SelectedAccentColor = AccentColors
                    .SingleOrDefault(
                        color =>
                            color.Path == PropertyHolder.Settings.SelectedAccentColor.Path &&
                            color.Name == PropertyHolder.Settings.SelectedAccentColor.Name);
            }
            else
            {
                SelectedAccentColor = AccentColors
                    .SingleOrDefault(
                        color => 
                            color.Name == "Red");
            }

            if (PropertyHolder.Settings.SelectedThemeColor != null)
            {
                SelectedThemeColor = ThemeColors
                    .SingleOrDefault(
                        color =>
                            color.Path == PropertyHolder.Settings.SelectedThemeColor.Path &&
                            color.Name == PropertyHolder.Settings.SelectedThemeColor.Name);
            }
            else
            {
                SelectedThemeColor = ThemeColors
                    .SingleOrDefault(
                        color => 
                            color.Name == "Light");
            }
        }

        private void CollectionAccentView_Changed(object sender, EventArgs e)
        {
            string colorPath = SelectedAccentColor.Path;
            CheckIfDeletable(ThemeColors, CollectionAccentView,
                out ResourceDictionary last, out bool isDeletable, out colorPath);

            CreateResourceDictionary(isDeletable, last, SelectedAccentColor.Path,
                PropertyHolder.Settings.SelectedAccentColor.Path, CollectionAccentView);
        }

        public void CollectionThemeView_Changed(object sender, EventArgs eventArgs)
        {
            string colorPath = SelectedThemeColor.Path;
            CheckIfDeletable(AccentColors, CollectionThemeView,
                out ResourceDictionary last, out bool isDeletable, out colorPath);

            CreateResourceDictionary(isDeletable, last, SelectedThemeColor.Path,
                PropertyHolder.Settings.SelectedThemeColor.Path, CollectionThemeView);
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

        private void CreateResourceDictionary(
            bool isDeletable, ResourceDictionary last,
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