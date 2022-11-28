using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [NotMapped] public ICollection<Author> Author { get; set; }
        public int? Year { get; set; }
        public string Isbn { get; set; }
        public string Publisher { get; set; }
        public string Language { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}