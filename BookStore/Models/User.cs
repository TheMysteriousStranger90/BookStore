using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}