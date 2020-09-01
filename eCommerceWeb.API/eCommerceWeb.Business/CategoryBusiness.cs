using eCommerceWeb.Contracts;
using eCommerceWeb.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceWeb.Business
{
    public class CategoryBusiness : ICategoryBusiness
    {
        private readonly IRepository repository;

        public CategoryBusiness(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> AddCategory(Category category)
        {
            return await this.repository.AddCategory(category);
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await this.repository.GetAllCategories();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await this.repository.GetCategoryById(id);
        }
    }
}
