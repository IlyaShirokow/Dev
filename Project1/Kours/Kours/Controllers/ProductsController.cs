using Microsoft.AspNetCore.Mvc;
using Kours.DAL.DAL;
using Kours.Domain;

namespace Kours.Controllers
{
    [ApiController]
    [Route("api/Products")]
    [ApiExplorerSettings(GroupName = "products")]
    public class ProductsController : Controller
    {
        private readonly ProductsDAL _dal;

        public ProductsController(ProductsDAL productsDAL)
        {
            _dal = productsDAL;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        {
            return await _dal.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<Products>> NewProducts(Products products)
        {
            return await _dal.Add(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Products?>> GetProducts(int id)
        {
            return await _dal.Get(id);
        }

        [HttpPut("PutProducts")]
        public async Task<ActionResult<Products?>> PutProducts(Products products)
        {
            return await _dal.Update(products);
        }

        [HttpDelete("DeleteProducts/{id}")]
        public async Task<ActionResult<Products?>> Delete(int id)
        {
            return await _dal.Delete(id);
        }
    }
}
