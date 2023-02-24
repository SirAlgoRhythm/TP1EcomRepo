using Microsoft.AspNetCore.Mvc;

namespace TheWebsite.Controllers
{
    public class ProduitsController : Controller
    {
        public IActionResult GestionProduits()
        {
            return View();
        }
    }
}
