using Contacts.Data;
using Contacts.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ContactsController : Controller
    {
        public ContactsController(ContactsDBContext _dbContext)
        {
        }

        [HttpPost]
        public IActionResult InsertOrUpdatePerson(Person person)
        {
            var result = "";
            //var result=databaseHelper.insertOrUpdatePersonAsync(person);
            return Json(result);
        }
    }
}
