using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MentalEdu.BlazorApp.Models;

namespace MentalEdu.BlazorApp.Client.Services
{
    public class SupportProgramService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "api/SupportProgram";

        public SupportProgramService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<SupportProgram>> GetAllProgramsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<SupportProgram>>(_baseUrl);
        }

        public async Task<SupportProgram> GetProgramByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<SupportProgram>($"{_baseUrl}/{id}");
        }

        public async Task<IEnumerable<SupportProgram>> GetProgramsByCategoryAsync(Guid categoryId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<SupportProgram>>($"{_baseUrl}/category/{categoryId}");
        }

        public async Task<IEnumerable<ProgramCategory>> GetAllCategoriesAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ProgramCategory>>($"{_baseUrl}/categories");
        }

        public async Task<SupportProgram> CreateProgramAsync(SupportProgram program)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseUrl, program);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<SupportProgram>();
        }

        public async Task UpdateProgramAsync(SupportProgram program)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/{program.Id}", program);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteProgramAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}