using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KoursProject.Data;
using KoursProject.Models;
using KoursProject.Models.Domain;

namespace KoursProject.Controllers
{
    public class OrderController : Controller
    {
        private readonly MVCProductDbContext mvcProductDbContext;

        public OrderController(MVCProductDbContext mvcProductDbContext)
        {
            this.mvcProductDbContext = mvcProductDbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(mvcProductDbContext.Order
                .Include(rp=>rp.Products)
                .Include(rp=>rp.Autos)
                .Include(rp=>rp.Drivers)
                .Include(rp=>rp.Organizations)
                .Include(rp=>rp.Invoices)
                .ToList());
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddOrderViewModel addOrderRequest)
        {
            var order = new Order()
            {
                Id = Guid.NewGuid(),
                ProductsID = addOrderRequest.ProductsID,
                AutosID = addOrderRequest.AutosID,
                DriversId = addOrderRequest.DriversId,
                OrganizationsId = addOrderRequest.OrganizationsId,
                PhoneNumber= addOrderRequest.PhoneNumber,
                Address= addOrderRequest.Address,
                Data= addOrderRequest.Data,
                Email= addOrderRequest.Email,
                InvoicesId=addOrderRequest.InvoicesId
            };

            await mvcProductDbContext.Order.AddAsync(order);
            await mvcProductDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
