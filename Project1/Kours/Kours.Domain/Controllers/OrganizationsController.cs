using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Kours.Domain.Controllers
{
    [ApiController]
    [Route("api/Domain/Organizations")]
    public class OrganizationsController : ControllerBase
    {
        private readonly string? _DalConnectionString;
        private readonly HttpClient _organizations;

        public OrganizationsController(IConfiguration conf)
        {
            _DalConnectionString = conf.GetValue<string>("DalConnectionString");
            _organizations = new HttpClient();
        }

        [HttpGet]
        public async Task<ActionResult<Organizations[]>> GetOrganizations()
        {
            var response = await _organizations.GetAsync($"{_DalConnectionString}/api/Organizations");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            if (content == null) return NotFound();

            return JsonSerializer.Deserialize<Organizations[]>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? Array.Empty<Organizations>();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Organizations?>> GetOrganizations(int id)
        {
            var response = await _organizations.GetAsync($"{_DalConnectionString}/api/Organizations/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            if (content == null) return NotFound();

            return JsonSerializer.Deserialize<Organizations?>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        [HttpPost]
        public async Task<Organizations?> PostOrganizations(Organizations newOrganizations)
        {
            JsonContent content = JsonContent.Create(newOrganizations);
            var response = await _organizations.PostAsync($"{_DalConnectionString}/api/Organizations", content);
            response.EnsureSuccessStatusCode();
            Organizations? organizations = await response.Content.ReadFromJsonAsync<Organizations>();

            return organizations;
        }

        [HttpDelete("{id}")]
        public async Task DeleteOrganizations(int id)
        {
            var response = await _organizations.DeleteAsync($"{_DalConnectionString}/api/Organizations/DeleteOrganizations/{id}");
            response.EnsureSuccessStatusCode();
        }

        [HttpPut]
        public async Task PutOrganizations(Organizations newOrganizations)
        {
            JsonContent content = JsonContent.Create(newOrganizations);
            var response = await _organizations.PutAsync($"{_DalConnectionString}/api/Organizations/PutOrganizations", content);
            response.EnsureSuccessStatusCode();
        }
    }
}
