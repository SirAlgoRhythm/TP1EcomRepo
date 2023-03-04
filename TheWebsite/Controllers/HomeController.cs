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

        private Guid UtilisateurActif;
        public IActionResult Index(Models.Utilisateur utilisateur)
        {
            IndexVM indexVM = new IndexVM(utilisateur, null, null);
            UtilisateurActif = utilisateur.UtilisateurId;
            //Chercher tous les produits des vendeurs
            indexVM.ProduitList = this.DbContext.Produits.ToList();
            return View(indexVM);
        }

        [HttpGet]
        public IActionResult Recherche(string search, Guid utilisateurId)
        {
            List<Produit> produitList = new List<Produit>();
            produitList = this.DbContext.Produits.Where(p => p.Title.Contains(search) || p.Description.Contains(search)).ToList();

            List<ProduitPanier> produitPanierList = new List<ProduitPanier>();
            produitPanierList = this.DbContext.ProduitsPanier.Where(p => p.UtilisateurId == utilisateurId).ToList();

            Utilisateur utilisateur = this.DbContext.Utilisateurs.Find(utilisateurId);

            IndexVM indexVM = new IndexVM(utilisateur, produitList, produitPanierList);

            return View("index", indexVM);
        }

        public IActionResult AjoutPanier(Guid produitId)
        {
            Produit produit = this.DbContext.Produits.Find(produitId);
            Utilisateur utilisateur = this.DbContext.Utilisateurs.Find(UtilisateurActif);
            Models.ProduitPanier produitPanier = this.DbContext.ProduitsPanier.Where(p => p.UtilisateurId == UtilisateurActif).First();

            if (produitPanier == null)
            {
                //On crée un nouveau panier pour ce client
                produitPanier = new ProduitPanier();
                produitPanier.Produits.Add(produit);
                produitPanier.UtilisateurId = UtilisateurActif;
                produitPanier.Utilisateur = utilisateur;
                produitPanier.ProduitPanierId = Guid.NewGuid();

                this.DbContext.SaveChanges();
            }
            else
            {
                //Sinon on fait juste ajouter un produit à la liste de produits du panier
                produitPanier.Produits.Add(produit);

                this.DbContext.SaveChanges();
            }

            List<Produit> produitList = this.DbContext.Produits.Where(p => p.ProduitId != produitId).ToList();

            List<ProduitPanier> produitPanierList = this.DbContext.ProduitsPanier.Where(p => p.UtilisateurId == UtilisateurActif).ToList();
            
            IndexVM indexVM = new IndexVM(utilisateur, produitList, produitPanierList);

            return View("index", indexVM);
        }
    }
}
