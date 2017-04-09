﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Threading;
using UrbanDictionnet;

namespace Dictionary.ViewModels
{
    public class DictionaryAppViewModel : NotfiyPropertyChanged
    {
        //Private members
        private static string _searchBoxText;
        private static ObservableCollection<string> _suggestionsCollection;
        public static DictionaryAppViewModel Instance { get; set; }

        //Methods
        public DictionaryAppViewModel()
        {
            Instance = this;
            Search = new SearchCommand(this);

            ResultsView = CollectionViewSource.GetDefaultView(Results);
            ResultsView.MoveCurrentToPosition(0);
            Results.CollectionChanged += (sender, args) =>
            {
                ResultsView.MoveCurrentToFirst();
            };

            SuggestionsCollection = new ObservableCollection<string>();
        }

        //Public fields
        public static ObservableCollection<string> SuggestionsCollection
        {
            get { return _suggestionsCollection; }
            set
            {
                _suggestionsCollection = value;
                OnStaticPropertyChanged();
            }
        }

        public static string SearchBoxText
        {
            get
            {
                return _searchBoxText;
            }
            set
            {
                if (_searchBoxText != value)
                {
                    _searchBoxText = value;
                    Dispatcher.CurrentDispatcher.BeginInvoke(new Action(async () =>
                    {
                        List<string> suggestionsList = await new UrbanClient()
                            .GetAutocompletionFor(value);

                        
                        SuggestionsCollection.Clear();
                        foreach (string item in suggestionsList)
                        {
                            SuggestionsCollection.Add(item);
                        }
                    }));   
                }
            }
        }

        public ObservableCollection<string> Tags { get; private set; } 
            = new ObservableCollection<string>();

        public ObservableCollection<UrbanItemViewModel> Results { get; set; } 
            = new ObservableCollection<UrbanItemViewModel>();

        public ICollectionView ResultsView { get; set; }

        public Brush SearchBoxBrush { get; set; }

        public Thickness TextBoxThickness { get; set; }

        public SearchCommand Search { get; }
    }
}
