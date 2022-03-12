using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Tarim11.WEB.Extensions
{
    public class requestAPI : IRequestAPI
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            //PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            

        };

        public requestAPI(IHttpClientFactory HttpClientFactory, IConfiguration Configuration)
        {
            httpClientFactory = HttpClientFactory;
            configuration = Configuration;
        }
        public async Task<List<T>> getListAsync<T>(string Url, string controller = "Contacts")
        {

            List<T> list = new List<T>();

            HttpClient client = httpClientFactory.CreateClient("api");
            client.DefaultVersionPolicy = HttpVersionPolicy.RequestVersionOrHigher;

            HttpResponseMessage response = await client.GetAsync(controller + "/" + Url);
            if (response.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                string result = response.Content.ReadAsStringAsync().Result;

                if (result.Length > 0)
                {
                    using MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(result));
                    

                    list = await JsonSerializer.DeserializeAsync<List<T>>(stream, options);
                }
            }

            return list;
        }

        public async Task<string> getJsonAsync(string Url, string controller = "Contacts")
        {

            string result = "";

            HttpClient client = httpClientFactory.CreateClient("api");
            client.DefaultVersionPolicy = HttpVersionPolicy.RequestVersionOrHigher;

            HttpResponseMessage response = await client.GetAsync(controller + "/" + Url);
            if (response.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                result = response.Content.ReadAsStringAsync().Result;

                
            }

            return result;
        }

        public async Task<T> getObjectAsync<T>(string Url, string controller = "Contacts")
        {

            T list = default(T);

            HttpClient client = httpClientFactory.CreateClient("api");
            client.DefaultVersionPolicy = HttpVersionPolicy.RequestVersionOrHigher;

            HttpResponseMessage response = await client.GetAsync(controller + "/" + Url);
            if (response.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                string result = response.Content.ReadAsStringAsync().Result;
                
                    if (result.Length > 0)
                        list = JsonSerializer.Deserialize<T>(result, options);
                
                

            }

            return list;
        }

        public async Task<List<T>> postObjectAsync<T, Type1>(string Url, Type1 content, string controller = "Contacts")
        {

            List<T> res = new List<T>();

            HttpClient client = httpClientFactory.CreateClient("api");
            client.DefaultVersionPolicy = HttpVersionPolicy.RequestVersionOrHigher;
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

            HttpResponseMessage response = await client.PostAsJsonAsync<Type1>(controller + "/" + Url, content);
            if (response.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                string result = response.Content.ReadAsStringAsync().Result;

                if (result.Length > 0)
                {
                    using MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(result));


                    res = await JsonSerializer.DeserializeAsync<List<T>>(stream, options);
                }

            }

            return res;
        }

        public async Task<T> postObject2Async<T, Type1>(string Url, Type1 content, string controller = "Contacts")
        {

            T res = default(T);

            HttpClient client = httpClientFactory.CreateClient("api");
            client.DefaultVersionPolicy = HttpVersionPolicy.RequestVersionOrHigher;
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

            HttpResponseMessage response = await client.PostAsJsonAsync<Type1>(controller + "/" + Url, content);
            if (response.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                string result = response.Content.ReadAsStringAsync().Result;

                if (result.Length > 0)
                {
                    using MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(result));


                    res = await JsonSerializer.DeserializeAsync<T>(stream, options);
                }

            }

            return res;
        }

        public async Task<T> postSimpleObjectAsync<T>(string Url, T content, string controller= "Contacts")
        {

            T res = default(T);

            HttpClient client = httpClientFactory.CreateClient("api");
            client.DefaultVersionPolicy = HttpVersionPolicy.RequestVersionOrHigher;
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

            HttpResponseMessage response = await client.PostAsJsonAsync(controller + "/" + Url, content);
            if (response.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                string result = response.Content.ReadAsStringAsync().Result;

                if (result.Length > 0)
                {
                    using MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(result));


                    res = await JsonSerializer.DeserializeAsync<T>(stream, options);
                }

            }

            return res;
        }

        public async Task<long> postSimpleObject2longAync<T>(string Url, T content, string controller = "Contacts")
        {

            long res = 0;

            HttpClient client = httpClientFactory.CreateClient("api");
            client.DefaultVersionPolicy = HttpVersionPolicy.RequestVersionOrHigher;
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

            HttpResponseMessage response = await client.PostAsJsonAsync(controller + "/" + Url, content);
            if (response.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                string result = response.Content.ReadAsStringAsync().Result;

                if (result.Length > 0)
                {
                    using MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(result));


                    res = await JsonSerializer.DeserializeAsync<long>(stream, options);
                }

            }

            return res;
        }

        public async Task<IActionResult> DeleteItemAsync(string Url, string controller = "Contacts") {

            long res = 0;

            HttpClient client = httpClientFactory.CreateClient("api");
            client.DefaultVersionPolicy = HttpVersionPolicy.RequestVersionOrHigher;

            HttpResponseMessage response = await client.DeleteAsync(controller + "/" + Url);
            if (response.IsSuccessStatusCode)
            {
                return new OkResult();
            }
            else {
                return new BadRequestResult();
            }
        }
    }

    public interface IRequestAPI
    {
        public Task<List<T>> getListAsync<T>(string Url, string controller = "Contacts");
        public Task<T> getObjectAsync<T>(string Url, string controller = "Contacts");
        public Task<List<T>> postObjectAsync<T, Type1>(string Url, Type1 content, string controller = "Contacts");
        public Task<T> postObject2Async<T, Type1>(string Url, Type1 content, string controller = "Contacts");
        public Task<T> postSimpleObjectAsync<T>(string Url, T content, string controller = "Contacts");
        public Task<long> postSimpleObject2longAync<T>(string Url, T content, string controller = "Contacts");
        public Task<string> getJsonAsync(string Url, string controller = "Contacts");
        public Task<IActionResult> DeleteItemAsync(string Url, string controller = "Contacts");
    }
}
