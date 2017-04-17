using UrbanDictionnet;

namespace Dictionary.ViewModels
{
    public class UrbanItemViewModel : NotifyPropertyChanged
    {
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

        public int Upvotes => Definition.ThumbsUp;

        public int Downvotes => Definition.ThumbsDown;

        public string Author => Definition.Author;

        public string Example => Definition.Example;
    }
}