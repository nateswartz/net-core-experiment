using NETCoreExperimentalWebApp.Models.NewsModels;
using System.Collections.Generic;

namespace NETCoreExperimentalWebApp.Data
{
    public interface ICryptoTickerProvider
    {
        IList<CryptocurrencyModel> GetTickerValues();
    }

}
