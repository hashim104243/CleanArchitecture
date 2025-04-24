using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Persistance.IdentityModel;

namespace Persistance.Seed
{
    public static  class DefaultUser
    {
        public static async Task SeedUserAsync(IServiceProvider serviceProvider)
        {
            var userManager=serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var defaultUser = new ApplicationUser();
            defaultUser.Id = Guid.NewGuid().ToString();

            defaultUser.FirstName = "hashim";
            defaultUser.Gender = "Male";
            defaultUser.Email = "superadmin@gmail.com";
            defaultUser.UserName = "superAdmin";
            defaultUser.EmailConfirmed = true;
            defaultUser.PhoneNumberConfirmed = true;
            defaultUser.TwoFactorEnabled = false;
            defaultUser.LockoutEnabled = false;
           

                var Userresult=await userManager.FindByEmailAsync(defaultUser.Email);
                if (Userresult==null)
                {
                    var result=await userManager.CreateAsync(defaultUser,"#SuperAdmin123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(defaultUser,"SuperAdmin");
                }
                }

            
        }
    }
}
