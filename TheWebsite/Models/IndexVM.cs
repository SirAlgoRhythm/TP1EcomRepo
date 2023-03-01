namespace TheWebsite.Models
{
    public class IndexVM
    {
        public Utilisateur UtilisateurActif { get; set; }
        public List<Produit> ProduitList { get; set; }

        public IndexVM(Utilisateur u)
        {
            this.UtilisateurActif = u;
        }

    }
}
