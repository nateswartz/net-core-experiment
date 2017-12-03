using System.Net.Http;

namespace NETCoreExperimentalWebApp.Infrastructure
{
    public interface IHttpClientAccessor 
    {
        HttpClient Client { get; }
    }

    public class DefaultHttpClientAccessor : IHttpClientAccessor
    {
        public HttpClient Client { get; }

        public DefaultHttpClientAccessor()
        {
            Client = new HttpClient();
        }
    }
}
