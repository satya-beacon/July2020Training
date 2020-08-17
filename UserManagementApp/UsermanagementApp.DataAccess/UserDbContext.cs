using Microsoft.EntityFrameworkCore;
using UsermanagementApp.Entity;

namespace UsermanagementApp.DataAccess
{
    public class UserDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=sbx-01-sql-cti-ctidm.corp.fmglobal.com,1010;Database=WebLoginDb;Trusted_Connection=True;");
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
