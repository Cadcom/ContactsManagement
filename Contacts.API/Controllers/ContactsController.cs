using Contacts.Business.Abstract;
using Contacts.Business.Concrete;
using Contacts.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
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
    }
}
