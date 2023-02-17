using Microsoft.AspNetCore.Mvc;

namespace KoursProject.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
