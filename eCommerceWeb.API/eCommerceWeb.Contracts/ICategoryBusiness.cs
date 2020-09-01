using eCommerceWeb.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerceWeb.Contracts
{
    public interface ICategoryBusiness
    {
     
        /// <summary>
        /// A method to save category
        /// </summary>
        /// <param name="category">Pass the category object</param>
        /// <returns>return status</returns>
        Task<int> AddCategory(Category category);

        Task<Category> GetCategoryById(int id);
        Task<List<Category>> GetAllCategories();
    }
}
