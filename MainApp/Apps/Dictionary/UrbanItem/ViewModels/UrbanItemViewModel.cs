using System.Collections.Generic;
using System.Windows.Data;
using Dictionary.Services;
using UrbanDictionnet;

namespace Dictionary.ViewModels
{
    public class UrbanItemViewModel : NotifyPropertyChanged
    {
        private readonly int _downVotes;
        private readonly int _upVotes;

        private string _pausePlayText;
        private int _selectedTabIndex;

        public UrbanItemViewModel(DefinitionData definitionData)
        {
            Instance = this;
            Definition = definitionData;

            PausePlayText = "\xE768";
            SelectedTabIndex = 0;

            _upVotes = Definition.ThumbsUp;
            _downVotes = Definition.ThumbsDown;

            Languages = (ListCollectionView) CollectionViewSource.GetDefaultView(_languages);
        }

        public static UrbanItemViewModel Instance { get; set; }

        private List<SeleniumTranslate.Languages> _languages;

        public ListCollectionView Languages { get; set; }

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
    }
}