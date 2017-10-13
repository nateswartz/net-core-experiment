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

        public JsonResult GetIndex()
        {
            return Json(_bookData.GetAll());
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

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        public IActionResult Create([Bind("id,Title,Author,Type,Image")] BookModel book)
        {
            if (ModelState.IsValid)
            {
                _bookData.Create(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        [HttpPost]
        public IActionResult CreateViaJSON([FromBody]BookModel book)
        {
            book.id = 0;
            if (ModelState.IsValid)
            {
                var newBook = _bookData.Create(book);
                return new ObjectResult(newBook);
            }
            return BadRequest("Book data incomplete");
        }

        // GET: Books/Edit/5
        public IActionResult Edit(int? id)
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

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult Edit(int id, [Bind("id,Title,Author,Type,Image")] BookModel book)
        {
            if (id != book.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bookData.Update(id, book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        [HttpPost]
        public IActionResult EditViaJSON(int id, [FromBody]BookModel book)
        {
            if (ModelState.IsValid)
            {
                _bookData.Update(id, book);
                return new ObjectResult(true);
            }
            return BadRequest("Book data incomplete");
        }

        // GET: Books/Delete/5
        public IActionResult Delete(int? id)
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

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _bookData.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
