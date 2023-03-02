namespace TheWebsite.Models
{
    public class GestionProduitVM
    {
        public Utilisateur VendeurActif { get; set; }
        public List<Produit>? ProduitsDuVendeur { get; set; }
        public Produit? ProduitAjouter { get; set; }

        public GestionProduitVM(Utilisateur u, List<Produit>? l)
        {
            VendeurActif = u;
            ProduitsDuVendeur = l;
        } 
        
        public GestionProduitVM() { }
    }
}
