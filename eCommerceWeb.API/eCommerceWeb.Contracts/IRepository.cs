using eCommerceWeb.Entity;
using System.Collections.Generic;

namespace eCommerceWeb.Contracts
{
    public interface IRepository
    {
        int AddCategory(Category category);
        Category GetCategoryById(int id);
        List<Category> GetAllCategories();
    }
}
