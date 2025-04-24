using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Persistance.IdentityModel;

namespace Persistance.Seed
{
    public static class DefaultRoles
    {
        public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
        {
           var roleManager= serviceProvider.GetRequiredService<Microsoft.AspNetCore.Identity.RoleManager<ApplicationRole>>();
            var roles = new[] { "SuperAdmin", "Admin", "Basic" };

            foreach (var roleName in roles)
            {
                var existingRole = await roleManager.FindByNameAsync(roleName);

                if (existingRole == null)
                {
                    var newRole = new ApplicationRole
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = roleName,
                        NormalizedName = roleName.ToUpper()
                    };
                    await roleManager.CreateAsync(newRole);
                }
            }
            //var superAdmin = new ApplicationRole();
            //superAdmin.Id = "a1111111 - aaaa - aaaa - aaaa - aaaaaaaaaaaa";
            //superAdmin.Name = RolesType.SuperAdmin.ToString();
            //superAdmin.NormalizedName = RolesType.SuperAdmin.ToString().ToUpper();
            //await roleManager.CreateAsync(superAdmin);

            //var Admin=new ApplicationRole();
            //Admin.Id = "b2222222-bbbb-bbbb-bbbb-bbbbbbbbbbbb";
            //Admin.Name = RolesType.Admin.ToString();
            //Admin.NormalizedName = RolesType.Admin.ToString().ToUpper();
            //await roleManager.CreateAsync(Admin);

            //var basic=new ApplicationRole();
            //basic.Id = "c3333333-cccc-cccc-cccc-cccccccccccc";
            //basic.Name = RolesType.Basic.ToString();
            //basic.NormalizedName = RolesType.Basic.ToString().ToUpper();

            //await roleManager.CreateAsync(basic);




        }
    }
}
