namespace TheWebsite.Models
{
    public class IndexVM
    {
        public Utilisateur UtilisateurActif { get; set; }
        public List<Produit> ProduitList { get; set; }

        public IndexVM(Utilisateur u, List<Produit> produits)
        {
            this.UtilisateurActif = u;
            this.ProduitList = produits;
        }

    }
}
