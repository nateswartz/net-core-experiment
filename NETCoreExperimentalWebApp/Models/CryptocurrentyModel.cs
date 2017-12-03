using Newtonsoft.Json;

namespace NETCoreExperimentalWebApp.Models.NewsModels
{
    public class CryptocurrencyModel
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        [JsonProperty(PropertyName = "Price_USD")]
        public decimal Price { get; set; }
        [JsonProperty(PropertyName = "percent_change_1h")]
        public decimal PercentChangeOneHour { get; set; }
        [JsonProperty(PropertyName = "percent_change_24h")]
        public decimal PercentChangeOneDay { get; set; }
        [JsonProperty(PropertyName = "percent_change_7d")]
        public decimal PercentChangeOneWeek { get; set; }
    }
}
