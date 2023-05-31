using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KoursProject.Data;
using KoursProject.Models;
using KoursProject.Models.Domain;

namespace KoursProject.Controllers
{
    public class DriversController : Controller
    {
        private readonly MVCProductDbContext mvcProductDbContext;

        public DriversController(MVCProductDbContext mvcProductDbContext)
        {
            this.mvcProductDbContext = mvcProductDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Drivers = await mvcProductDbContext.Drivers.ToListAsync();
            return View(Drivers);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddDriversViewModel addDriversRequest)
        {
            var drivers = new Drivers()
            {
                Id = Guid.NewGuid(),
                Surname = addDriversRequest.Surname,
                Name = addDriversRequest.Name,
                PhoneNumber = addDriversRequest.PhoneNumber,
                Email = addDriversRequest.Email,
                Address = addDriversRequest.Address,
                DateOfBirth = addDriversRequest.DateOfBirth
            };

            await mvcProductDbContext.Drivers.AddAsync(drivers);
            await mvcProductDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var drivers = await mvcProductDbContext.Drivers.FirstOrDefaultAsync(x => x.Id == id);
            if (drivers != null)
            {
                var viewModel = new UpdateDriversViewModel()
                {
                    Id = drivers.Id,
                    Surname = drivers.Surname,
                    Name = drivers.Name,
                    PhoneNumber = drivers.PhoneNumber,
                    Email = drivers.Email,
                    Address = drivers.Address,
                    DateOfBirth= drivers.DateOfBirth
                };
                return await Task.Run(() => View("View", viewModel));
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateDriversViewModel model)
        {
            var drivers = await mvcProductDbContext.Drivers.FindAsync(model.Id);
            if (drivers != null)
            {
                drivers.Surname = model.Surname;
                drivers.Name = model.Name;
                drivers.PhoneNumber = model.PhoneNumber;
                drivers.Email = model.Email;
                drivers.Address = model.Address;
                drivers.DateOfBirth= model.DateOfBirth;

                await mvcProductDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateDriversViewModel model)
        {
            var drivers = await mvcProductDbContext.Drivers.FindAsync(model.Id);

            if (drivers != null)
            {
                mvcProductDbContext.Drivers.Remove(drivers);
                await mvcProductDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
