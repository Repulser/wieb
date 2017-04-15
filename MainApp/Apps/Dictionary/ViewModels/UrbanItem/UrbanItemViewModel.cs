using System;
using System.Windows;
using System.Windows.Media;
using UrbanDictionnet;

namespace Dictionary.ViewModels
{
    public class UrbanItemViewModel : NotifyPropertyChanged
    {
        private SolidColorBrush _thumbsUpFill;
        private SolidColorBrush _thumbsDownFill;

        public UrbanItemViewModel(DefinitionData definitionData)
        {
            Instance = this;
            Definition = definitionData;
            ThumbsUpFill = new SolidColorBrush();
            ThumbsDownFill = new SolidColorBrush();
        }

        public bool ThumbsDownIsChecked { get; set; }

        public bool ThumbsUpIsChecked { get; set; }

        public SolidColorBrush ThumbsUpFill
        {
            get => _thumbsUpFill;
            set
            {
                _thumbsUpFill = value;
                OnPropertyChanged();
            }
        }

        public SolidColorBrush ThumbsDownFill
        {
            get => _thumbsDownFill;
            set
            {
                _thumbsDownFill = value; OnPropertyChanged();
            }
        }

        public static UrbanItemViewModel Instance { get; set; }

        public DefinitionData Definition { get; }

        public string Title => Definition.Word;

        public string DefinitionString
        {
            get => Definition.Definition;
            set => Definition.Definition = value;
        }

        public int Upvotes => Definition.ThumbsUp;

        public int Downvotes => Definition.ThumbsDown;

        public string Author => Definition.Author;

        public string Example => Definition.Example;
    }
}