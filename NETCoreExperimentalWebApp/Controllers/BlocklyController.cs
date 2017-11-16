using Microsoft.AspNetCore.Mvc;

namespace NETCoreExperimentalWebApp.Controllers
{
    public class BlocklyController : Controller
    {
        public IActionResult Editor()
        {
            return View();
        }
    }
}