using KoursProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace KoursProject.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Check(Contact contact)
        {
            if (ModelState.IsValid) 
            {
                return Redirect("/");
            }
            return View("Index");
        }
    }

}
