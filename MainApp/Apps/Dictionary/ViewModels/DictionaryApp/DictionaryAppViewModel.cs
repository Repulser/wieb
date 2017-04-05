using System.Collections.ObjectModel;
using System.ComponentModel;
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

            ResultsView = CollectionViewSource.GetDefaultView(Results);
            Results.CollectionChanged += (sender, args) =>
            {
                ResultsView.MoveCurrentToLast();
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
