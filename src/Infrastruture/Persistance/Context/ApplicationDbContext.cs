using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistance.IdentityModel;

namespace Persistance.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
      public DbSet<Product> Products { get; set; }
    }
}
