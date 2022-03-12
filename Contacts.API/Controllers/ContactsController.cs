using Contacts.Business.Abstract;
using Contacts.Business.Concrete;
using Contacts.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ContactsController : Controller
    {
        IContactService service;
        public ContactsController(IContactService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Insert or Update Person Method. If person.Guid is null than this is an add property else this is an update
        /// property. So finds the person from database and update it.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("InsertOrUpdatePerson")]
        public async Task<IActionResult> InsertOrUpdatePersonAsync(Person person)
        {
            if (ModelState.IsValid)
            {
                var result = await service.InsertOrUpdatePersonAsync(person);
                return Json(result);
            }
            else return BadRequest(ModelState);
        }


        /// <summary>
        /// Insert or Update Contact Method. If contact.Guid is null than this is an add property else this is an update
        /// property. So finds the contact from database and update it.
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("InsertOrUpdateContact")]
        public async Task<IActionResult> InsertOrUpdateContactAsync(Contact contact)
        {
            if (ModelState.IsValid)
            {
                var result = await service.InsertOrUpdateContactAsync(contact);
                return Json(result);
            }
            else return BadRequest(ModelState);
        }

        /// <summary>
        /// Deletes the person by given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeletePerson")]
        public async Task DeletePersonAsync(Guid id)
        {
            await service.DeletePersonAsync(id);
        }

        /// <summary>
        /// Deletes the contact by given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteContact")]
        public async Task DeleteContactAsync(Guid id)
        {
             await service.DeleteContactAsync(id);
        }


        /// <summary>
        /// Gets the Person data by person id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetPersonByID")]
        public async Task<IActionResult> GetPersonByIDAsync(Guid id)
        {
            var result=await service.getPersonByIDAsync(id);
            return Json(result);
        }


        /// <summary>
        /// Gets the Contact data by person id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetContactByID")]
        public async Task<IActionResult> GetContactByIDAsync(Guid id)
        {
            var result=await service.getContactByIDAsync(id);
            return Json(result);
        }

        /// <summary>
        /// Get all contact list which given person id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetContactsByPersonID")]
        public IActionResult GetContactsByPersonID(Guid id)
        {
            var result = service.GetContactsByPersonID(id);
            return Json(result);
        }


        /// <summary>
        /// Gets all persons from database. No filter, No parameter
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllPersons")]
        public IActionResult GetAllPersons()
        {
            var result = service.getAllPersons();
            return Json(result);
        }


        /// <summary>
        /// Gets all contacts from database. No filter, No parameter
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllContacts")]
        public IActionResult GetAllContacts()
        {
            var result = service.getAllContacts();
            return Json(result);
        }
    }
}
