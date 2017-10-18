using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NETCoreExperimentalWebApp.Models.StarWarsModels;

namespace NETCoreExperimentalWebApp.Data
{
    public class APIStarWarsProvider : IStarWarsDataProvider
    {
        private readonly HttpClient _client;

        public APIStarWarsProvider()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://swapi.co/api/");
        }

        public PersonModel GetPerson(int personId)
        {
            var result = _client.GetAsync("people/" + personId).Result;
            var data = result.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<PersonModel>(data);
        }

        public IEnumerable<StarshipModel> GetStarships()
        {
            var settings = new JsonSerializerSettings
            {
                Error = IgnoreErrorConvertingUnknown
            };

            var starships = new List<StarshipModel>();
            int count;
            var page = 1;
            do
            {
                var result = _client.GetAsync("starships/?page=" + page).Result;
                var data = result.Content.ReadAsStringAsync().Result;
                var responseObj = JsonConvert.DeserializeObject<StarshipResponse>(data, settings);
                count = responseObj.count;
                starships.AddRange(responseObj.results);
                page++;
            } while (count > starships.Count);
            return starships;
        }

        public void IgnoreErrorConvertingUnknown(object sender, ErrorEventArgs errorArgs)
        {
            var currentError = errorArgs.ErrorContext.Error.Message;
            if (currentError.Contains("unknown"))
            {
                errorArgs.ErrorContext.Handled = true;
            }
        }
    }
}
