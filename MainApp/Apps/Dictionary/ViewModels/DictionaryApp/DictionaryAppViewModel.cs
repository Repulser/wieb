using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Dictionary.ViewModels
{
    public class DictionaryAppViewModel
    {
        public static DictionaryAppViewModel Instance { get; set; }
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
        }

        public ObservableCollection<string> Tags { get; private set; } 
            = new ObservableCollection<string>();

        public ObservableCollection<UrbanItemViewModel> Results { get; set; } =
            new ObservableCollection<UrbanItemViewModel>();

        public ICollectionView ResultsView { get; set; }

        public static string SearchBoxText { get; set; }

        public Brush SearchBoxBrush { get; set; }

        public Thickness TextBoxThickness { get; set; }

        public SearchCommand Search { get; }
    }
}
