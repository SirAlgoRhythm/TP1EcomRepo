using Microsoft.AspNetCore.Mvc;

namespace TheWebsite.Controllers
{
    public class StatistiqueController : Controller
    {
        public IActionResult Index()
        {
            return View("VendorStatistique");
        }
    }
}
