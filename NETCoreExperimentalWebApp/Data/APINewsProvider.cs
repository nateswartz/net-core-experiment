using System;
using System.Net.Http;
using NETCoreExperimentalWebApp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace NETCoreExperimentalWebApp.Data
{
    public class APINewsProvider : INewsProvider
    {
        private readonly HttpClient _client;

        public APINewsProvider()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://newsapi.org/v1/");
        }

        public NewsArticleModel GetArticle()
        {
            var result = _client.GetAsync("articles?sortBy=top&apiKey=5933e800d1bc401f88e92f56caff0aca&source=ars-technica").Result;
            var data = result.Content.ReadAsStringAsync().Result;
            var response = JsonConvert.DeserializeObject<NewsArticlesResponse>(data);
            return response.articles[0];
        }

        public IList<NewsArticleModel> GetArticles()
        {
            var result = _client.GetAsync("articles?sortBy=top&apiKey=5933e800d1bc401f88e92f56caff0aca&source=ars-technica").Result;
            var data = result.Content.ReadAsStringAsync().Result;
            var response = JsonConvert.DeserializeObject<NewsArticlesResponse>(data);
            return response.articles;
        }
    }
}
