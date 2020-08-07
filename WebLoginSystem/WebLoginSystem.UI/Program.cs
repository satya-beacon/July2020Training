using Microsoft.Extensions.Configuration;
using System;
using System.IO;

using WebLoginSystem.Business;
using WebLoginSystem.Entity;

namespace WebLoginSystem.UI
{
    class Program
    {
        private static IConfiguration configuration;
        static void Main(string[] args)
        {
            InitConfiguration();

            IBusiness business = new Business.Business(configuration);
            //business.AddUser(new Userprofile() { FirstName = "John", LastName = "Boldizar", Email = "john@gmail.com", Telephone = "11111", DateRegistered = DateTime.Now, UserCredentail = new UserCredentail() { Username = "satya", Password = "satya@123" } });

            var user = business.ValidateUser("satya", "satya@123");
        }

        static void InitConfiguration()
        {
            configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        }
        
    }
}
