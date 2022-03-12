using Contacts.Business.Abstract;
using Contacts.Data.Abstract;
using Contacts.Data.Concrate;
using Contacts.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Business.Concrete
{
    public class ContactService : IContactService
    {
        IDatabaseHelper databaseHelper;
        public ContactService()
        {
            databaseHelper=new DatabaseHelper();
        }

        public async Task DeleteContactAsync(Guid id)
        {
            await databaseHelper.DeleteContactAsync(id);
        }

        public async Task DeletePersonAsync(Guid id)
        {
            await databaseHelper.DeletePersonAsync(id);
        }

        public List<Contact> getAllContacts()
        {
            return databaseHelper.GetAllContacts();
        }

        public List<Person> getAllPersons()
        {
            return databaseHelper.GetAllPersons();
        }

        public async Task<Contact> getContactByIDAsync(Guid id)
        {
            return await databaseHelper.GetContactAsync(id);
        }

        public List<Contact> GetContactsByPersonID(Guid id)
        {
            return databaseHelper.GetContactsByPersonID(id);
        }

        public async Task<Person> getPersonByIDAsync(Guid id)
        {
            return await databaseHelper.GetPersonAsync(id);
        }

        public async Task<Contact> InsertOrUpdateContactAsync(Contact contact)
        {
            return await databaseHelper.insertOrUpdateContactAsync(contact);
        }

        public async Task<Person> InsertOrUpdatePersonAsync(Person person)
        {
            return await databaseHelper.insertOrUpdatePersonAsync(person);
        }
    }
}
