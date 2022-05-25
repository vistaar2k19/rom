using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Authentication.Models;

namespace AuthenticationDbContext.Data
{
    public class AuthenticationContext : DbContext
    {
        public AuthenticationContext (DbContextOptions<AuthenticationContext> options)
            : base(options)
        {
        }

        public DbSet<UserLogin> UserLogin { get; set; }
    }
}
