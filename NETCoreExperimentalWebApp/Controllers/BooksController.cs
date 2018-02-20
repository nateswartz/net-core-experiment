using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETCoreExperimentalWebApp.Data;
using NETCoreExperimentalWebApp.Models;

namespace NETCoreExperimentalWebApp.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly IBookDataProvider _bookDataProvider;

        private readonly UserManager<ApplicationUser> _userManager;

        public BooksController(IBookDataProvider bookDataProvider, UserManager<ApplicationUser> userManager)
        {
            _bookDataProvider = bookDataProvider;
            _userManager = userManager;
        }

        // GET: Books
        public IActionResult Index()
        {
            var id = _userManager.GetUserId(User);
            return View(_bookDataProvider.GetForUser(id));
        }

        public IActionResult VueIndex()
        {
            return View();
        }

        // GET: Books/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _bookDataProvider.Get(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var id = _userManager.GetUserId(User);
            return new ObjectResult(_bookDataProvider.GetForUser(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody]BookModel book)
        {
            book.userId = _userManager.GetUserId(User);
            book.id = 0;
            if (ModelState.IsValid)
            {
                var newBook = _bookDataProvider.Create(book);
                return new ObjectResult(newBook);
            }
            return BadRequest("Book data incomplete");
        }

        [HttpPost]
        public IActionResult Edit(int id, [FromBody]BookModel book)
        {
            if (ModelState.IsValid)
            {
                _bookDataProvider.Update(id, book);
                return new ObjectResult(true);
            }
            return BadRequest("Book data incomplete");
        }

        // POST: Books/Delete/5
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _bookDataProvider.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
