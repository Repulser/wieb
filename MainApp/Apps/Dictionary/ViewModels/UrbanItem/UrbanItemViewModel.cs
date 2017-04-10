using UrbanDictionnet;

namespace Dictionary.ViewModels
{
    public class UrbanItemViewModel : NotfiyPropertyChanged
    {
        public UrbanItemViewModel(DefinitionData definitionData)
        {
            Instance = this;
            Definition = definitionData;
        }

        public static UrbanItemViewModel Instance { get; set; }

        private DefinitionData Definition { get; }

        public string Title
        {
            get { return Definition.Word; }
        }

        public string DefinitionString
        {
            get { return Definition.Definition; }
            set { Definition.Definition = value; }
        }

        public int Upvotes
        {
            get { return Definition.ThumbsUp; }
        }

        public int Downvotes
        {
            get { return Definition.ThumbsDown; }
        }

        public string Author
        {
            get { return Definition.Author; }
        }

        public string Example
        {
            get { return Definition.Example; }
        }
    }
}