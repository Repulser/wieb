using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using Dictionary.UrbanItem.ViewModels;

namespace Dictionary.ViewModels
{
    public class DictionaryAppViewModel : NotifyPropertyChanged
    {
        private ICollectionView _resultsView;
        private UrbanItemViewModel _currentItem;
        public static DictionaryAppViewModel Instance { get; private set; }

        public DictionaryAppViewModel()
        {
            Search = new SearchCommand(this);
            Voice = new RecognizeVoiceCommand();

            ResultsView = CollectionViewSource.GetDefaultView(Results);
            ResultsView.MoveCurrentToFirst();
            CurrentItem = ResultsView.CurrentItem as UrbanItemViewModel;
            Instance = this;
        }

        public ObservableCollection<string> Tags { get; private set; }
            = new ObservableCollection<string>();

        public ObservableCollection<UrbanItemViewModel> Results { get; set; }
            = new ObservableCollection<UrbanItemViewModel>();

        public UrbanItemViewModel CurrentItem
        {
            get { return _currentItem; }
            set
            {
                _currentItem = value;
                OnPropertyChanged();
            }
        }

        public ICollectionView ResultsView
        {
            get { return _resultsView; }
            set
            {
                _resultsView = value;
                OnPropertyChanged();
            }
        }

        public static string SearchBoxText { get; set; }

        public Brush SearchBoxBrush { get; set; }

        public Thickness TextBoxThickness { get; set; }

        public SearchCommand Search { get; }

        public RecognizeVoiceCommand Voice { get; }
    }
}