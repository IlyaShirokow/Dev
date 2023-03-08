using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KoursProject.Data;
using KoursProject.Models;
using KoursProject.Models.Domain;

namespace KoursProject.Controllers
{
    public class ProductsController : Controller
    {
        private readonly MVCProductDbContext mvcProductDbContext;

        public ProductsController(MVCProductDbContext mvcProductDbContext)
        {
            this.mvcProductDbContext = mvcProductDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Products = await mvcProductDbContext.Products.ToListAsync();
            return View(Products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddProductsViewModel addProductsRequest)
        {
            var products = new Products()
            {
                Id = Guid.NewGuid(),
                Product = addProductsRequest.Product,
                Fragility = addProductsRequest.Fragility,
                Dimension = addProductsRequest.Dimension
            };

            await mvcProductDbContext.Products.AddAsync(products);
            await mvcProductDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var products = await mvcProductDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (products != null)
            {
                var viewModel = new UpdateProductsViewModel()
                {
                    Id = products.Id,
                    Product = products.Product,
                    Fragility = products.Fragility,
                    Dimension = products.Dimension
                };
                return await Task.Run(() => View("View", viewModel));
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateProductsViewModel model)
        {
            var products = await mvcProductDbContext.Products.FindAsync(model.Id);
            if (products != null)
            {
                products.Product = model.Product;
                products.Fragility = model.Fragility;
                products.Dimension = model.Dimension;

                await mvcProductDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateProductsViewModel model)
        {
            var products = await mvcProductDbContext.Products.FindAsync(model.Id);

            if (products != null)
            {
                mvcProductDbContext.Products.Remove(products);
                await mvcProductDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
