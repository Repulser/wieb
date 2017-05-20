using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Threading;
using UrbanDictionnet;

namespace Dictionary.ViewModels
{
    public class DictionaryAppViewModel : NotifyPropertyChanged
    {
        //Private members
        private static string _searchBoxText;
        private static ObservableCollection<string> _suggestionsCollection;

        //Methods
        public DictionaryAppViewModel()
        {
            Instance = this;
            Search = new SearchCommand(this);
            Voice = new VoiceRecognizeCommand();

            ResultsView = CollectionViewSource.GetDefaultView(Results);
            ResultsView.MoveCurrentToPosition(0);
            Results.CollectionChanged += (sender, args) =>
            {
                ResultsView.MoveCurrentToFirst();
            };

            SuggestionsCollection = new ObservableCollection<string>();
        }

        //Public fields
        public static DictionaryAppViewModel Instance { get; set; }

        public static ObservableCollection<string> SuggestionsCollection
        {
            get => _suggestionsCollection;
            set
            {
                _suggestionsCollection = value;
                OnStaticPropertyChanged();
            }
        }

        public static string SearchBoxText
        {
            get => _searchBoxText;
            set
            {
                if (_searchBoxText == value) return;
                _searchBoxText = value;
                Dispatcher.CurrentDispatcher.BeginInvoke(new Action(async () =>
                {
                    List<string> suggestionsList = await new UrbanClient()
                        .GetAutocompletionFor(value);
                    
                    SuggestionsCollection.Clear();
                    foreach (var item in suggestionsList)
                    {
                        SuggestionsCollection.Add(item);
                    }
                }));
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
        
        public VoiceRecognizeCommand Voice { get; }
    }
}
