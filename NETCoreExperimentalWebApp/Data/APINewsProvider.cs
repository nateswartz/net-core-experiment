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
        private readonly string _apiKeyQueryStringParam = "apiKey=5933e800d1bc401f88e92f56caff0aca";
        private readonly string _queryStringParams = "language=en&country=us";

        public APINewsProvider()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://newsapi.org/v2/");
        }

        public NewsArticleModel GetArticle()
        {
            var result = _client.GetAsync($"top-headlines?sources=ars-technica&{_queryStringParams}&{_apiKeyQueryStringParam}").Result;
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
            var result = _client.GetAsync($"top-headlines?sources={source}&{_queryStringParams}&{_apiKeyQueryStringParam}").Result;
            var data = result.Content.ReadAsStringAsync().Result;
            var response = JsonConvert.DeserializeObject<NewsArticlesResponse>(data);
            return response.articles;
        }

        public IList<NewsArticleModel> GetArticles(IList<string> sources)
        {
            var sourcesQueryString = string.Join(",", sources);
            var result = _client.GetAsync($"top-headlines?sources={sourcesQueryString}&{_queryStringParams}&{_apiKeyQueryStringParam}").Result;
            var data = result.Content.ReadAsStringAsync().Result;
            var response = JsonConvert.DeserializeObject<NewsArticlesResponse>(data);
            return response.articles;
        }

        public IList<NewsSourceModel> GetSources()
        {
            var result = _client.GetAsync($"sources?{_queryStringParams}&{_apiKeyQueryStringParam}").Result;
            var data = result.Content.ReadAsStringAsync().Result;
            var response = JsonConvert.DeserializeObject<NewsSourcesResponse>(data);
            return response.sources;
        }
    }
}
