using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanDictionnet;
namespace Dictionary.UrbanItem
{
    class UrbanItemViewModel
    {
        private DefinitionData Definition { get; set; }

        public UrbanItemViewModel(DefinitionData definitionData)
        {
            Definition = definitionData;         
        }

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
