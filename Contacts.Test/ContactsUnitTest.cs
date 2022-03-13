using Contacts.API;
using Contacts.API.Controllers;
using Contacts.Shared.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Contacts.Test
{
    public class ContactsUnitTest : IDisposable
    {
        public HttpClient client { get; set; }
        Person person;
        Contact contact;

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            //PropertyNamingPolicy = JsonNamingPolicy.CamelCase


        };

        public  ContactsUnitTest()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>().UseSetting("myConnectionString", "Server=localhost;Database=DBContacts;User Id=postgres;Password=123456"));

            client=server.CreateClient();

            person = new Person { Company = "CADCOM", Name = "Cevat", Surname = "Serin" };
            contact = new Contact { Type = InfoType.Location, Info = "Ankara" };

        }

        [Fact]
        public async Task InsertOrUpdatePersonTestAsync() {
            client = new ContactsUnitTest().client;

            var httpContent = new StringContent(JsonConvert.SerializeObject(person), Encoding.UTF8, "application/json");


            var response = await client.PostAsync("api/Contacts/InsertOrUpdatePerson", httpContent);

            

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            string result = response.Content.ReadAsStringAsync().Result;
            if (result.Length > 0)
            {
                using MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(result));
                person = await System.Text.Json.JsonSerializer.DeserializeAsync<Person>(stream, options);
            }

            Assert.False (person.UUID==Guid.Empty);
            contact.PersonID = person.UUID;
        }

        [Fact]
        public async Task InsertOrUpdateContactTestAsync()
        {
            client = new ContactsUnitTest().client;

            await InsertOrUpdatePersonTestAsync();
            var httpContent = new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8, "application/json");


            var response = await client.PostAsync("api/Contacts/InsertOrUpdateContact", httpContent);



            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            string result = response.Content.ReadAsStringAsync().Result;
            if (result.Length > 0)
            {
                using MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(result));
                contact = await System.Text.Json.JsonSerializer.DeserializeAsync<Contact>(stream, options);
            }

            Assert.False(contact.UUID == Guid.Empty);
        }

        [Fact]
        public async Task DeletePersonTestAsync()
        {
            client = new ContactsUnitTest().client;
            await InsertOrUpdatePersonTestAsync();
            var response = await client.DeleteAsync($"api/Contacts/DeletePerson?id={person.UUID.ToString()}");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

        [Fact]
        public async Task DeleteContactTestAsync()
        {
            client = new ContactsUnitTest().client;
            var response = await client.GetAsync("api/Contacts/GetAllContacts");

            string result = response.Content.ReadAsStringAsync().Result;
            if (result.Length > 0)
            {
                using MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(result));
                List<Contact> contacts = await System.Text.Json.JsonSerializer.DeserializeAsync<List<Contact>>(stream, options);

                if (contacts.Count > 0)
                {
                    response = await client.DeleteAsync($"api/Contacts/DeleteContact?id={contacts[0].UUID}");

                    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                }
            }



            

        }

        public void Dispose()
        {
        }
    }
}
