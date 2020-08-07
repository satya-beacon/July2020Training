using WebLoginSystem.Entity;

namespace WebLoginSystem.Business
{
    public interface IBusiness
    {
        void AddUser(Userprofile userprofile);
        Userprofile ValidateUser(string username, string password);
    }
}
