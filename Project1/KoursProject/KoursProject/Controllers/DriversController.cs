using Microsoft.AspNetCore.Mvc;

namespace KoursProject.Controllers
{
    public class DriversController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
