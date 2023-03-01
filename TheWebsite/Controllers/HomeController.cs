using Microsoft.AspNetCore.Mvc;
using TheWebsite.Models;

namespace TheWebsite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(Models.Utilisateur utilisateur)
        {
            IndexVM indexVM = new IndexVM(utilisateur);
            return View(indexVM);
        }
    }
}
