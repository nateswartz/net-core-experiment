using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NETCoreExperimentalWebApp.Data;
using NETCoreExperimentalWebApp.Models;

namespace NETCoreExperimentalWebApp.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly IBookData _bookData;

        public BooksController(IBookData bookData)
        {
            _bookData = bookData;
        }

        // GET: Books
        public IActionResult Index()
        {
            return View(_bookData.GetAll());
        }

        // GET: Books/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _bookData.Get(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost]
        public IActionResult Create([FromBody]BookModel book)
        {
            book.id = 0;
            if (ModelState.IsValid)
            {
                var newBook = _bookData.Create(book);
                return new ObjectResult(newBook);
            }
            return BadRequest("Book data incomplete");
        }

        [HttpPost]
        public IActionResult Edit(int id, [FromBody]BookModel book)
        {
            if (ModelState.IsValid)
            {
                _bookData.Update(id, book);
                return new ObjectResult(true);
            }
            return BadRequest("Book data incomplete");
        }

        // POST: Books/Delete/5
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _bookData.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
