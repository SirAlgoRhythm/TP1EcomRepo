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
        public IActionResult GestionProduits(Guid utilisateurId)
        {
            //Trouver le vendeur
            Models.Utilisateur utilisateur = this.DbContext.Utilisateurs.Find(utilisateurId);
            //Donne la liste des produits actifs du vendeur connecté
            List<Models.Produit> produitList = this.DbContext.Produits.Where(u => u.UtilisateurId == utilisateurId).ToList();
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
                return RedirectToAction("GestionProduits", "Produits", vendeur);
            }
            return View(vendeur);
        }

        [HttpPost]
        public IActionResult SupprimerProduit(Guid produitId)
        {
            Models.Produit produit = this.DbContext.Produits.Find(produitId);
            Guid vendeurActif = produit.UtilisateurId;
            DbContext.Remove(produit);
            DbContext.SaveChanges();
            return RedirectToAction("GestionProduits",vendeurActif);
        }

        [HttpPost]
        public IActionResult ModifierProduit(Guid produitId, string Title, double Price, int Quantite)
        {
            Models.Produit produit = this.DbContext.Produits.Find(produitId);
            Models.Utilisateur vendeurActif = this.DbContext.Utilisateurs.Find(produit.UtilisateurId);

            produit.Title = Title;
            produit.Price = Price;
            produit.Quantite = Quantite;
            DbContext.SaveChanges();
            return RedirectToAction("GestionProduits", "Produits", vendeurActif);
        }
    }
}
