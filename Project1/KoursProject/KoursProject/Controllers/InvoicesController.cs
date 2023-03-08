using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KoursProject.Data;
using KoursProject.Models;
using KoursProject.Models.Domain;

namespace KoursProject.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly MVCProductDbContext mvcProductDbContext;

        public InvoicesController(MVCProductDbContext mvcProductDbContext)
        {
            this.mvcProductDbContext = mvcProductDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Invoices = await mvcProductDbContext.Invoices.ToListAsync();
            return View(Invoices);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddInvoicesViewModel addInvoicesRequest)
        {
            var invoices = new Invoices()
            {
                Id = Guid.NewGuid(),
                InvoiceType = addInvoicesRequest.InvoiceType,
                Descrption = addInvoicesRequest.Descrption
            };

            await mvcProductDbContext.Invoices.AddAsync(invoices);
            await mvcProductDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var invoices = await mvcProductDbContext.Invoices.FirstOrDefaultAsync(x => x.Id == id);
            if (invoices != null)
            {
                var viewModel = new UpdateInvoicesViewModel()
                {
                    Id = invoices.Id,
                    InvoiceType = invoices.InvoiceType,
                    Descrption = invoices.Descrption
                };
                return await Task.Run(() => View("View", viewModel));
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateInvoicesViewModel model)
        {
            var invoices = await mvcProductDbContext.Invoices.FindAsync(model.Id);
            if (invoices != null)
            {
                invoices.InvoiceType = model.InvoiceType;
                invoices.Descrption = model.Descrption;

                await mvcProductDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateInvoicesViewModel model)
        {
            var invoices = await mvcProductDbContext.Invoices.FindAsync(model.Id);

            if (invoices != null)
            {
                mvcProductDbContext.Invoices.Remove(invoices);
                await mvcProductDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
