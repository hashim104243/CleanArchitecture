using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Persistance.IdentityModel
{
    public class ApplicationUser : IdentityUser<string>
    {
        public string? FirstName { get; set; }
        public string? LasrName { get; set; }
        public string? Gender { get; set; }

    }
}
