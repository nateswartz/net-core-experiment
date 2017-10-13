using Microsoft.EntityFrameworkCore;
using NETCoreExperimentalWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace NETCoreExperimentalWebApp.Data
{
    public class EfBookDataProvider : IBookDataProvider
    {
        private readonly WebAppDbContext _context;
        public EfBookDataProvider(WebAppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<BookModel> GetAll()
        {
            return _context.Book.ToList();
        }

        public BookModel Get(int? id)
        {
            return _context.Book.SingleOrDefault(m => m.id == id);
        }

        public BookModel Create(BookModel book)
        {
            var result = _context.Add(book).Entity;
            _context.SaveChanges();
            return result;
        }

        public bool Delete(int? id)
        {
            var book = _context.Book.SingleOrDefault(m => m.id == id);
            _context.Book.Remove(book);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public bool Update(int id, BookModel book)
        {
            try
            {
                _context.Update(book);
                var result = _context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(book.id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.id == id);
        }
    }
}
