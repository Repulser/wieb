using System.Linq;
using UrbanDictionnet;

namespace Dictionary.UrbanDicionaryPanel.Models
{
    internal class UrbanSearcher
    {
        private DefinitonData Find(string word)
        {
            UrbanClient client = new UrbanClient();

            var searchResultList = client.GetWordAsync(word)
                .Result
                .OrderBy(w => client.GetWordAsync(w.Word)
                    .Result
                    .List
                    .Count)
                .First();

            return searchResultList;
        }
    }
}