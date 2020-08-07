using Microsoft.Extensions.Configuration;
using WebLoginSystem.DataAccess;
using WebLoginSystem.Entity;

namespace WebLoginSystem.Business
{
    public class Business : IBusiness
    {
        private IRepository repository;
        private IConfiguration configuration;

        public Business(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.repository = new Repository(configuration.GetConnectionString("DefaultConnectionString"));
        }

        public void AddUser(Userprofile userprofile)
        {
            this.repository.AddUser(userprofile);            
        }

        public Userprofile ValidateUser(string username, string password)
        {
            return this.repository.ValidateUser(username, password);
        }
    }
}
