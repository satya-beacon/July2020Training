using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UsermanagementApp.Entity;

namespace UsermanagementApp.DataAccess
{
    public class UserDbContext : DbContext
    {
        private IConfiguration configuration;
        public UserDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.configuration["SqlConnectionString"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfile>().ToTable("UserProfile");
            modelBuilder.Entity<UserContact>().ToTable("UserContacts");
        }

        public DbSet<UserProfile> Userprofiles { get; set; }
        public DbSet<UserContact> UserContacts { get; set; }
    }
}
