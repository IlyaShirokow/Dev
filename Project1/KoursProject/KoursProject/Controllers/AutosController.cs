using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KoursProject.Data;
using KoursProject.Models;
using KoursProject.Models.Domain;

namespace KoursProject.Controllers
{
    public class AutosController : Controller
    {
        private readonly MVCProductDbContext mvcProductDbContext;

        public AutosController(MVCProductDbContext mvcProductDbContext)
        {
            this.mvcProductDbContext = mvcProductDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Autos = await mvcProductDbContext.Autos.ToListAsync();
            return View(Autos);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddAutosViewModel addAutosRequest)
        {
            var autos = new Autos()
            {
                Id = Guid.NewGuid(),
                Car = addAutosRequest.Car,
                Carnumber = addAutosRequest.Carnumber,
                Condition = addAutosRequest.Condition
            };

            await mvcProductDbContext.Autos.AddAsync(autos);
            await mvcProductDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var autos = await mvcProductDbContext.Autos.FirstOrDefaultAsync(x => x.Id == id);
            if (autos != null)
            {
                var viewModel = new UpdateAutosViewModel()
                {
                    Id = autos.Id,
                    Car = autos.Car,
                    Carnumber = autos.Carnumber,
                    Condition = autos.Condition
                };
                return await Task.Run(() => View("View", viewModel));
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateAutosViewModel model)
        {
            var autos = await mvcProductDbContext.Autos.FindAsync(model.Id);
            if (autos != null)
            {
                autos.Car = model.Car;
                autos.Carnumber = model.Carnumber;
                autos.Condition = model.Condition;

                await mvcProductDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateAutosViewModel model)
        {
            var autos = await mvcProductDbContext.Autos.FindAsync(model.Id);

            if (autos != null)
            {
                mvcProductDbContext.Autos.Remove(autos);
                await mvcProductDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
