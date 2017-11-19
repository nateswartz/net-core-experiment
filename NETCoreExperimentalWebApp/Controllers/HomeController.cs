﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NETCoreExperimentalWebApp.Models;
using NETCoreExperimentalWebApp.Data;
using System.Collections.Generic;

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
        public IActionResult GetArticles([FromBody]List<string> sources)
        {
            var articles = _newsProvider.GetArticles(sources);
            return new ObjectResult(articles);
        }

        [HttpGet]
        public IActionResult GetSources()
        {
            var sources = _newsProvider.GetSources();
            return new ObjectResult(sources);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
