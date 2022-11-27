using Book_management_auth.Authentication;
using Book_management_auth.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_management_auth.Repositry
{
    public class BookRepositry:IBookRepositry
    {
        private readonly ApplicationDBContext _context;
        public BookRepositry(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Book> AddBook(Book book)
        {
            var newbook = await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return newbook.Entity;

        }

        public async Task<Book> DeleteBook(int id)
        {
            var result = await _context.Books.Where(b => b.Id == id).FirstOrDefaultAsync();
            if (result != null)
            {
                _context.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Book> GetBook(int id)
        {
            return await _context.Books.FirstOrDefaultAsync(book => book.Id == id);
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> UpdateBook(Book book)
        {
            var toUpdateBook = await _context.Books.FirstOrDefaultAsync(b => b.Id == book.Id);
            if (toUpdateBook != null)
            {
                toUpdateBook.Id = book.Id;
                toUpdateBook.Name = book.Name;
                toUpdateBook.AuthorName = book.AuthorName;
                toUpdateBook.TotalPages = book.TotalPages;
                await _context.SaveChangesAsync();
                return toUpdateBook;
            }
            return null;
        }
    }
}
