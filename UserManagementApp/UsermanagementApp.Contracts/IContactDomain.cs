using System.Collections.Generic;
using UsermanagementApp.Entity;
using UsermanagementApp.Entity.ViewModels;

namespace UsermanagementApp.Contracts
{
    public interface IContactDomain
    {
        void AddContact(UserContact userContact);

        ContactViewModel GetAllContacts(ContactFilterViewModel filterViewModel);
    }
}
