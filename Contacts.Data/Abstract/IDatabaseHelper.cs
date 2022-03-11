using Contacts.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Data.Abstract
{
    public interface IDatabaseHelper
    {
        public Task<Person> insertOrUpdatePersonAsync(Person person);
        public Task DeletePersonAsync(Guid guid);
        public Task<Person> GetPersonAsync(Guid guid);
        public List<Person> GetAllPersons();

        public Task<Contact> insertOrUpdateContactAsync(Contact contact);
        public Task DeleteContactAsync(Guid guid);
        public Task<Contact> GetContactAsync(Guid guid);
        public List<Contact> GetAllContacts();
    }
}
