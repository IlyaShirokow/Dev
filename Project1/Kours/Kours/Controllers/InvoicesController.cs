using Kours.DAL.DAL;
using Kours.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Kours.Controllers
{
    [ApiController]
    [Route("api/Invoices")]
    [ApiExplorerSettings(GroupName = "invoices")]
    public class InvoicesController : Controller
    {
        private readonly InvoicesDAL _dal;

        public InvoicesController(InvoicesDAL invoicesDAL)
        {
            _dal = invoicesDAL;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoices>>> GetInvoices()
        {
            return await _dal.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<Invoices>> NewInvoices(Invoices invoices)
        {
            return await _dal.Add(invoices);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Invoices?>> GetInvoices(int id)
        {
            return await _dal.Get(id);
        }

        [HttpPut("PutPost")]
        public async Task<ActionResult<Invoices?>> PutInvoices(Invoices invoices)
        {
            return await _dal.Update(invoices);
        }

        [HttpDelete("DeleteInvoices/{id}")]
        public async Task<ActionResult<Invoices?>> Delete(int id)
        {
            return await _dal.Delete(id);
        }
    }
}
