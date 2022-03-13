using Contacts.Shared.DTOs;
using Contacts.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Data.Abstract
{
    public interface IDatabaseHelper
    {
        public Task<Person> insertOrUpdatePersonAsync(Person person);
        public Task DeletePersonAsync(Guid guid);
        public Task<Person> GetPersonAsync(Guid guid);
        public List<Person> GetAllPersons(int page = 1, int size = 20);

        public Task<Contact> insertOrUpdateContactAsync(Contact contact);
        public Task DeleteContactAsync(Guid guid);
        public Task<Contact> GetContactAsync(Guid guid);
        public List<Contact> GetAllContacts(int page = 1, int size = 20);
        public List<Contact> GetContactsByPersonID(Guid guid);
        public List<Report> GetReport();
    }
}
