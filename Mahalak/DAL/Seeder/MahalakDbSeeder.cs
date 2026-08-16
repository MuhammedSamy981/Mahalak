using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Mahalak;
public static class MahalakDbSeeder
    {
    public static string[] roles = new[] { "Manager", "Admin", "User" };

    public static async Task SeedDataAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        await SeedRolesAsync(roleManager);
        await SeedUsersAsync(userManager);

    }
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            
          if (await roleManager.Roles.AnyAsync()) return;


                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole(role));
                }


        }

    private static async Task SeedUsersAsync(UserManager<User> userManager)
    {
      if (await userManager.Users.AnyAsync()) return;
/*Gender = "ذكر",
            Birthdate = DateTime.Parse("1/8/1995"),*/

       var user = new User
        {
            FirstName = "محمد",
            LastName = "سامي",
            UserName = "MuhammedSamy@mahalak.net",
            Email = "MuhammedSamy@mahalak.net",
            PhoneNumber = string.Empty,
            EmailConfirmed = true,
        };

        var result = await userManager.CreateAsync(user, "P@ssw0rd123");

        if (result.Succeeded)
        {
            //Console.WriteLine("\n\nDone\n\n");
            await userManager.AddToRoleAsync(user, roles[0]);
        } 
             
    }

    }