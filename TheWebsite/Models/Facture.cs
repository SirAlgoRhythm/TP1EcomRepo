namespace TheWebsite.Models
{
    public class Facture
    {
        public Facture()
        {
            ProduitPanierList = new List<ProduitPanier>();
        }
        public Guid FactureId { get; set; }
        public DateTime DateTimeDay { get; set; }
        public ICollection<ProduitPanier> ProduitPanierList { get; set; }
        public Utilisateur Utilisateur { get; set; }
    }
}
