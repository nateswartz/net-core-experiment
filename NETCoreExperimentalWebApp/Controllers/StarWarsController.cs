using Microsoft.AspNetCore.Mvc;
using NETCoreExperimentalWebApp.Data;

namespace NETCoreExperimentalWebApp.Controllers
{
    public class StarWarsController : Controller
    {
        private IStarWarsDataProvider _provider;

        public StarWarsController(IStarWarsDataProvider provider)
        {
            _provider = provider;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Person(int id)
        {
            var person = _provider.GetPerson(id);
            return View(person);
        }

        [HttpGet]
        public IActionResult Starships()
        {
            var starships = _provider.GetStarships();
            return View(starships);
        }

        [HttpGet]
        public IActionResult Species()
        {
            var species = _provider.GetSpecies();
            return View(species);
        }
    }
}