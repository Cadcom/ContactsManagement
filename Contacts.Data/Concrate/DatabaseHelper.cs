using Contacts.Data.Abstract;
using Contacts.Shared.DTOs;
using Contacts.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Data.Concrate
{
    public class DatabaseHelper: IDatabaseHelper
    {
        ContactsDBContext db;
        public DatabaseHelper(ContactsDBContext db)
        {
            this.db= db;
        }

        public async Task<Person> insertOrUpdatePersonAsync(Person person) {
            
            
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
            var deletePerson = await GetPersonAsync(guid);

            if (deletePerson != null)
                db.Remove(deletePerson);

            db.SaveChanges();
        }

        public async Task<Person> GetPersonAsync(Guid guid)
        {
            var person = await db.FindAsync<Person>(guid);

            return person;
        }

        public List<Person> GetAllPersons(int page = 1, int size = 20)
        {
            if (size==0)
                return db.Persons.AsQueryable().ToList();
            else
                return db.Persons.AsQueryable().Skip((page - 1) * size).Take(size).ToList();

        }

        public async Task<Contact> insertOrUpdateContactAsync(Contact contact)
        {


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
            var deleteContact = await GetContactAsync(guid);

            if (deleteContact != null)
                db.Remove(deleteContact);

            db.SaveChanges();
        }

        public async Task<Contact> GetContactAsync(Guid guid)
        {
            var contact = await db.FindAsync<Contact>(guid);

            return contact;
        }

        public List<Contact> GetAllContacts(int page=1, int size=20)
        {
            if (size == 0)
                return db.Contacts.AsQueryable().ToList();
            else
                return db.Contacts.AsQueryable().Skip((page - 1) * size).Take(size).ToList();
        }

        public List<Contact> GetContactsByPersonID(Guid guid)
        {
            var contacts= db.Contacts.AsQueryable().Where(x => x.PersonID == guid).ToList();

            return contacts;
        }

        public List<Report> GetReport()
        {
            var myList = db.Contacts;

            var contacts = myList.Where(x => x.Type == InfoType.Location).GroupBy(t => t.Info)
                           .Select (t => new Report
                           {
                               Konum = t.Key,
                               Kisi = t.Distinct().Count(),
                               Telefon = (myList.Where(x => x.Type == InfoType.PhoneNumber && x.Info.Equals(t.Key)).Count())
                           }).ToList< Report>();

            return contacts;
        }
    }
}
