using System.Collections.Generic;
using BookStore.Models;

namespace BookStore.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<Order> GetOrdersByUserEmail(string email, bool includeItems);
    }
}