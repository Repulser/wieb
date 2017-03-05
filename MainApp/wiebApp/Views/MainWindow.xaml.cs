﻿using System;
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

namespace wiebApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainBtn1_Click(object sender, RoutedEventArgs e)
        {
            //MainTabControl.SelectedIndex = 1;
        }

        private void DropGlowLabel_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void SettingsItemTile_Click(object sender, RoutedEventArgs e)
        {
            // temp code for ui demo
            MainTab_Grid.Visibility = Visibility.Collapsed;
            DictionaryApp_Grid.Visibility = Visibility.Visible;
            titlebarControl.BackButtonVisibility = Visibility.Visible;
        }

        private void TitlebarControl_BackButton_Click(object sender, RoutedEventArgs e)
        {
            // temp code for ui demo
            MainTab_Grid.Visibility = Visibility.Visible;
            DictionaryApp_Grid.Visibility = Visibility.Collapsed;
            titlebarControl.BackButtonVisibility = Visibility.Collapsed;
        }
    }
}
