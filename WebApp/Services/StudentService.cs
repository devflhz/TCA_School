using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Data.Models;
using Newtonsoft.Json;

namespace WebApp.Services
{
    public class StudentService
    {
        static readonly HttpClient client = new HttpClient();

        public async Task<List<Student>> GetStudentsAsync()
        {
            List<Student> students;
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44385/api/Student");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                students = JsonConvert.DeserializeObject<List<Student>>(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                students = null;
            }
            return students;
        }
    }
}
