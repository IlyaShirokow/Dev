using Microsoft.AspNetCore.Mvc;
using Kours.DAL.DAL;
using Kours.Domain.Models;

namespace Kours.Controllers
{
    [ApiController]
    [Route("api/Order")]
    [ApiExplorerSettings(GroupName = "order")]
    public class OrderController : Controller
    {
        private readonly OrderDAL _dal;

        public OrderController(OrderDAL orderDAL)
        {
            _dal = orderDAL;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrder()
        {
            return await _dal.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<Order>> NewOrder(Order order)
        {
            return await _dal.Add(order);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order?>> GetOrder(int id)
        {
            return await _dal.Get(id);
        }

        [HttpPut("PutProduct")]
        public async Task<ActionResult<Order?>> PutOrder(Order order)
        {
            return await _dal.Update(order);
        }

        [HttpDelete("DeleteOrder/{id}")]
        public async Task<ActionResult<Order?>> Delete(int id)
        {
            return await _dal.Delete(id);
        }
    }
}
