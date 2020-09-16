using eCommerceWeb.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerceWeb.Contracts
{
    public interface IRepository
    {
        Task<int> AddCategory(Category category);
        Task<Category> GetCategoryById(int id);
        Task<List<Category>> GetAllCategories();

        Task AddUser(User user);
        Task<User> ValidateUser(string username, string password);
        Task<List<User>> GetUsers();
        Task<User> GetUserById(int id);

        Task<User> GetUserByName(string username);

    }
}
