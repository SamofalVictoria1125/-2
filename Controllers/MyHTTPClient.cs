using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using Курсовая.Models;

namespace Курсовая.Controllers
{
    static class MyHTTPClient
    {
        static HttpClient client = new HttpClient();
        static JsonSerializerOptions options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        public static async Task<IEnumerable<ContactPerson>> GetAllUsers()
        {
            var response = await client.GetAsync("https://localhost:7251/api/User");
            var code = response.StatusCode;
            if (code == System.Net.HttpStatusCode.OK)
            {
                IEnumerable<ContactPerson> array;
                using (var fs = response.Content.ReadAsStream())
                {
                    array = JsonSerializer.Deserialize<IEnumerable<ContactPerson>>(fs, options);
                }
                return array;
            }
            else
            {
                MessageBox.Show("Что-то пошло не так");
                return new List<ContactPerson>();
            }
        }

        public static async Task<IEnumerable<Product>> GetAllProducts()
        {
            var response = await client.GetAsync("https://localhost:5031/api/Products");
            var code = response.StatusCode;
            if (code == System.Net.HttpStatusCode.OK)
            {
                IEnumerable<Product> array;
                using (var fs = response.Content.ReadAsStream())
                {
                    array = JsonSerializer.Deserialize<IEnumerable<Product>>(fs, options);
                }
                return array;
            }
            else
            {
                MessageBox.Show("Что-то пошло не так");
                return new List<Product>();
            }
        }

        public static async Task<ContactPerson> GetUserById(int id)
        {
            var response = await client.GetAsync($"https://localhost:7251/api/User/{id}");
            var code = response.StatusCode;
            if (code == System.Net.HttpStatusCode.OK)
            {
                ContactPerson contactPerson;
                using (var fs = response.Content.ReadAsStream())
                {
                    contactPerson = JsonSerializer.Deserialize<ContactPerson>(fs, options);
                }
                return contactPerson;
            }
            else
            {
                MessageBox.Show("Что-то пошло не так");
                return new ContactPerson();
            }
        }

        public static async Task<Product> GetProductById(int id)
        {
            var response = await client.GetAsync($"https://localhost:5031/api/Products/{id}");
            var code = response.StatusCode;
            if (code == System.Net.HttpStatusCode.OK)
            {
                Product product;
                using (var fs = response.Content.ReadAsStream())
                {
                    product = JsonSerializer.Deserialize<Product>(fs, options);
                }
                return product;
            }
            else
            {
                MessageBox.Show("Что-то пошло не так");
                return new Product();
            }
        }

        public static async Task<ContactPerson> CreateUser(ContactPerson contactPerson)
        {
            StreamContent content;
            HttpResponseMessage response;
            using (var fs = new MemoryStream())
            {
                JsonSerializer.Serialize(fs, contactPerson, options);
                fs.Seek(0, SeekOrigin.Begin);
                content = new StreamContent(fs);
                content.Headers.Add("Content-Type", "application/json");
                response = await client.PostAsync("https://localhost:7251/api/User", content);
            }
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                using (var fs = response.Content.ReadAsStream())
                    contactPerson = JsonSerializer.Deserialize<ContactPerson>(fs, options);
            }
            return contactPerson;
        }

        public static async Task<bool> UpdateUser(ContactPerson contactPerson)
        {
            StreamContent content;
            HttpResponseMessage response;
            using (var fs = new MemoryStream())
            {
                JsonSerializer.Serialize(fs, contactPerson, options);
                fs.Seek(0, SeekOrigin.Begin);
                content = new StreamContent(fs);
                content.Headers.Add("Content-Type", "application/json");
                response = await client.PutAsync($"https://localhost:7251/api/User/{contactPerson.ID}", content);
            }
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        public static async Task<bool> DeleteUser(ContactPerson contactPerson)
        {
            var response = await client.DeleteAsync($"https://localhost:7251/api/User/{contactPerson.ID}");
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    }
}

