using System;
using System.Collections.Generic;
using NETCoreExperimentalWebApp.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace NETCoreExperimentalWebApp.Data
{
    public class APIStarWarsProvider : IStarWarsDataProvider
    {
        private HttpClient _client;

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
            var starships = new List<StarshipModel>();
            var count = 0;
            var page = 1;
            do
            {
                var result = _client.GetAsync("starships/?page=" + page).Result;
                var data = result.Content.ReadAsStringAsync().Result;
                var responseObj = JsonConvert.DeserializeObject<StarshipResponse>(data);
                count = responseObj.count;
                starships.AddRange(responseObj.results);
                page++;
            } while (count > starships.Count);
            return starships;
        }
    }
}
