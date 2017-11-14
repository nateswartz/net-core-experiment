using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using NETCoreExperimentalWebApp.Models.NewsModels;

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

        public IList<NewsArticleModel> GetArticles(ArticleCategories category)
        {
            var source = "";
            if (category == ArticleCategories.Tech)
            {
                source = "ars-technica";
            }
            else if (category == ArticleCategories.News)
            {
                source = "cnn";
            }
            var result = _client.GetAsync($"articles?sortBy=top&apiKey=5933e800d1bc401f88e92f56caff0aca&source={source}").Result;
            var data = result.Content.ReadAsStringAsync().Result;
            var response = JsonConvert.DeserializeObject<NewsArticlesResponse>(data);
            return response.articles;
        }

        public IList<NewsArticleModel> GetArticles(IList<string> sources)
        {
            var articles = new List<NewsArticleModel>();
            foreach (var source in sources)
            {
                var result = _client.GetAsync($"articles?sortBy=top&apiKey=5933e800d1bc401f88e92f56caff0aca&source={source}").Result;
                var data = result.Content.ReadAsStringAsync().Result;
                var response = JsonConvert.DeserializeObject<NewsArticlesResponse>(data);
                articles.AddRange(response.articles);
            }
            return articles;
        }

        public IList<NewsSourceModel> GetSources()
        {
            var result = _client.GetAsync("sources?apiKey=5933e800d1bc401f88e92f56caff0aca").Result;
            var data = result.Content.ReadAsStringAsync().Result;
            var response = JsonConvert.DeserializeObject<NewsSourcesResponse>(data);
            return response.sources;
        }
    }
}
