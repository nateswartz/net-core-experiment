using NETCoreExperimentalWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NETCoreExperimentalWebApp.Data
{
    public interface IBookData
    {
        IEnumerable<Book> GetAll();
        Book Get(int? id);

        Book Create(Book book);
        bool Delete(int? id);
        bool Update(int id, Book book);

    }

    public class EFBookData : IBookData
    {
        private readonly NETCoreExperimentalWebAppContext _context;
        public EFBookData(NETCoreExperimentalWebAppContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Book.ToList();
        }

        public Book Get(int? id)
        {
            return _context.Book.SingleOrDefault(m => m.id == id);
        }

        public Book Create(Book book)
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

        public bool Update(int id, Book book)
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
