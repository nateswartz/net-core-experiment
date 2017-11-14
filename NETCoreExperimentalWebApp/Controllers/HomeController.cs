using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NETCoreExperimentalWebApp.Models;
using NETCoreExperimentalWebApp.Data;

namespace NETCoreExperimentalWebApp.Controllers
{
    public class HomeController : Controller
    {
        private INewsProvider _newsProvider;
        public HomeController(INewsProvider newsProvider)
        {
            _newsProvider = newsProvider;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetArticles([FromBody]int category)
        {
            var articles = _newsProvider.GetArticles((ArticleCategories)category);
            return new ObjectResult(articles);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
