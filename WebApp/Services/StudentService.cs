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
    public class StudentService
    {
        static readonly HttpClient client = new HttpClient();

        public async Task<Result<List<Student>>> GetStudentsAsync()
        {
            List<Student> students;
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44385/api/Student");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                students = JsonConvert.DeserializeObject<List<Student>>(responseBody);
                return Result.Ok(students);
            }
            catch (HttpRequestException e)
            {
                return Result.Fail(e.Message);
            }
        }

        public async Task<Result<Student>> GetStudentAsync(int studentId)
        {
            Student student;
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:44385/api/Student/{studentId}");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                student = JsonConvert.DeserializeObject<Student>(responseBody);
                return Result.Ok(student);
            }
            catch (HttpRequestException e)
            {
                return Result.Fail(e.Message);
            }
        }

        public async Task<Result<Student>> PostStudentAsync(Student student)
        {
            var data = new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json");
            try
            {
                var response = await client.PostAsync("https://localhost:44385/api/Student", data);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                student = JsonConvert.DeserializeObject<Student>(responseBody);
                return Result.Ok(student);
            }
            catch (HttpRequestException e)
            {
                return Result.Fail(e.Message);
            }
        }
        
        public async Task<Result<Student>> PutStudentAsync(Student student)
        {
            var data = new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json");
            try
            {
                var response = await client.PostAsync("https://localhost:44385/api/Student", data);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                student = JsonConvert.DeserializeObject<Student>(responseBody);
                return Result.Ok(student);
            }
            catch (HttpRequestException e)
            {
                return Result.Fail(e.Message);
            }
        }

        public async Task<Result> DeleteStudent(int id)
        {
            try
            {
                var response = await client.DeleteAsync($"https://localhost:44385/api/Student/{id}");
                response.EnsureSuccessStatusCode();
                return Result.Ok();
            }
            catch (HttpRequestException e)
            {
                return Result.Fail(e.Message);
            }
        }
        
        public async Task<Result<List<string>>> GetGendersAsync()
        {
            List<string> genders;
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "https://raw.githubusercontent.com/ceceradio/genders/master/genders.json");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                genders = JsonConvert.DeserializeObject<List<string>>(responseBody);
                return Result.Ok(genders);
            }
            catch (HttpRequestException e)
            {
                return Result.Fail(e.Message);
            }
        }
    }
}
