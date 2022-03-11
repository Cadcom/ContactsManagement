using Contacts.API.Code;
using Contacts.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ContactsController : Controller
    {
        DatabaseHelper databaseHelper = new DatabaseHelper();
        public ContactsController()
        {
        }

        [HttpPost]
        public IActionResult InsertOrUpdatePerson(Person person)
        {
            return View();
        }
    }
}
