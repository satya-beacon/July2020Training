using BlogPostDemo.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogPostDemo.BusinessLogic
{
    public class CustomerDomain : ICustomerDomain
    {
        IRepository repository;

        public CustomerDomain()
        {
            this.repository = new Repository();
        }
        public void TransferAccountBalance(int fromAccount, int toAccount, decimal amount)
        {
            this.repository.TransferAccountBalance(fromAccount, toAccount, amount);
        }
    }
}
