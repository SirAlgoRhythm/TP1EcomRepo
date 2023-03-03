using Microsoft.AspNetCore.Mvc;
using TheWebsite.Models;

namespace TheWebsite.Controllers
{
    public class HomeController : Controller
    {
        public TheWebsiteContext DbContext { get; set; }
        public HomeController()
        {
            this.DbContext = new TheWebsiteContext();
        }
        public IActionResult Index(Models.Utilisateur utilisateur)
        {
            IndexVM indexVM = new IndexVM(utilisateur);
            //Chercher tous les produits des vendeurs
            indexVM.ProduitList = this.DbContext.Produits.ToList();
            return View(indexVM);
        }
    }
}
