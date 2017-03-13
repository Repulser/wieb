using UrbanDictionnet;

namespace Dictionary.ViewModels
{
    public class UrbanItemViewModel
    {

        public UrbanItemViewModel(DefinitionData definitionData)
        {
            Definition = definitionData;
        }

        private DefinitionData Definition { get; }

        public string Title => $"{Definition.Author}'s definition for {Definition.Word}";

        public string DefinitionString
        {
            get { return Definition.Definition; }
            set { Definition.Definition = value; }
        }

        public int Upvotes => Definition.ThumbsUp;
        public int Downvotes => Definition.ThumbsDown;

        public string Example => Definition.Example;
    }
}