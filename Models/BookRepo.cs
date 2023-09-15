using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LibraryMVCApp.Models
{
    public class BookRepo : IRepository<Book>
    {
        private readonly LibraryContext _context;
        public BookRepo(LibraryContext context)
        {
            _context = context;
        }

        public async Task<Book> GetById(int id)
        {
            Book book = await _context.Books.FindAsync(id);
            return book;
        }

        public async Task<List<Book>> GetAll()
        {
            return await _context.Books.ToListAsync();
        }

        public bool Add(Book book)
        {
            if(book != null)
            {
                _context.Books.Add(book);
                int rowsEffected = _context.SaveChanges();
                if(rowsEffected > 0)
                    return true;
            }
            return false;
        }

        public bool Remove(int id)
        {
            Book book = _context.Books.Find(id);
            if(book != null)
            {
                _context.Books.Remove(book);
                int rowsEffected = _context.SaveChanges();
                if(rowsEffected > 0)
                    return true;
            }
            return false;
        }

        public bool Update(int id,Book book)
        {
            if(book != null)
            {
                Book bookToUpdate = _context.Books.Find(id);
                if(bookToUpdate != null)
                {
                    bookToUpdate.Title = book.Title;
                    bookToUpdate.Author = book.Author;
                    bookToUpdate.Genre = book.Genre;
                    int rowsEffected = _context.SaveChanges();
                    if(rowsEffected > 0)
                        return true;
                }
            }
            return false;
        }
    }
}