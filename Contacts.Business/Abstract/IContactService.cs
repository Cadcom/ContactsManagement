using Contacts.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Business.Abstract
{
    public interface IContactService
    {
        List<Person> getAllPersons();
        Task<Person> getPersonByIDAsync(Guid id);
        Task<Person> InsertOrUpdatePersonAsync(Person person);
        Task DeletePersonAsync(Guid id);

        List<Contact> getAllContacts();
        Task<Contact> getContactByIDAsync(Guid id);
        Task<Contact> InsertOrUpdateContactAsync(Contact person);
        Task DeleteContactAsync(Guid id);
    }
}
