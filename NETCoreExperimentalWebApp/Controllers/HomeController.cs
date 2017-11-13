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
            var articles = _newsProvider.GetArticles();
            return View(articles);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
