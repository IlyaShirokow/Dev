using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Kours.Domain.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/Domain/Autos")]
    public class AutosController : ControllerBase
    {
        private readonly string? _DalConnectionString;
        private readonly HttpClient _autos;

        public AutosController(IConfiguration conf)
        {
            _DalConnectionString = conf.GetValue<string>("DalConnectionString");
            _autos = new HttpClient();
        }

        [HttpGet]
        public async Task<ActionResult<Autos[]>> GetAutos()
        {
            var response = await _autos.GetAsync($"{_DalConnectionString}/api/Autos");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            if (content == null) return NotFound();

            return JsonSerializer.Deserialize<Autos[]>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? Array.Empty<Autos>();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Autos?>> GetAutos(int id)
        {
            var response = await _autos.GetAsync($"{_DalConnectionString}/api/Autos/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            if (content == null) return NotFound();

            return JsonSerializer.Deserialize<Autos?>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        [HttpPost]
        public async Task<Autos?> PostAutos(Autos newAutos)
        {
            JsonContent content = JsonContent.Create(newAutos);
            var response = await _autos.PostAsync($"{_DalConnectionString}/api/Autos", content);
            response.EnsureSuccessStatusCode();
            Autos? autos = await response.Content.ReadFromJsonAsync<Autos>();

            return autos;
        }

        [HttpDelete("{id}")]
        public async Task DeleteAutos(int id)
        {
            var response = await _autos.DeleteAsync($"{_DalConnectionString}/api/Autos/DeleteAutos/{id}");
            response.EnsureSuccessStatusCode();
        }

        [HttpPut]
        public async Task PutAutos(Autos newAutos)
        {
            JsonContent content = JsonContent.Create(newAutos);
            var response = await _autos.PutAsync($"{_DalConnectionString}/api/Autos/PutAutos", content);
            response.EnsureSuccessStatusCode();
        }
    }
}

