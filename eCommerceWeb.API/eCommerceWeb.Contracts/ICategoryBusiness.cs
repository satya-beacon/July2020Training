using eCommerceWeb.Entity;
using System.Collections.Generic;


namespace eCommerceWeb.Contracts
{
    public interface ICategoryBusiness
    {
     
        /// <summary>
        /// A method to save category
        /// </summary>
        /// <param name="category">Pass the category object</param>
        /// <returns>return status</returns>
        int AddCategory(Category category);

        Category GetCategoryById(int id);
        List<Category> GetAllCategories();
    }
}
