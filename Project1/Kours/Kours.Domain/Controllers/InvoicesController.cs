using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Kours.Domain.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/Domain/Invoices")]
    public class InvoicesController : ControllerBase
    {
        private readonly string? _DalConnectionString;
        private readonly HttpClient _invoices;

        public InvoicesController(IConfiguration conf)
        {
            _DalConnectionString = conf.GetValue<string>("DalConnectionString");
            _invoices = new HttpClient();
        }

        [HttpGet]
        public async Task<ActionResult<Invoices[]>> GetInvoices()
        {
            var response = await _invoices.GetAsync($"{_DalConnectionString}/api/Invoices");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            if (content == null) return NotFound();

            return JsonSerializer.Deserialize<Invoices[]>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? Array.Empty<Invoices>();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Invoices?>> GetInvoices(int id)
        {
            var response = await _invoices.GetAsync($"{_DalConnectionString}/api/invoices/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            if (content == null) return NotFound();

            return JsonSerializer.Deserialize<Invoices?>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        [HttpPost]
        public async Task<Invoices?> AddInvoices(Invoices newInvoices)
        {
            JsonContent content = JsonContent.Create(newInvoices);
            var response = await _invoices.PostAsync($"{_DalConnectionString}/api/Invoices", content);
            response.EnsureSuccessStatusCode();
            Invoices? invoices = await response.Content.ReadFromJsonAsync<Invoices>();

            return invoices;
        }

        [HttpDelete("{id}")]
        public async Task DeleteInvoices(int id)
        {
            var response = await _invoices.DeleteAsync($"{_DalConnectionString}/api/Invoices/DeleteInvoices/{id}");
            response.EnsureSuccessStatusCode();
        }

        [HttpPut]
        public async Task PutInvoices(Invoices newInvoices)
        {
            JsonContent content = JsonContent.Create(newInvoices);
            var response = await _invoices.PutAsync($"{_DalConnectionString}/api/Invoices/PutInvoices", content);
            response.EnsureSuccessStatusCode();
        }
    }
}
