using System.Threading.Tasks;
using BookStore.Models;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Seed
{
    public static class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "my_admin@outlook.com";
            string password = "_Aa123456";
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
                User admin = new User { Email = adminEmail, UserName = adminEmail };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Administrator");
                }
            }
        }
    }
}