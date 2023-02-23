using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KoursProject.Data;
using KoursProject.Models;
using KoursProject.Models.Domain;
using KoursProject.Data.KoursProject.Data;

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
        var Test = await mvcProductDbContext.Autos.ToListAsync();
        return View(Test);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Add(AddAutosViewModel addTestRequest)
    {
        var Autos = new Autos()
        {
            ID = Guid.NewGuid(),
            Car = addTestRequest.Car,
            Carnumber = addTestRequest.Carnumber,
            Condition = addTestRequest.Condition
        };

        await mvcProductDbContext.Autos.AddAsync(Autos);
        await mvcProductDbContext.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> View(Guid id)
    {
        var Autos = await mvcProductDbContext.Autos.FirstOrDefaultAsync(x => x.ID == id);
        if (Autos != null)
        {
            var viewModel = new UpdateAutosViewModel()
            {
                ID = Autos.ID,
                Car = Autos.Car,
                Carnumber = Autos.Carnumber,
                Condition = Autos.Condition
            };
            return await Task.Run(() => View("View", viewModel));
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> View(UpdateAutosViewModel model)
    {
        var Autos = await mvcProductDbContext.Autos.FindAsync(model.ID);
        if (Autos != null)
        {
            Autos.Car = model.Car;
            Autos.Carnumber = model.Carnumber;
            Autos.Condition = model.Condition;

            await mvcProductDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(UpdateAutosViewModel model)
    {
        var Autos = await mvcProductDbContext.Autos.FindAsync(model.ID);

        if (Autos != null)
        {
            mvcProductDbContext.Autos.Remove(Autos);
            await mvcProductDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
    }
}
}
