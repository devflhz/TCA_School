using Data.Models;
using FluentResults;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public class PhoneService
    {
        static readonly HttpClient client = new HttpClient();

        public async Task<Result> PostPhoneAsync(int studentId, Phone phone)
        {
            phone.StudentId = studentId;
            phone.AreaCode = "662";
            phone.CountryCode = "+52";
            phone.PhoneType = 1;
            var data = new StringContent(JsonConvert.SerializeObject(phone), Encoding.UTF8, "application/json");
            try
            {
                var response = await client.PostAsync("https://localhost:44385/api/Phone", data);
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
