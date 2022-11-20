using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.ViewModels
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public int BookId { get; set; }

        public string BookTitle { get; set; }
        public ICollection<Author> BookAuthor { get; set; }
        public string BookIsbn { get; set; }
        public string BookPublisher{ get; set; }
        public string BookLanguage { get; set; }
        public string BookGenre{ get; set; }
    }
}