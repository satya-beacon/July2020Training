using System;
using System.Collections.Generic;
using System.Text;
using UsermanagementApp.Contracts;
using UsermanagementApp.Entity;
using UsermanagementApp.Entity.ViewModels;

namespace UsermanagementApp.Business
{
    public class ContactDomain : IContactDomain
    {
        private IRepository repository;
        public ContactDomain(IRepository repository)
        {
            this.repository = repository;
        }
        public void AddContact(UserContact userContact)
        {
            this.repository.AddContact(userContact);
        }

        public ContactViewModel GetAllContacts(ContactFilterViewModel filterViewModel)
        {
            return this.repository.GetAllContacts(filterViewModel);
        }
    }
}
