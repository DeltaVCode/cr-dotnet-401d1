using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Demo.Web.Models;

namespace Demo.Web.Services
{
    public class HttpStudentService : IStudentService
    {
        private static readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44323/api/"),
        };

        public async Task<List<Student>> GetAll()
        {
            var responseStream = await client.GetStreamAsync("Students");
            List<Student> result = await JsonSerializer.DeserializeAsync<List<Student>>(responseStream);
            return result;
        }

        public async Task<Student> GetOne(int id)
        {
            var responseStream = await client.GetStreamAsync($"Students/{id}");
            Student result = await JsonSerializer.DeserializeAsync<Student>(responseStream);
            return result;
        }
    }
}
