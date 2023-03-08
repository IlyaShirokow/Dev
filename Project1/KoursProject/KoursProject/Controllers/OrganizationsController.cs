using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KoursProject.Data;
using KoursProject.Models;
using KoursProject.Models.Domain;

namespace KoursProject.Controllers
{
    public class OrganizationsController : Controller
    {
        private readonly MVCProductDbContext mvcProductDbContext;

        public OrganizationsController(MVCProductDbContext mvcProductDbContext)
        {
            this.mvcProductDbContext = mvcProductDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Organizations = await mvcProductDbContext.Organizations.ToListAsync();
            return View(Organizations);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddOrganizationsViewModel addOrganizatonsRequest)
        {
            var organizations = new Organizations()
            {
                Id = Guid.NewGuid(),
                NameOrganizations = addOrganizatonsRequest.NameOrganizations,
                Email = addOrganizatonsRequest.Email,
                PhoneNumber = addOrganizatonsRequest.PhoneNumber
            };

            await mvcProductDbContext.Organizations.AddAsync(organizations);
            await mvcProductDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var organizations = await mvcProductDbContext.Organizations.FirstOrDefaultAsync(x => x.Id == id);
            if (organizations != null)
            {
                var viewModel = new UpdateOrganizationsViewModel()
                {
                    Id = organizations.Id,
                    NameOrganizations = organizations.NameOrganizations,
                    Email = organizations.Email,
                    PhoneNumber = organizations.PhoneNumber
                };
                return await Task.Run(() => View("View", viewModel));
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateOrganizationsViewModel model)
        {
            var organizations = await mvcProductDbContext.Organizations.FindAsync(model.Id);
            if (organizations != null)
            {
                organizations.NameOrganizations = model.NameOrganizations;
                organizations.Email = model.Email;
                organizations.PhoneNumber = model.PhoneNumber;

                await mvcProductDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateOrganizationsViewModel model)
        {
            var organizations = await mvcProductDbContext.Organizations.FindAsync(model.Id);

            if (organizations != null)
            {
                mvcProductDbContext.Organizations.Remove(organizations);
                await mvcProductDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
