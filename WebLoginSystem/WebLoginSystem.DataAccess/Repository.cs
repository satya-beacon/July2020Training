using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebLoginSystem.Entity;

namespace WebLoginSystem.DataAccess
{
    public class Repository : IRepository
    {
        private WebLoginDbContext dbContext;
        public Repository(string connectionString)
        {
            this.dbContext = new WebLoginDbContext();
        }
        public void AddUser(Userprofile userprofile)
        {
            this.dbContext.Userprofiles.Add(userprofile);
            this.dbContext.SaveChanges();
        }

        public Userprofile ValidateUser(string username, string password)
        {
            var userInfo = this.dbContext.Userprofiles.Include(u => u.UserCredentail)
                            .Where(u => u.UserCredentail.Username == username && u.UserCredentail.Password == password).FirstOrDefault();

            return userInfo;
        }
    }
}
