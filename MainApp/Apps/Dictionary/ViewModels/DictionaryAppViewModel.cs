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

            ResultsView = CollectionViewSource.GetDefaultView(Results);
            ResultsView.CurrentChanged += ResultsView_CurrentChanged;
            ResultsView.MoveCurrentToFirst();
            Instance = this;
        }

        private void ResultsView_CurrentChanged(object sender, System.EventArgs e)
        {
            CurrentItem = ResultsView.CurrentItem as UrbanItemViewModel;
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
                if (Equals(value, _currentItem)) return;
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

        public string SearchBoxText { get; set; }

        public Brush SearchBoxBrush { get; set; }

        public Thickness TextBoxThickness { get; set; }

        public SearchCommand Search { get; }
    }
}