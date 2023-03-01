using Microsoft.AspNetCore.Mvc;

namespace TheWebsite.Controllers
{
    public class PanierController : Controller
    {
        public IActionResult Index()
        {
            return View("Panier");
        }
        public IActionResult Paiement()
        {
            return View();
        }
    }
}
