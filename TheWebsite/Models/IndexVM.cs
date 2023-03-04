namespace TheWebsite.Models
{
    public class IndexVM
    {
        public Utilisateur UtilisateurActif { get; set; }
        public List<Produit> ProduitList { get; set; }
        public List<ProduitPanier> ProduitPanierList { get; set; }

        public IndexVM(Utilisateur u, List<Produit> produits, List<ProduitPanier> produitPaniers)
        {
            this.UtilisateurActif = u;
            this.ProduitList = produits;
            this.ProduitPanierList = produitPaniers;
        }

    }
}
