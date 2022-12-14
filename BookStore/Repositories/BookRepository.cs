using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Context;
using BookStore.Interfaces;
using BookStore.Models;

namespace BookStore.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(ApplicationContext context) : base(context)
        {
        }

        public IEnumerable<Book> GetBooksByGenre(string genre)
        {
            return _context.Set<Book>().Where(p => p.Genre == genre)
                .ToList();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            try
            {
                return _context.Set<Book>()
                    .OrderBy(p => p.Title)
                    .ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}