using Kours.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Kours.Domain.Controllers
{
    [ApiController]
    [Route("api/Domain/Order")]
    public class OrderController : ControllerBase
    {
        private readonly string? _DalConnectionString;
        private readonly HttpClient _order;

        public OrderController(IConfiguration conf)
        {
            _DalConnectionString = conf.GetValue<string>("DalConnectionString");
            _order = new HttpClient();
        }

        [HttpGet]
        public async Task<ActionResult<Order[]>> GetOrder()
        {
            var response = await _order.GetAsync($"{_DalConnectionString}/api/Order");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            if (content == null) return NotFound();

            return JsonSerializer.Deserialize<Order[]>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? Array.Empty<Order>();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order?>> GetOrder(int id)
        {
            var response = await _order.GetAsync($"{_DalConnectionString}/api/Order/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            if (content == null) return NotFound();

            return JsonSerializer.Deserialize<Order?>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        [HttpPost]
        public async Task<Order?> PostOrder(Order newOrder)
        {
            JsonContent content = JsonContent.Create(newOrder);
            var response = await _order.PostAsync($"{_DalConnectionString}/api/Order", content);
            response.EnsureSuccessStatusCode();
            Order? order = await response.Content.ReadFromJsonAsync<Order>();

            return order;
        }

        [HttpDelete("{id}")]
        public async Task DeleteOrder(int id)
        {
            var response = await _order.DeleteAsync($"{_DalConnectionString}/api/Order/DeleteOrder/{id}");
            response.EnsureSuccessStatusCode();
        }

        [HttpPut]
        public async Task PutOrder(Order newOrder)
        {
            JsonContent content = JsonContent.Create(newOrder);
            var response = await _order.PutAsync($"{_DalConnectionString}/api/Order/PutOrder", content);
            response.EnsureSuccessStatusCode();
        }
    }
}
