using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Kours.Domain.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/Domain/Products")]
    public class ProductsController : ControllerBase
    {
        private readonly string? _DalConnectionString;
        private readonly HttpClient _products;

        public ProductsController(IConfiguration conf)
        {
            _DalConnectionString = conf.GetValue<string>("DalConnectionString");
            _products = new HttpClient();
        }

        [HttpGet]
        public async Task<ActionResult<Products[]>> GetProducts()
        {
            var response = await _products.GetAsync($"{_DalConnectionString}/api/Products");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            if (content == null) return NotFound();

            return JsonSerializer.Deserialize<Products[]>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? Array.Empty<Products>();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Products?>> GetProducts(int id)
        {
            var response = await _products.GetAsync($"{_DalConnectionString}/api/Products/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            if (content == null) return NotFound();

            return JsonSerializer.Deserialize<Products?>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        [HttpPost]
        public async Task<Products?> PostProducts(Products newProducts)
        {
            JsonContent content = JsonContent.Create(newProducts);
            var response = await _products.PostAsync($"{_DalConnectionString}/api/Products", content);
            response.EnsureSuccessStatusCode();
            Products? products = await response.Content.ReadFromJsonAsync<Products>();

            return products;
        }

        [HttpDelete("{id}")]
        public async Task DeleteProducts(int id)
        {
            var response = await _products.DeleteAsync($"{_DalConnectionString}/api/Products/DeleteProducts/{id}");
            response.EnsureSuccessStatusCode();
        }

        [HttpPut]
        public async Task PutProducts(Products newProducts)
        {
            JsonContent content = JsonContent.Create(newProducts);
            var response = await _products.PutAsync($"{_DalConnectionString}/api/Products/PutProducts", content);
            response.EnsureSuccessStatusCode();
        }
    }
}
