using System;
using System.Net.Http;
using System.Collections.Generic;
using NETCoreExperimentalWebApp.Models.NewsModels;
using Newtonsoft.Json;
using NETCoreExperimentalWebApp.Infrastructure;

namespace NETCoreExperimentalWebApp.Data
{
    public class APICryptoTickerProvider : ICryptoTickerProvider
    {
        private readonly HttpClient _client;

        public APICryptoTickerProvider(IHttpClientAccessor httpClientAccessor)
        {
            _client = httpClientAccessor.Client;
            _client.BaseAddress = new Uri("https://api.coinmarketcap.com/v1/");
        }

        public IList<CryptocurrencyModel> GetTickerValues()
        {
            var result = _client.GetAsync("ticker").Result;
            var data = result.Content.ReadAsStringAsync().Result;
            var response = JsonConvert.DeserializeObject<List<CryptocurrencyModel>>(data);
            return response;
        }

    }
}
