using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NETCoreExperimentalWebApp.Models;

namespace NETCoreExperimentalWebApp.Controllers
{
    public class StarWarsController : Controller
    {
        private HttpClient _client;

        public StarWarsController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://swapi.co/api/");
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Person(int id)
        {
            var result = _client.GetAsync("people/" + id).Result;
            var data = result.Content.ReadAsStringAsync().Result;
            return View(JsonConvert.DeserializeObject<PersonModel>(data));
        }
    }
}