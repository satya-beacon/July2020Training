using Microsoft.EntityFrameworkCore;
using WebLoginSystem.Entity;

namespace WebLoginSystem.DataAccess
{
    public class WebLoginDbContext : DbContext
    {
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=sbx-01-sql-cti-ctidm.corp.fmglobal.com,1010;Database=WebLoginDb;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Userprofile> Userprofiles { get; set; }
        public DbSet<UserCredentail> UserCredentails { get; set; }
    }
}
