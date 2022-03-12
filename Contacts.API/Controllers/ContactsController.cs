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
        public ContactsController()
        {
            service = new ContactService();
        }

        [HttpPost]
        [Route("InsertOrUpdatePerson")]
        public async Task<IActionResult> InsertOrUpdatePersonAsync(Person person)
        {
            var result= await service.InsertOrUpdatePersonAsync(person);
            return Json(result);
        }

        [HttpPost]
        [Route("InsertOrUpdateContact")]
        public async Task<IActionResult> InsertOrUpdateContactAsync(Contact contact)
        {
            var result = await service.InsertOrUpdateContactAsync(contact);
            return Json(result);
        }

        [HttpDelete]
        [Route("DeletePerson")]
        public async Task DeletePersonAsync(Guid id)
        {
            await service.DeletePersonAsync(id);
        }

        [HttpDelete]
        [Route("DeleteContact")]
        public async Task DeleteContactAsync(Guid id)
        {
             await service.DeleteContactAsync(id);
        }

        [HttpGet]
        [Route("GetPersonByID")]
        public async Task<IActionResult> GetPersonByIDAsync(Guid id)
        {
            var result=await service.getPersonByIDAsync(id);
            return Json(result);
        }

        [HttpGet]
        [Route("GetContactByID")]
        public async Task<IActionResult> GetContactByIDAsync(Guid id)
        {
            var result=await service.getContactByIDAsync(id);
            return Json(result);
        }

        [HttpGet]
        [Route("GetContactsByPersonID")]
        public IActionResult GetContactsByPersonID(Guid id)
        {
            var result = service.GetContactsByPersonID(id);
            return Json(result);
        }

        [HttpGet]
        [Route("GetAllPersons")]
        public IActionResult GetAllPersons()
        {
            var result = service.getAllPersons();
            return Json(result);
        }

        [HttpGet]
        [Route("GetAllContacts")]
        public IActionResult GetAllContacts()
        {
            var result = service.getAllContacts();
            return Json(result);
        }
    }
}
