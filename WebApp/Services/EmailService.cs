using Data.Models;
using FluentResults;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public class EmailService
    {
        static readonly HttpClient client = new HttpClient();

        public async Task<Result> PostEmailAsync(int studentId, Email email)
        {
            email.EmailType = 1;
            email.StudentId = studentId;
            var data = new StringContent(JsonConvert.SerializeObject(email), Encoding.UTF8, "application/json");
            try
            {
                var response = await client.PostAsync("https://localhost:44385/api/Email", data);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                return Result.Fail(e.Message);
            }
            return Result.Ok();
        }
    }
}
