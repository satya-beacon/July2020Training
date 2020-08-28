using eCommerceWeb.Contracts;
using eCommerceWeb.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerceWeb.Business
{
    public class CategoryBusiness : ICategoryBusiness
    {
        private readonly IRepository repository;

        public CategoryBusiness(IRepository repository)
        {
            this.repository = repository;
        }

        public int AddCategory(Category category)
        {
            return this.repository.AddCategory(category);
        }

        public List<Category> GetAllCategories()
        {
            return this.repository.GetAllCategories();
        }

        public Category GetCategoryById(int id)
        {
            return this.repository.GetCategoryById(id);
        }
    }
}
