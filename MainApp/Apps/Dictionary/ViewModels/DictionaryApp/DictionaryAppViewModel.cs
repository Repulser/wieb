﻿using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Dictionary.ViewModels
{
    public class DictionaryAppViewModel
    {
        public DictionaryAppViewModel()
        {
            Search = new SearchCommand(this);

            ResultsView = (ListCollectionView) CollectionViewSource.GetDefaultView(Results);
            ResultsView.MoveCurrentToFirst();
        }

        public ObservableCollection<string> Tags { get; private set; } 
            = new ObservableCollection<string>();

        public ObservableCollection<UrbanItemViewModel> Results { get; set; } =
            new ObservableCollection<UrbanItemViewModel>();

        public ListCollectionView ResultsView { get; set; }

        public static string SearchBoxText { get; set; }

        public Brush SearchBoxBrush { get; set; }

        public Thickness TextBoxThickness { get; set; }

        public SearchCommand Search { get; }
    }
}
