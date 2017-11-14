using NETCoreExperimentalWebApp.Models.NewsModels;
using System.Collections.Generic;

namespace NETCoreExperimentalWebApp.Data
{
    public interface INewsProvider
    {
        NewsArticleModel GetArticle();

        IList<NewsSourceModel> GetSources();

        IList<NewsArticleModel> GetArticles(ArticleCategories category);

        IList<NewsArticleModel> GetArticles(IList<string> sources);
    }

    public enum ArticleCategories
    {
        Tech, News
    }
}
