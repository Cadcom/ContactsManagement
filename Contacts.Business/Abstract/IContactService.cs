using Contacts.Shared.DTOs;
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
        List<Person> getAllPersons(int page = 1, int size = 20);
        Task<Person> getPersonByIDAsync(Guid id);
        Task<Person> InsertOrUpdatePersonAsync(Person person);
        Task DeletePersonAsync(Guid id);

        List<Contact> getAllContacts(int page = 1, int size = 20);
        Task<Contact> getContactByIDAsync(Guid id);
        Task<Contact> InsertOrUpdateContactAsync(Contact person);
        Task DeleteContactAsync(Guid id);
        List<Contact> GetContactsByPersonID(Guid id);

        List<Report> GetReport();
    }
}
