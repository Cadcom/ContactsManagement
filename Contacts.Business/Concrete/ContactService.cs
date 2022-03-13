using Contacts.Business.Abstract;
using Contacts.Data.Abstract;
using Contacts.Data.Concrate;
using Contacts.Shared.DTOs;
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
        public ContactService(IDatabaseHelper databaseHelper)
        {
            this.databaseHelper = databaseHelper;
        }

        public async Task DeleteContactAsync(Guid id)
        {
            await databaseHelper.DeleteContactAsync(id);
        }

        public async Task DeletePersonAsync(Guid id)
        {
            await databaseHelper.DeletePersonAsync(id);
        }

        public List<Contact> getAllContacts(int page = 1, int size = 20)
        {
            return databaseHelper.GetAllContacts(page,size).ToList();
        }

        public List<Person> getAllPersons(int page = 1, int size = 20)
        {
            var result= databaseHelper.GetAllPersons(page, size);
            return result;
        }

        public async Task<Contact> getContactByIDAsync(Guid id)
        {
            return await databaseHelper.GetContactAsync(id);
        }

        public List<Contact> GetContactsByPersonID(Guid id)
        {
            return databaseHelper.GetContactsByPersonID(id).ToList();
        }

        public async Task<Person> getPersonByIDAsync(Guid id)
        {
            return await databaseHelper.GetPersonAsync(id);
        }

        public List<Report> GetReport()
        {
            return databaseHelper.GetReport();
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
