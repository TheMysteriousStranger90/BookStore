using System.Collections.Generic;

namespace BookStore.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<OrderItem> Author { get; set; }
        public int? Year { get; set; }
        public string Isbn { get; set; }
        public string Publisher { get; set; }
        public string Language { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}