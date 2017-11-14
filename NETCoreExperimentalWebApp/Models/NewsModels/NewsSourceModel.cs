using System.Collections.Generic;

namespace NETCoreExperimentalWebApp.Models.NewsModels
{
    public class NewsSourcesResponse
    {
        public IList<NewsSourceModel> sources;
    }

    public class NewsSourceModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
    }
}