using eCommerceWeb.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerceWeb.DataAccess
{
    public class ECommerceDbContext : DbContext
    {
        private readonly IConfiguration configuration;
        public ECommerceDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=sbx-01-sql-cti-ctidm.corp.fmglobal.com,1010;Database=eCommerceDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("Category");
        }

        public DbSet<Category> Categories { get; set; }
    }
}
