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
            IndexVM indexVM = new IndexVM(utilisateur, null);
            //Chercher tous les produits des vendeurs
            indexVM.ProduitList = this.DbContext.Produits.ToList();
            return View(indexVM);
        }

        [HttpGet]
        public IActionResult Recherche(string search, Guid utilisateurId)
        {
            List<Produit> produitList = new List<Produit>();
            produitList = this.DbContext.Produits.Where(p => p.Title.Contains(search) || p.Description.Contains(search)).ToList();

            Utilisateur utilisateur = this.DbContext.Utilisateurs.Find(utilisateurId);
            IndexVM indexVM = new IndexVM(utilisateur, produitList);

            return View("index", indexVM);
        }

        //public IActionResult AjoutPanier(Models.Produit produit, Utilisateur utilisateur)
        //{

        //}
    }
}
