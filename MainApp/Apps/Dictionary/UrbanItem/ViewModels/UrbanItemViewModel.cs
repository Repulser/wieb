using UrbanDictionnet;

namespace Dictionary.ViewModels
{
    public class UrbanItemViewModel : NotifyPropertyChanged
    {
        private int _selectedTabIndex = 0;

        public UrbanItemViewModel(DefinitionData definitionData)
        {
            Instance = this;
            Definition = definitionData;
        }

        public static UrbanItemViewModel Instance { get; set; }

        public DefinitionData Definition { get; }

        public string Title => Definition.Word;

        public string DefinitionString
        {
            get => Definition.Definition;
            set => Definition.Definition = value;
        }

        public int Upvotes
        {
            get => Definition.ThumbsUp;
            set
            {
                Definition.ThumbsUp = value;
                OnPropertyChanged();
            }
        }

        public int Downvotes => Definition.ThumbsDown;

        public string Author => Definition.Author;

        public string Example => Definition.Example;

        #region Header

        public int SelectedTabIndex
        {
            get => _selectedTabIndex;
            set
            {
                _selectedTabIndex = value;
                OnPropertyChanged();
            }
        }

        public string PausePlayText { get; set; }
            = "\xE768";

        #endregion
    }
}