using System.Collections.Generic;
using System.Linq;
using BookStore.Context;
using BookStore.Interfaces;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationContext context) : base(context)
        {
        }

        public IEnumerable<Order> GetOrdersByUserEmail(string email, bool includeItems)
        {
            if (includeItems)
            {
                return _context.Set<Order>()
                    .Include(o => o.Items)
                    .ThenInclude(i => i.Book)
                    .Where(o => o.User.Email == email)
                    .ToList();
            }
            else
            {
                return _context.Set<Order>()
                    .Where(o => o.User.Email == email)
                    .ToList();
            }
        }
    }
}