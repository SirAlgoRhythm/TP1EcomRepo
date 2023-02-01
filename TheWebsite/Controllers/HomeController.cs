using Microsoft.AspNetCore.Mvc;

namespace TheWebsite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
