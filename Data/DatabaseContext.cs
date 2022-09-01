using Microsoft.EntityFrameworkCore;
using mswebapiserver.Models;

namespace mswebapiserver.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AgentUser> AgentUsers { get; set; }
        public DbSet<AddressDetail> AddressDetails { get; set; }

    }
}
