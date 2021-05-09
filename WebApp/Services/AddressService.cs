using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using FluentResults;
using Newtonsoft.Json;

namespace WebApp.Services
{
    public class AddressService
    {
        static readonly HttpClient client = new HttpClient();

        public async Task<Result<List<Address>>> GetAddressesAsync()
        {
            try
            {
                var response = await client.GetAsync("https://localhost:44385/api/Address");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Address> addresses = JsonConvert.DeserializeObject<List<Address>>(responseBody);
                return Result.Ok(addresses);
            }
            catch (HttpRequestException e)
            {
                return Result.Fail(e.Message);
            }
        }

        public async Task<Result<Address>> GetAddresslAsync(int id)
        {
            try
            {
                var response = await client.GetAsync($"https://localhost:44385/api/Address/{id}");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Address address = JsonConvert.DeserializeObject<Address>(responseBody);
                return Result.Ok(address);
            }
            catch (HttpRequestException e)
            {
                return Result.Fail(e.Message);
            }
        }

        public async Task<Result> PostAddressAsync(int studentId, Address address)
        {
            address.StudentId = studentId;
            var data = new StringContent(JsonConvert.SerializeObject(address), Encoding.UTF8, "application/json");
            try
            {
                var response = await client.PostAsync("https://localhost:44385/api/Address", data);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                address = JsonConvert.DeserializeObject<Address>(responseBody);
                return Result.Ok(address);
            }
            catch (HttpRequestException e)
            {
                return Result.Fail(e.Message);
            }
        }

        public async Task<Result<Address>> PutAddressAsync(int studentId, Address address)
        {
            address.StudentId = studentId;
            var data = new StringContent(JsonConvert.SerializeObject(address), Encoding.UTF8, "application/json");
            try
            {
                var response = await client.PutAsync("https://localhost:44385/api/Address", data);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                address = JsonConvert.DeserializeObject<Address>(responseBody);
                return Result.Ok(address);
            }
            catch (HttpRequestException e)
            {
                return Result.Fail(e.Message);
            }
        }

        public async Task<Result> DeleteAddressAsync(int id)
        {
            try
            {
                var response = await client.DeleteAsync($"https://localhost:44385/api/Address/{id}");
                response.EnsureSuccessStatusCode();
                return Result.Ok();
            }
            catch (HttpRequestException e)
            {
                return Result.Fail(e.Message);
            }
        }

        public async Task<Result<List<State>>> GetStatesAsync()
        {
            List<State> states;
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "https://raw.githubusercontent.com/astockwell/countries-and-provinces-states-regions/master/countries/mexico.json");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                states = JsonConvert.DeserializeObject<List<State>>(responseBody);
                return Result.Ok(states);
            }
            catch (HttpRequestException e)
            {
                return Result.Fail(e.Message);
            }
        }
    }
}
