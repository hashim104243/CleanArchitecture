using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Context;
using Persistance.Seed;

namespace Persistance
{
    public static class ServiceExtention
    {
        public static void AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            DefaultUser.SeedUserAsync(services.BuildServiceProvider());
            DefaultRoles.SeedRolesAsync(services.BuildServiceProvider());
            //return services;
        }
    }
}
