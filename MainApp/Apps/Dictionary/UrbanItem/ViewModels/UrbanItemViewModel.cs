using System.Windows.Media.Animation;
using UrbanDictionnet;

namespace Dictionary.ViewModels
{
    public class UrbanItemViewModel : NotifyPropertyChanged
    {
        private int _selectedTabIndex;

        private int _upVotes;
        private int _downVotes;

        public UrbanItemViewModel(DefinitionData definitionData)
        {
            Instance = this;
            Definition = definitionData;

            PausePlayText = "\xE768";
            SelectedTabIndex = 0;

            _upVotes = Definition.ThumbsUp;
            _downVotes = Definition.ThumbsDown;
        }

        public static UrbanItemViewModel Instance { get; set; }

        public DefinitionData Definition { get; }

        public string Title => Definition.Word;

        private string _pausePlayText;

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

        public int Downvotes
        {
            get => Definition.ThumbsDown;
            set
            {
                Definition.ThumbsDown = value;
                OnPropertyChanged();
            }
        }

        public string Author => Definition.Author;

        public string Example => Definition.Example;

        public void Like()
        {
            if (Upvotes == _upVotes)
            {
                Upvotes ++;
            }
            else
            {
                Downvotes --;
                Upvotes ++;
            }
        }

        public void Dislike()
        {
            if (Downvotes == _downVotes)
            {
                Downvotes ++;
            }
            else
            {
                Upvotes --;
                Downvotes ++;
            }
        }

        public int SelectedTabIndex
        {
            get => _selectedTabIndex;
            set
            {
                _selectedTabIndex = value;
                OnPropertyChanged();
            }
        }

        public string PausePlayText
        {
            get => _pausePlayText;
            set
            {
                _pausePlayText = value;
                OnPropertyChanged();
            }
        }
    }
}