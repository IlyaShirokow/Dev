using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Kours.Domain.Controllers
{
    [ApiController]
    [Route("api/Domain/Drivers")]
    public class DriversController : ControllerBase
    {
        private readonly string? _DalConnectionString;
        private readonly HttpClient _drivers;

        public DriversController(IConfiguration conf)
        {
            _DalConnectionString = conf.GetValue<string>("DalConnectionString");
            _drivers = new HttpClient();
        }

        [HttpGet]
        public async Task<ActionResult<Drivers[]>> GetDrivers()
        {
            var response = await _drivers.GetAsync($"{_DalConnectionString}/api/Drivers");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            if (content == null) return NotFound();

            return JsonSerializer.Deserialize<Drivers[]>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? Array.Empty<Drivers>();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Drivers?>> GetDrivers(int id)
        {
            var response = await _drivers.GetAsync($"{_DalConnectionString}/api/Drivers/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            if (content == null) return NotFound();

            return JsonSerializer.Deserialize<Drivers?>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        [HttpPost]
        public async Task<Drivers?> PostDrivers(Drivers newDrivers)
        {
            JsonContent content = JsonContent.Create(newDrivers);
            var response = await _drivers.PostAsync($"{_DalConnectionString}/api/Drivers", content);
            response.EnsureSuccessStatusCode();
            Drivers? drivers = await response.Content.ReadFromJsonAsync<Drivers>();

            return drivers;
        }

        [HttpDelete("{id}")]
        public async Task DeleteEmployee(int id)
        {
            var response = await _drivers.DeleteAsync($"{_DalConnectionString}/api/Drivers/DeleteDrivers/{id}");
            response.EnsureSuccessStatusCode();
        }

        [HttpPut]
        public async Task PutDrivers(Drivers newDrivers)
        {
            JsonContent content = JsonContent.Create(newDrivers);
            var response = await _drivers.PutAsync($"{_DalConnectionString}/api/Drivers/PutDrivers", content);
            response.EnsureSuccessStatusCode();
        }
    }
}
