using Contacts.Data.Abstract;
using Contacts.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Data.Concrate
{
    public class DatabaseHelper: IDatabaseHelper
    {

        public async Task<Person> insertOrUpdatePersonAsync(Person person) {

            using var db = new ContactsDBContext(); 
            
            
            if (person.UUID == Guid.Empty)
            {
                await db.Persons.AddAsync(person);

            }
            else {
                db.Persons.Update(person);
            }
            await db.SaveChangesAsync();

            return person;
        }

        public async Task DeletePersonAsync(Guid guid)
        {
            using var db = new ContactsDBContext();
            var deletePerson = await GetPersonAsync(guid);

            if (deletePerson != null)
                db.Remove(deletePerson);

            db.SaveChanges();
        }

        public async Task<Person> GetPersonAsync(Guid guid)
        {
            using var db = new ContactsDBContext();
            var person = await db.FindAsync<Person>(guid);

            return person;
        }

        public List<Person> GetAllPersons()
        {
            using var db = new ContactsDBContext();
            var person = db.Persons.AsEnumerable().ToList();

            return person;
        }

        public async Task<Contact> insertOrUpdateContactAsync(Contact contact)
        {
            using var db = new ContactsDBContext();


            if (contact.UUID == Guid.Empty)
            {
                await db.Contacts.AddAsync(contact);

            }
            else
            {
                db.Contacts.Update(contact);
            }
            await db.SaveChangesAsync();

            return contact;
        }

        public async Task DeleteContactAsync(Guid guid)
        {
            using var db = new ContactsDBContext();
            var deleteContact = await GetContactAsync(guid);

            if (deleteContact != null)
                db.Remove(deleteContact);

            db.SaveChanges();
        }

        public async Task<Contact> GetContactAsync(Guid guid)
        {
            using var db = new ContactsDBContext();
            var contact = await db.FindAsync<Contact>(guid);

            return contact;
        }

        public List<Contact> GetAllContacts()
        {
            using var db = new ContactsDBContext();
            var contacts = db.Contacts.AsEnumerable().ToList();

            return contacts;
        }
    }
}
