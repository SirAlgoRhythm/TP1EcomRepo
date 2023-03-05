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

        public IActionResult AjoutPanier(Guid produitId, Guid utilisateurId)
        {
            Produit produitAjout = this.DbContext.Produits.Find(produitId);
            Utilisateur utilisateur = this.DbContext.Utilisateurs.Find(utilisateurId);

            //Si on trouve un panier
            if (this.DbContext.ProduitsPanier.Any(p => p.UtilisateurId == utilisateurId))
            {
                Models.ProduitPanier panier = this.DbContext.ProduitsPanier.Where(p => p.UtilisateurId == utilisateurId).First();
                // ajouter un produit à la liste de produits du panier
                panier.Produits.Add(produitAjout);
                this.DbContext.SaveChanges();
            }
            else
            {
                //sinon on crée un nouveau panier pour ce client
                Models.ProduitPanier panier = new ProduitPanier();
                panier.Produits = new List<Produit>();
                panier.Produits.Add(produitAjout);
                panier.UtilisateurId = utilisateurId;
                panier.Utilisateur = utilisateur;
                panier.ProduitPanierId = Guid.NewGuid();

                this.DbContext.ProduitsPanier.Add(panier);
                this.DbContext.SaveChanges();
            }

            List<Produit> produitList = this.DbContext.Produits.Where(p => p.ProduitId != produitId).ToList();

            List<ProduitPanier> produitPanierList = this.DbContext.ProduitsPanier.Where(p => p.UtilisateurId == utilisateurId).ToList();
            
            IndexVM indexVM = new IndexVM(utilisateur, produitList, produitPanierList);

            return View("index", indexVM);
        }
    }
}
