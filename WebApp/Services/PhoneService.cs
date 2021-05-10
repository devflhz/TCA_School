using Data.Constants;
using Data.Models;
using FluentResults;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public class PhoneService
    {
        static readonly HttpClient client = new HttpClient();

        public async Task<Result<List<Phone>>> GetPhonesAsync()
        {
            try
            {
                var response = await client.GetAsync($"{Constants.APIUri}/Phone");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Phone> phones = JsonConvert.DeserializeObject<List<Phone>>(responseBody);
                return Result.Ok(phones);
            }
            catch (HttpRequestException e)
            {
                return Result.Fail(e.Message);
            }
        }

        public async Task<Result<Phone>> GetPhoneAsync(int id)
        {
            try
            {
                var response = await client.GetAsync($"{Constants.APIUri}/Phone/{id}");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Phone phone = JsonConvert.DeserializeObject<Phone>(responseBody);
                return Result.Ok(phone);
            }
            catch (HttpRequestException e)
            {
                return Result.Fail(e.Message);
            }
        }

        public async Task<Result<Phone>> PostPhoneAsync(int studentId, Phone phone)
        {
            phone.StudentId = studentId;
            phone.AreaCode = "662";
            phone.CountryCode = "+52";
            phone.PhoneType = 1;
            var data = new StringContent(JsonConvert.SerializeObject(phone), Encoding.UTF8, "application/json");
            try
            {
                var response = await client.PostAsync($"{Constants.APIUri}/Phone", data);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                phone = JsonConvert.DeserializeObject<Phone>(responseBody);
                return Result.Ok(phone);
            }
            catch (HttpRequestException e)
            {
                return Result.Fail(e.Message);
            }
        }

        public async Task<Result<Phone>> PutPhoneAsync(int studentId, Phone phone)
        {
            phone.StudentId = studentId;
            phone.AreaCode = "662";
            phone.CountryCode = "+52";
            phone.PhoneType = 1;
            var data = new StringContent(JsonConvert.SerializeObject(phone), Encoding.UTF8, "application/json");
            try
            {
                var response = await client.PutAsync($"{Constants.APIUri}/Phone/{phone.PhoneId}", data);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                phone = JsonConvert.DeserializeObject<Phone>(responseBody);
                return Result.Ok(phone);
            }
            catch (HttpRequestException e)
            {
                return Result.Fail(e.Message);
            }
        }

        public async Task<Result> DeletePhoneAsync(int id)
        {
            try
            {
                var response = await client.DeleteAsync($"{Constants.APIUri}/Phone/{id}");
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
