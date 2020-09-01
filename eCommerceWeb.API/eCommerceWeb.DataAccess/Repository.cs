using eCommerceWeb.Contracts;
using eCommerceWeb.Entity;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceWeb.DataAccess
{
    public class Repository : IRepository
    {
        private readonly ECommerceDbContext eCommerceDbContext;

        public Repository(IConfiguration configuration)
        {
            eCommerceDbContext = new ECommerceDbContext(configuration);
        }

        public async Task<int> AddCategory(Category category)
        {
            this.eCommerceDbContext.Categories.Add(category);
            await this.eCommerceDbContext.SaveChangesAsync();
            return category.Id;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await Task.FromResult(this.eCommerceDbContext.Categories.ToList());
        }

        public async  Task<Category> GetCategoryById(int id)
        {
            return await Task.FromResult(this.eCommerceDbContext.Categories.FirstOrDefault(c => c.Id == id));
        }
    }
}
