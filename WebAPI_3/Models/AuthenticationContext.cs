using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace WebAPI_3.Models
{
    public class AuthenticationContext : IdentityDbContext
    { 
        public AuthenticationContext(DbContextOptions options):base(options)
        { 
        }

        public DbSet<ApplicationUser> applicationUsers { get; set; }
    }
}
