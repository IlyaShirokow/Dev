using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.Domain;


namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        private readonly MVCDemoDbContext mvcDemoDbContext;

        public TestController(MVCDemoDbContext mvcDemoDbContext) 
        {
            this.mvcDemoDbContext = mvcDemoDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Test = await mvcDemoDbContext.Test.ToListAsync();
            return View(Test);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddTestViewModel addTestRequest) 
        {
            var test = new Test()
            {
                Id = Guid.NewGuid(),
                Name = addTestRequest.Name,
                Surname = addTestRequest.Surname,
                Email = addTestRequest.Email,
                Age = addTestRequest.Age,
                DateOfBirtch = addTestRequest.DateOfBirtch
            };

            await mvcDemoDbContext.Test.AddAsync(test);
            await mvcDemoDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var test = await mvcDemoDbContext.Test.FirstOrDefaultAsync(x => x.Id == id);
            if (test != null)
            {
                var viewModel = new UpdateTestViewModel()
                {
                    Id = test.Id,
                    Name = test.Name,
                    Surname = test.Surname,
                    Email = test.Email,
                    Age = test.Age,
                    DateOfBirtch = test.DateOfBirtch
                };
                return await Task.Run(()=>View("View", viewModel));
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateTestViewModel model)
        {
            var test = await mvcDemoDbContext.Test.FindAsync(model.Id);
            if (test != null)
            { 
                test.Name = model.Name;
                test.Surname= model.Surname;
                test.Email = model.Email;
                test.Age = model.Age;
                test.DateOfBirtch = model.DateOfBirtch;

                await mvcDemoDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateTestViewModel model)
        {
            var test = await mvcDemoDbContext.Test.FindAsync(model.Id);

            if (test != null) 
            {
                mvcDemoDbContext.Test.Remove(test);
                await mvcDemoDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
                return RedirectToAction("Index");
        }

    }
}
