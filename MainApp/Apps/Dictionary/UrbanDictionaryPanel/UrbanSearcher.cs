using System.Linq;
using System.Threading.Tasks;
using UrbanDictionnet;

namespace Dictionary.UrbanDictionaryPanel
{
    internal class UrbanSearcher
    {
        private UrbanClient Client { get; } = new UrbanClient();
        public async Task<WordDefine> Find(string word)
        {
            return await Client.GetWordAsync(word);
        }
        public async Task<DefinitonData> FindFirst(string word)
        {
            return (await Client.GetWordAsync(word))[0];
        }
    }
}