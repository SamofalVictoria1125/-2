using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using Курсовая.Models;
using Курсовая.Windows;
using System.Windows.Controls;
using System.Diagnostics.Eventing.Reader;
using System.Reflection;

namespace Курсовая.Controllers
{
    static class MyHTTPClient
    {
        static HttpClient client = new HttpClient();
        static JsonSerializerOptions options = new JsonSerializerOptions {
            PropertyNameCaseInsensitive = true, 
            ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
        };
        public static async Task<IEnumerable<ContactPerson>> GetAllUsers()
        {
            await Auth();
            var response = await client.GetAsync("http://localhost:5031/api/User");
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

        public static string Login;
        public static string Password;


        public static async Task Auth()
        {
            RSACryptoServiceProvider RsaKey2 = new RSACryptoServiceProvider();
            //RsaKey2.FromXmlString("<RSAKeyValue><Modulus>qLSks6XFKN/iEPcvwWTJ4ghf/9gNLx7hCw7D2Y3j0ARNGmLqiBULAVnDTJ2iZhzzebsD1kaaMp2GRAROPHH/OwwD2C3x8rQQCl1VOKzzOQ1h+rNuAgezkPHVaXCu1OCuwURnTpqs09L3xVQitD1ZByxOxgZ0OzRKjUqpdwXXMfk=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>");
            var key = await client.GetAsync("http://localhost:5031/api/PublicKey");
            var code2 = key.StatusCode;
            var fst = "";
            if (code2 == System.Net.HttpStatusCode.OK)
            {

                fst = await key.Content.ReadAsStringAsync();

                //array = JsonSerializer.Deserialize<string>(fst, options);

            }
            else
            {
                MessageBox.Show("Что-то пошло не так2");
               // return new List<Product>();
            }
            RsaKey2.FromXmlString(fst);

            byte[] EncryptedData;
            byte[] data = new byte[1024];
            data = Encoding.UTF8.GetBytes(Login + " " + Password + " " + DateTime.Now);
            EncryptedData = RsaKey2.Encrypt(data, false);
            string a = "";
            for (int i = 0; i < EncryptedData.Length; i++)
            {
                a = a + EncryptedData[i] + " ";
            }



            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", a);
        }

        public static async Task<IEnumerable<Product>> GetAllProducts()
        {
            await Auth();
            var response = await client.GetAsync("http://localhost:5031/api/Products");
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
                string responseContent;
                responseContent = await response.Content.ReadAsStringAsync();
                var startIndex = responseContent.IndexOf("detail")+9;
                var endIndex = responseContent.IndexOf("\"", startIndex);       
                MessageBox.Show(responseContent.Substring(startIndex, endIndex - startIndex));
                return new List<Product>();
            }
        }

        public static async Task<IEnumerable<ContactPerson>> GetAllContactPersons()
        {
            await Auth();
            var response = await client.GetAsync("http://localhost:5031/api/ContactPersons");
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

        public static async Task<IEnumerable<Counterparty>> GetAllCounterparties()
        {
            await Auth();
            var response = await client.GetAsync("http://localhost:5031/api/Counterparties");
            var code = response.StatusCode;
            if (code == System.Net.HttpStatusCode.OK)
            {
                IEnumerable<Counterparty> array;
                using (var fs = response.Content.ReadAsStream())
                {
                    array = JsonSerializer.Deserialize<IEnumerable<Counterparty>>(fs, options);
                }
                return array;
            }
            else
            {
                MessageBox.Show("Что-то пошло не так");
                return new List<Counterparty>();
            }
        }

        public static async Task<IEnumerable<Currency>> GetAllCurrencies()
        {
            await Auth();
            var response = await client.GetAsync("http://localhost:5031/api/Currencies");
            var code = response.StatusCode;
            if (code == System.Net.HttpStatusCode.OK)
            {
                IEnumerable<Currency> array;
                using (var fs = response.Content.ReadAsStream())
                {
                    array = JsonSerializer.Deserialize<IEnumerable<Currency>>(fs, options);
                }
                return array;
            }
            else
            {
                MessageBox.Show("Что-то пошло не так");
                return new List<Currency>();
            }
        }

        public static async Task<IEnumerable<Purchase>> GetAllPurchases()
        {
            await Auth();
            var response = await client.GetAsync("http://localhost:5031/api/Purchases");
            var code = response.StatusCode;
            if (code == System.Net.HttpStatusCode.OK)
            {
                IEnumerable<Purchase> array;
                using (var fs = response.Content.ReadAsStream())
                {
                    array = JsonSerializer.Deserialize<IEnumerable<Purchase>>(fs, options);
                }
                return array;
            }
            else
            {
                MessageBox.Show("Что-то пошло не так");
                return new List<Purchase>();
            }
        }

        public static async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            await Auth();
            var response = await client.GetAsync("http://localhost:5031/api/Customers");
            var code = response.StatusCode;
            if (code == System.Net.HttpStatusCode.OK)
            {
                IEnumerable<Customer> array;
                using (var fs = response.Content.ReadAsStream())
                {
                    array = JsonSerializer.Deserialize<IEnumerable<Customer>>(fs, options);
                }
                return array;
            }
            else
            {
                MessageBox.Show("Что-то пошло не так");
                return new List<Customer>();
            }
        }

        public static async Task<IEnumerable<PurchaseComposition>> GetPurchasesCompositionsByPurchaseId(int PurchaseId)
        {
            await Auth();
            var response = await client.GetAsync($"http://localhost:5031/api/PurchaseComposition/{PurchaseId}");
            var code = response.StatusCode;
            if (code == System.Net.HttpStatusCode.OK)
            {
                IEnumerable<PurchaseComposition> array;
                using (var fs = response.Content.ReadAsStream())
                {
                    array = JsonSerializer.Deserialize<IEnumerable<PurchaseComposition>>(fs, options);
                }
                return array;
            }
            else
            {
                MessageBox.Show("Что-то пошло не так");
                return new List<PurchaseComposition>();
            }
        }

        public static async Task<ContactPerson> GetUserById(int id)
        {
            await Auth();
            var response = await client.GetAsync($"https://localhost:5031/api/User/{id}");
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
            await Auth();
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

        public static async Task<Employee> GetEmployeeById(int id)
        {
            await Auth();
            var response = await client.GetAsync($"https://localhost:5031/api/Employees/{id}");
            var code = response.StatusCode;
            if (code == System.Net.HttpStatusCode.OK)
            {
                Employee employee;
                using (var fs = response.Content.ReadAsStream())
                {
                    employee = JsonSerializer.Deserialize<Employee>(fs, options);
                }
                return employee;
            }
            else
            {
                MessageBox.Show("Что-то пошло не так");
                return new Employee();
            }
        }

        public static async Task<ContactPerson> GetContactPersonById(int id)
        {
            await Auth();
            var response = await client.GetAsync($"http://localhost:5031/api/ContactPersons/{id}");
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

        public static async Task<Currency> GetCurrencyById(int id)
        {
            await Auth();
            var response = await client.GetAsync($"https://localhost:5031/api/ContactPersons/{id}");
            var code = response.StatusCode;
            if (code == System.Net.HttpStatusCode.OK)
            {
                Currency purchase;
                using (var fs = response.Content.ReadAsStream())
                {
                    purchase = JsonSerializer.Deserialize<Currency>(fs, options);
                }
                return purchase;
            }
            else
            {
                MessageBox.Show("Что-то пошло не так");
                return new Currency();
            }
        }

        public static async Task<Counterparty> GetPartnerById(int id)
        {
            await Auth();
            var response = await client.GetAsync($"https://localhost:5031/api/Counterparties/{id}");
            var code = response.StatusCode;
            if (code == System.Net.HttpStatusCode.OK)
            {
                Counterparty counterparty;
                using (var fs = response.Content.ReadAsStream())
                {
                    counterparty = JsonSerializer.Deserialize<Counterparty>(fs, options);
                }
                return counterparty;
            }
            else
            {
                MessageBox.Show("Что-то пошло не так");
                return new Counterparty();
            }
        }

        public static async Task<Employee> GetManagerById(int id)
        {
            await Auth();
            var response = await client.GetAsync($"https://localhost:5031/api/Employees/{id}");
            var code = response.StatusCode;
            if (code == System.Net.HttpStatusCode.OK)
            {
                Employee employee;
                using (var fs = response.Content.ReadAsStream())
                {
                    employee = JsonSerializer.Deserialize<Employee>(fs, options);
                }
                return employee;
            }
            else
            {
                MessageBox.Show("Что-то пошло не так");
                return new Employee();
            }
        }

        public static async Task<Purchase> GetPurchaseById(int id)
        {
            await Auth();
            var response = await client.GetAsync($"https://localhost:5031/api/ContactPersons/{id}");
            var code = response.StatusCode;
            if (code == System.Net.HttpStatusCode.OK)
            {
                Purchase purchase;
                using (var fs = response.Content.ReadAsStream())
                {
                    purchase = JsonSerializer.Deserialize<Purchase>(fs, options);
                }
                return purchase;
            }
            else
            {
                MessageBox.Show("Что-то пошло не так");
                return new Purchase();
            }
        }

        public static async Task<Shipment> GetShipmentById(int id)
        {
            await Auth();
            var response = await client.GetAsync($"https://localhost:5031/api/Shipments/{id}");
            var code = response.StatusCode;
            if (code == System.Net.HttpStatusCode.OK)
            {
                Shipment shipment;
                using (var fs = response.Content.ReadAsStream())
                {
                    shipment = JsonSerializer.Deserialize<Shipment>(fs, options);
                }
                return shipment;
            }
            else
            {
                MessageBox.Show("Что-то пошло не так");
                return new Shipment();
            }
        }

        public static async Task<ContactPerson> CreateContactPerson(ContactPerson contactPerson)
        {
            await Auth();
            StreamContent content;
            HttpResponseMessage response;
            using (var fs = new MemoryStream())
            {
                JsonSerializer.Serialize(fs, contactPerson, options);
                fs.Seek(0, SeekOrigin.Begin);
                content = new StreamContent(fs);
                content.Headers.Add("Content-Type", "application/json");
                response = await client.PostAsync("http://localhost:5031/api/ContactPersons", content);
            }
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                using (var fs = response.Content.ReadAsStream())
                    contactPerson = JsonSerializer.Deserialize<ContactPerson>(fs, options);
            }
            return contactPerson;
        }

        public static async Task<Purchase> CreatePurchase(Purchase purchase)
        {
            await Auth();
            StreamContent content;
            HttpResponseMessage response;
            using (var fs = new MemoryStream())
            {
                JsonSerializer.Serialize(fs, purchase, options);
                fs.Seek(0, SeekOrigin.Begin);
                content = new StreamContent(fs);
                content.Headers.Add("Content-Type", "application/json");
                response = await client.PostAsync("http://localhost:5031/api/Purchase", content);
            }
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                using (var fs = response.Content.ReadAsStream())
                    purchase = JsonSerializer.Deserialize<Purchase>(fs, options);
            }
            return purchase;
        }

        public static async Task<Counterparty> CreateCounterparty(Counterparty counterparty)
        {
            await Auth();
            StreamContent content;
            HttpResponseMessage response;
            using (var fs = new MemoryStream())
            {
                JsonSerializer.Serialize(fs, counterparty, options);
                fs.Seek(0, SeekOrigin.Begin);
                content = new StreamContent(fs);
                content.Headers.Add("Content-Type", "application/json");
                response = await client.PostAsync("http://localhost:5031/api/Counterparties", content);
            }
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                using (var fs = response.Content.ReadAsStream())
                    counterparty = JsonSerializer.Deserialize<Counterparty>(fs, options);
            }
            return counterparty;
        }

        public static async Task<Customer> CreateCustomer(Customer customer)
        {
            await Auth();
            StreamContent content;
            HttpResponseMessage response;
            using (var fs = new MemoryStream())
            {
                JsonSerializer.Serialize(fs, customer, options);
                fs.Seek(0, SeekOrigin.Begin);
                content = new StreamContent(fs);
                content.Headers.Add("Content-Type", "application/json");
                response = await client.PostAsync("http://localhost:5031/api/Customers", content);
            }
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                using (var fs = response.Content.ReadAsStream())
                    customer = JsonSerializer.Deserialize<Customer>(fs, options);
            }
            return customer;
        }

        public static async Task<bool> UpdateCustomer(Customer customer)
        {
            await Auth();
            StreamContent content;
            HttpResponseMessage response;
            using (var fs = new MemoryStream())
            {
                JsonSerializer.Serialize(fs, customer, options);
                fs.Seek(0, SeekOrigin.Begin);
                content = new StreamContent(fs);
                content.Headers.Add("Content-Type", "application/json");
                response = await client.PutAsync($"http://localhost:5031/api/Customers/{customer.Id}", content);
            }
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

       


        public static async Task<bool> UpdateContactPerson(ContactPerson contactPerson)
        {
            await Auth();
            StreamContent content;
            HttpResponseMessage response;
            using (var fs = new MemoryStream())
            {
                JsonSerializer.Serialize(fs, contactPerson, options);
                fs.Seek(0, SeekOrigin.Begin);
                content = new StreamContent(fs);
                content.Headers.Add("Content-Type", "application/json");
                response = await client.PutAsync($"http://localhost:5031/api/ContactPersons/{contactPerson.Id}", content);
            }
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        public static async Task<bool> UpdatePurchase(Purchase purchase)
        {
            await Auth();
            StreamContent content;
            HttpResponseMessage response;
            using (var fs = new MemoryStream())
            {
                JsonSerializer.Serialize(fs, purchase, options);
                fs.Seek(0, SeekOrigin.Begin);
                content = new StreamContent(fs);
                content.Headers.Add("Content-Type", "application/json");
                response = await client.PutAsync($"http://localhost:5031/api/Purchases/{purchase.Id}", content);
            }
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }



        public static async Task<Product> CreateProduct(Product product)
        {
            await Auth();
            StreamContent content;
            HttpResponseMessage response;
            using (var fs = new MemoryStream())
            {
                JsonSerializer.Serialize(fs, product, options);
                fs.Seek(0, SeekOrigin.Begin);
                content = new StreamContent(fs);
                content.Headers.Add("Content-Type", "application/json");
                response = await client.PostAsync("http://localhost:5031/api/Products", content);
            }
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                using (var fs = response.Content.ReadAsStream())
                    product = JsonSerializer.Deserialize<Product>(fs, options);
            }
            return product;
        }
        public static async Task<bool> UpdateCounterparty(Counterparty counterparty)
        {
            await Auth();
            StreamContent content;
            HttpResponseMessage response;
            using (var fs = new MemoryStream())
            {
                JsonSerializer.Serialize(fs, counterparty, options);
                fs.Seek(0, SeekOrigin.Begin);
                content = new StreamContent(fs);
                content.Headers.Add("Content-Type", "application/json");
                response = await client.PutAsync($"http://localhost:5031/api/Counterparties/{counterparty.Id}", content);
            }
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

            public static async Task<bool> UpdateProduct(Product product)
        {
            await Auth();
            StreamContent content;
            HttpResponseMessage response;
            using (var fs = new MemoryStream())
            {
                JsonSerializer.Serialize(fs, product, options);
                fs.Seek(0, SeekOrigin.Begin);
                content = new StreamContent(fs);
                content.Headers.Add("Content-Type", "application/json");
                response = await client.PutAsync($"http://localhost:5031/api/Products/{product.Id}", content);
            }
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        public static async Task<bool> UpdateUser(ContactPerson contactPerson)
        {
            await Auth();
            StreamContent content;
            HttpResponseMessage response;
            using (var fs = new MemoryStream())
            {
                JsonSerializer.Serialize(fs, contactPerson, options);
                fs.Seek(0, SeekOrigin.Begin);
                content = new StreamContent(fs);
                content.Headers.Add("Content-Type", "application/json");
                response = await client.PutAsync($"http://localhost:5031/api/User/{contactPerson.Id}", content);
            }
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        public static async Task<bool> DeleteUser(ContactPerson contactPerson)
        {
            await Auth();
            var response = await client.DeleteAsync($"https://localhost:7251/api/User/{contactPerson.Id}");
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        public static async Task<System.Net.HttpStatusCode> DeletePurchase(Purchase purchase)
        {
            await Auth();
            var response = await client.DeleteAsync($"https://localhost:7251/api/Purchase/{purchase.Id}");
            return response.StatusCode;
        }


        public static async Task<System.Net.HttpStatusCode> DeleteProduct(Product product)
        {

            await Auth();
            var response = await client.DeleteAsync($"http://localhost:5031/api/Products/{product.Id}");
            return response.StatusCode;
        }

        public static async Task<System.Net.HttpStatusCode> DeleteContactPerson(ContactPerson contactPerson)
        {

            await Auth();
            var response = await client.DeleteAsync($"http://localhost:5031/api/ContactPersons/{contactPerson.Id}");
            return response.StatusCode;
        }
    }
}

