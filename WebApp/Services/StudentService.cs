using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Data.Constants;
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
                var response = await client.GetAsync($"{Constants.APIUri}/Student");
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
                var response = await client.GetAsync($"{Constants.APIUri}/Student/{studentId}");
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
                var response = await client.PostAsync($"{Constants.APIUri}/Student", data);
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
                var response = await client.PutAsync($"{Constants.APIUri}/Student/{student.StudentId}", data);
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

        public async Task<Result> DeleteStudentAsync(int id)
        {
            try
            {
                var response = await client.DeleteAsync($"{Constants.APIUri}/Student/{id}");
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
                var response = await client.GetAsync("https://raw.githubusercontent.com/ceceradio/genders/master/genders.json");
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
