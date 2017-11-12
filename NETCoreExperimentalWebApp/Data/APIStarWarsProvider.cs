using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NETCoreExperimentalWebApp.Models.StarWarsModels;
using System.Linq;

namespace NETCoreExperimentalWebApp.Data
{
    public class APIStarWarsProvider : IStarWarsDataProvider
    {
        private readonly HttpClient _client;

        private List<StarshipModel> _starshipCache;

        private List<SpeciesModel> _speciesCache;

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
            if (_starshipCache != null)
            {
                return _starshipCache;
            }

            _starshipCache = GetObjects<StarshipModel, StarshipResponse>("starships");

            return _starshipCache;
        }

        public IEnumerable<SpeciesModel> GetSpecies()
        {
            if (_starshipCache != null)
            {
                return _speciesCache;
            }

            _speciesCache = GetObjects<SpeciesModel, SpeciesResponse>("species");

            return _speciesCache;
        }

        private void IgnoreErrorConvertingUnknown(object sender, ErrorEventArgs errorArgs)
        {
            var currentError = errorArgs.ErrorContext.Error.Message;
            if (currentError.Contains("unknown"))
            {
                errorArgs.ErrorContext.Handled = true;
            }
        }

        private List<T> GetObjects<T, U>(string url) where U : APIResponse<T>
        {
            var settings = new JsonSerializerSettings
            {
                Error = IgnoreErrorConvertingUnknown
            };

            var objects = new List<T>();
            int count;
            var page = 1;
            do
            {
                var result = _client.GetAsync($"{url}/?page={page}").Result;
                var data = result.Content.ReadAsStringAsync().Result;
                var responseObj = JsonConvert.DeserializeObject<U>(data, settings);
                count = responseObj.Count;
                objects.AddRange(responseObj.Results);
                page++;
            } while (count > objects.Count);
            return objects;
        }
    }
}
