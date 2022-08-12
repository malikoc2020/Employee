using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace EFCore.Context
{
    public class ContextSeed
    {
        public static async Task SeedRoleAsync(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            await roleManager.CreateAsync(new Role(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new Role(Roles.User.ToString()));
        }
        public static async Task SeedUserAsync(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            List<User> users = new List<User>();

            User systemUser = new User()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "System",
                MiddleName="",
                LastName = "System",
                UserName = "System",
                Email = "System@System.com",
                PhoneNumber = "System",
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                DefaultRole = "User"
            };
            users.Add(systemUser);


            User Admin = new User()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Admin",
                MiddleName = "",
                LastName = "Admin",
                UserName = "Admin",
                Email = "Admin@Admin.com",
                PhoneNumber = "",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                DefaultRole = "Admin"
            };
            users.Add(Admin);

            User user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "user",
                MiddleName = "",
                LastName = "user",
                UserName = "user",
                Email = "user@user.com",
                PhoneNumber = "",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                DefaultRole = "User"
            };
            users.Add(user);


 

            foreach (var usr in users)
            {
                var userEntity = await userManager.FindByEmailAsync(usr.Email);
                if (userEntity == null)
                {
                    try
                    {
                        var result = await userManager.CreateAsync(usr, "Password%5");
                        if (result.Succeeded && !String.IsNullOrEmpty(usr.DefaultRole))
                        {
                            await userManager.AddToRoleAsync(usr, usr.DefaultRole);
                        }
                    }
                    catch (Exception e)
                    {
                        //throw e;
                    }

                }
            }



        }
    }
}
