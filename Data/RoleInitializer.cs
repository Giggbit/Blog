using Blog.Models;
using Microsoft.AspNetCore.Identity;

namespace Blog.Data
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager) { 
            if(!roleManager.Roles.Any()) { 
                if(await roleManager.FindByNameAsync("Admin") == null) {
                    await roleManager.CreateAsync(new IdentityRole("Admin")) ;
                }

                if(await roleManager.FindByNameAsync("Editor") == null) {
                    await roleManager.CreateAsync(new IdentityRole("Editor")) ;
                }
            }

            if(!userManager.Users.Any()) {
                var users = new[]
                {
                    new { Email = "admin@gmail.com", Name = "Admin", Password = "qwerty" },
                    new { Email = "alex@gmail.com", Name = "Alex", Password = "123456" },
                    new { Email = "nick@gmail.com", Name = "Nick", Password = "654321" },
                    new { Email = "", Name = "", Password = "" }
                };

                foreach(var user in users) { 
                    if(await userManager.FindByEmailAsync(user.Email) == null) { 
                        User currentUser = new User { Email =  user.Email, Name = user.Name, UserName = user.Email };
                        IdentityResult result = await userManager.CreateAsync(currentUser, user.Password);
                        if(result.Succeeded) {
                            if (currentUser.Email.Equals("admin@gmail.com")) {
                                await userManager.AddToRoleAsync(currentUser, "Admin");
                            }
                            else {
                                await userManager.AddToRoleAsync(currentUser, "Editor");
                            }
                        }
                    }
                }
            }
        }
    }
}
