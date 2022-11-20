using System.Collections.Generic;
using BookStore.Models;

namespace BookStore.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        IEnumerable<Book> GetBooksByGenre(string genre);
    }
}