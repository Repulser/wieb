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

        public string Title
        {
            get { return $"{Definition.Author}'s definition for {Definition.Word}"; }
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

        public string Example
        {
            get { return Definition.Example; }
        }
    }
}