using Contacts.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tarim11.WEB.Extensions;

namespace Contacts.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IRequestAPI requestAPI;

        public List<Person> persons { get; set; }

        public IndexModel(IRequestAPI requestAPI, ILogger<IndexModel> logger)
        {
            _logger = logger;
            this.requestAPI = requestAPI;
        }

        public async Task OnGetAsync()
        {
            persons=await requestAPI.getListAsync<Person>("GetAllPersons?page=0&size=0");
        }

        public async Task<IActionResult> OnGetRemovePersonAsync(Guid guid) {
            var result = await requestAPI.DeleteItemAsync($"DeletePerson?id={guid}");

            return result;
        }
    }
}
