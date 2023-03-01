using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TheWebsite.Controllers
{
    public class FactureController : Controller
    {
        [HttpGet]
        public IActionResult Facture()
        {
            return View();
        }
    }
}
