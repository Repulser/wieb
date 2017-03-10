using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using Dictionary.UrbanItem.ViewModels;
using Dictionary.UrbanItem.Views;

namespace Dictionary.ViewModels
{
    public class DictionaryAppViewModel
    {
        public DictionaryAppViewModel()
        {
            Search = new SearchCommand(this);
        }

        public ObservableCollection<string> Tags { get; private set; } 
            = new ObservableCollection<string>();

        public ObservableCollection<UrbanItemViewModel> Results { get; set; } =
            new ObservableCollection<UrbanItemViewModel>();

        public string SearchBoxText { get; set; }

        public Brush SearchBoxBrush { get; set; }

        public Thickness TextBoxThickness { get; set; }

        public SearchCommand Search { get; }
    }
}
