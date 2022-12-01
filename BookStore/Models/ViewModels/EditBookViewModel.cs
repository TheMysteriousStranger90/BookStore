using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models.ViewModels
{
    public class EditBookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Author> Author { get; set; } = null;
        public int? Year { get; set; }
        public string Isbn { get; set; }
        public string Publisher { get; set; }
        public string Language { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}