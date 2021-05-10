using Data.Models;
using FluentResults;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Data.Constants;

namespace WebApp.Services
{
    public class EmailService
    {
        static readonly HttpClient client = new HttpClient();

        public async Task<Result<List<Email>>> GetEmailsAsync()
        {
            try
            {
                var response = await client.GetAsync($"{Constants.APIUri}/Email");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Email> emails = JsonConvert.DeserializeObject<List<Email>>(responseBody);
                return Result.Ok(emails);
            }
            catch (HttpRequestException e)
            {
                return Result.Fail(e.Message);
            }
        }

        public async Task<Result<Email>> GetEmailAsync(int id)
        {
            try
            {
                var response = await client.GetAsync($"{Constants.APIUri}/Email/{id}");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Email emails = JsonConvert.DeserializeObject<Email>(responseBody);
                return Result.Ok(emails);
            }
            catch (HttpRequestException e)
            {
                return Result.Fail(e.Message);
            }
        }

        public async Task<Result<Email>> PostEmailAsync(int id, Email email)
        {
            email.EmailType = 1;
            email.StudentId = id;
            var data = new StringContent(JsonConvert.SerializeObject(email), Encoding.UTF8, "application/json");
            try
            {
                var response = await client.PostAsync($"{Constants.APIUri}/Email", data);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                email = JsonConvert.DeserializeObject<Email>(responseBody);
                return Result.Ok(email);
            }
            catch (HttpRequestException e)
            {
                return Result.Fail(e.Message);
            }
        }
        public async Task<Result<Email>> PutEmailAsync(int id, Email email)
        {
            email.EmailType = 1;
            email.StudentId = id;
            var data = new StringContent(JsonConvert.SerializeObject(email), Encoding.UTF8, "application/json");
            try
            {
                var response = await client.PutAsync($"{Constants.APIUri}/Email/{email.EmailId}", data);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                email = JsonConvert.DeserializeObject<Email>(responseBody);
                return Result.Ok(email);
            }
            catch (HttpRequestException e)
            {
                return Result.Fail(e.Message);
            }
        }
        public async Task<Result> DeleteEmailAsync(int id)
        {
            try
            {
                var response = await client.DeleteAsync($"{Constants.APIUri}/Email/{id}");
                response.EnsureSuccessStatusCode();
                return Result.Ok();
            }
            catch (HttpRequestException e)
            {
                return Result.Fail(e.Message);
            }
        }
    }
}
