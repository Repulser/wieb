﻿using System.Threading.Tasks;
using UrbanDictionnet;

namespace Dictionary.Services
{
    internal class UrbanSearcher
    {
        private readonly UrbanClient client = new UrbanClient();

        private UrbanClient GetClient()
        {
            return client;
        }

        public async Task<WordDefine> Find(string word)
        {
            return await GetClient().GetWordAsync(word);
        }
        public async Task<DefinitionData> FindFirst(string word)
        {
            return (await GetClient().GetWordAsync(word))[0];
        }
    }
}