using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public User User { get; set; }
        public string? UserId { get; set; }
        public ICollection<OrderItem> Items { get; set; }
        
    }
}