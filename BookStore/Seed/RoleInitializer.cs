using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using BookStore.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Seed
{
    public static class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "lev.myshkin@outlook.com";
            string password = "Myshkin0101";
            if (await roleManager.FindByNameAsync("Administrator") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Administrator"));
            }
            if (await roleManager.FindByNameAsync("User") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new User { FirstName = "Lev", LastName = "Myshkin", Email = adminEmail, UserName = adminEmail };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Administrator");
                }
            }
        }


        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book()
                {
                    Id = 1, Title = "Fyodor Dostoevsky - Demons",
                    Author = new List<Author>()
                    {
                        new Author {Name = "Fyodor Dostoevsky"}
                    },
                    Year = 2008, Isbn = "978-0141441412", Publisher = "Penguin Classics", Language = "English", Genre = "Classic Literature & Fiction", Price = new decimal(14.00)
                },
                new Book()
                {
                    Id = 2, Title = "Jane Austen - Emma",
                    Author = new List<Author>()
                    {
                        new Author {Name = "Jane Austen"}
                    },
                    Year = 2020, Isbn = "978-1840227963", Publisher = "Wordsworth Editions Ltd", Language = "English", Genre = "Classic Literature & Fiction", Price = new decimal(12.00)
                },
                new Book()
                {
                    Id = 3, Title = "Andrew Troelsen, Phillip Japikse - Pro C# 9 with .NET 5: Foundational Principles and Practices in Programming 10th ed. Edition",
                    Author = new List<Author>()
                    {
                        new Author {Name = "Andrew Troelsen"}, new Author() {Name = "Phillip Japikse"}
                    },
                    Year = 2021, Isbn = "978-1484269381", Publisher = "Apress", Language = "English", Genre = "Programming Languages", Price = new decimal(28.00)
                }
            );
        }
    }
}