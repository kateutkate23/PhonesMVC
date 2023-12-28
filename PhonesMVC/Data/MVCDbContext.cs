using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhonesMVC.Models;

namespace PhonesMVC.Data
{
    public class MVCDbContext : IdentityDbContext<AppUser>
    {
        public MVCDbContext(DbContextOptions options) : base(options) 
        {

        }

        public DbSet<PhoneClient> PhoneClients { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
