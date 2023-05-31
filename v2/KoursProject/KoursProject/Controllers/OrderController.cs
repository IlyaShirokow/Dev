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
        [HttpGet]
        public IActionResult Add()
        {
            return View();
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
        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var order = await mvcProductDbContext.Order.FirstOrDefaultAsync(x => x.Id == id);
            if (order != null)
            {
                var viewModel = new UpdateOrderViewModel()
                {
                    Id = order.Id,
                    ProductsID = order.ProductsID,
                    AutosID = order.AutosID,
                    DriversId = order.DriversId,
                    OrganizationsId = order.OrganizationsId,
                    PhoneNumber = order.PhoneNumber,
                    Address = order.Address,
                    Data = order.Data,
                    Email = order.Email,
                    InvoicesId = order.InvoicesId
                };
                return await Task.Run(() => View("View", viewModel));
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateOrderViewModel model)
        {
            var order = await mvcProductDbContext.Order.FindAsync(model.Id);
            if (order != null)
            {
                order.ProductsID = model.ProductsID;
                order.AutosID = model.AutosID;
                order.DriversId = model.DriversId;
                order.OrganizationsId = model.OrganizationsId;
                order.PhoneNumber = model.PhoneNumber;
                order.Address = model.Address;
                order.Data = model.Data;
                order.Email = model.Email;
                order.InvoicesId = model.InvoicesId;

                await mvcProductDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateOrderViewModel model)
        {
            var order = await mvcProductDbContext.Order.FindAsync(model.Id);

            if (order != null)
            {
                mvcProductDbContext.Order.Remove(order);
                await mvcProductDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        }
}
