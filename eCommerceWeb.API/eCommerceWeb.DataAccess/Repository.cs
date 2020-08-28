using eCommerceWeb.Contracts;
using eCommerceWeb.Entity;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;


namespace eCommerceWeb.DataAccess
{
    public class Repository : IRepository
    {
        private readonly ECommerceDbContext eCommerceDbContext;

        public Repository(IConfiguration configuration)
        {
            eCommerceDbContext = new ECommerceDbContext(configuration);
        }

        public int AddCategory(Category category)
        {
            this.eCommerceDbContext.Categories.Add(category);
            this.eCommerceDbContext.SaveChanges();
            return category.Id;
        }

        public List<Category> GetAllCategories()
        {
            return this.eCommerceDbContext.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return this.eCommerceDbContext.Categories.FirstOrDefault(c => c.Id == id);
        }
    }
}
