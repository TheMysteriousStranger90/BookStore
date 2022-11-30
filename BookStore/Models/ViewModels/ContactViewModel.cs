using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.ViewModels
{
    public class ContactViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        [MaxLength(300)]
        public string Message { get; set; }
    }
}