using WebLoginSystem.Entity;

namespace WebLoginSystem.DataAccess
{
    public interface IRepository
    {
        void AddUser(Userprofile userprofile);
        Userprofile ValidateUser(string username, string password);
    }
}
