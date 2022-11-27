using Book_management_auth.Models;
using Book_management_auth.Repositry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_management_auth.Services
{
    public class BookBL
    {
        private readonly IBookRepositry _bookRepositry;

        public BookBL()
        {
        }

        public BookBL(IBookRepositry bookRepositry)
        {
            _bookRepositry = bookRepositry;
        }
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookRepositry.GetBooks();
            //tried to create buisness logic access from here but getting NULL 
        }
        public async Task<Book> AddBook(Book book)
        {
            return await _bookRepositry.AddBook(book);
        }
        public async Task<Book> GetBook(int id)
        {
            var result = await _bookRepositry.GetBook(id);
            if (result != null)
            {
                return result;
            }
            return null;
        }
        public async Task<Book> UpdateBook(int id, Book book)
        {
            var updatedBook = await _bookRepositry.UpdateBook(book);
            return book;
        }
        public async Task<Book> DeleteBook(int id)
        {
            return await _bookRepositry.DeleteBook(id);
        }
    }
}

