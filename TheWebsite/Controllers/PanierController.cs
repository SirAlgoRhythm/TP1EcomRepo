using Microsoft.AspNetCore.Mvc;
using TheWebsite.Models;

namespace TheWebsite.Controllers
{
    public class PanierController : Controller
    {
        public TheWebsiteContext DbContext { get; set; }
        public PanierController()
        {
            this.DbContext = new TheWebsiteContext();
        }

        public IActionResult Index(Guid utilisateurId)
        {
            Models.ProduitPanier panier = this.DbContext.ProduitsPanier.Where(p => p.UtilisateurId == utilisateurId).First();

            //if (panier.Produits.Count == 0)
            //    ViewBag.Empty = true;
            //else 
            //    ViewBag.Empty = false;
            panier.Produits.Add(this.DbContext.Produits.First());

            return View("Panier", panier);
        }
        public IActionResult Paiement()
        {
            return View();
        }
    }
}
