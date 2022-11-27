using Book_management_auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_management_auth.Repositry
{
    public interface IBookRepositry
    {
        Task<IEnumerable<Book>> GetBooks();

        Task<Book> GetBook(int id);

        Task<Book> AddBook(Book book);

        Task<Book> DeleteBook(int id);

        Task<Book> UpdateBook(Book book);
    }
}