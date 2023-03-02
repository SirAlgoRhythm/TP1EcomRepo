using Microsoft.AspNetCore.Mvc;
using TheWebsite.Models;

namespace TheWebsite.Controllers
{
    public class ProduitsController : Controller
    {
        public TheWebsiteContext DbContext { get; set; }
        public ProduitsController()
        {
            this.DbContext = new TheWebsiteContext();
        }
        public IActionResult GestionProduits(Models.Utilisateur utilisateur)
        {
            //Donne la liste des produits actifs du vendeur connecté
            List<Models.Produit> produitList = this.DbContext.Produits.Where(u => u.UtilisateurId == utilisateur.UtilisateurId).ToList();
            Models.GestionProduitVM gestionProduitVM = new GestionProduitVM(utilisateur, produitList);
            return View(gestionProduitVM);
        }

        [HttpPost]
        public IActionResult AddProduit(Models.Produit produit)
        {
            Utilisateur vendeur = this.DbContext.Utilisateurs.Find(produit.UtilisateurId);
            if (ModelState.IsValid)
            {
                produit.ProduitId = Guid.NewGuid();
                this.DbContext.Produits.Add(produit);
                this.DbContext.SaveChanges();
                return RedirectToAction("GestionProduits", vendeur);
            }
            return View(vendeur);
        }
    }
}
