using System.Collections.Generic;

namespace NETCoreExperimentalWebApp.Models.NewsModels
{
    public class NewsArticlesResponse
    {
        public IList<NewsArticleModel> articles;
    }

    public class NewsArticleModel
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string UrlToImage { get; set; }
        public string PublishedAt { get; set; }
    }
}