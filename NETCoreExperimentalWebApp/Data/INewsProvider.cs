using NETCoreExperimentalWebApp.Models;
using System.Collections.Generic;

namespace NETCoreExperimentalWebApp.Data
{
    public interface INewsProvider
    {
        NewsArticleModel GetArticle();
        IList<NewsArticleModel> GetArticles(ArticleCategories category);
    }

    public enum ArticleCategories
    {
        Tech, News
    }
}
