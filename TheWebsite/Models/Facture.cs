namespace TheWebsite.Models
{
    public class Facture
    {
        //public Facture()
        //{
        //    ProduitPanierList = new List<ProduitPanier>();
        //}
        //public ICollection<ProduitPanier> ProduitPanierList { get; set; }

        //Test one-to-one
        public Guid ProduitPanierId { get; set; }
        public ProduitPanier ProduitPanier { get; set; }

        public Guid FactureId { get; set; }
        public DateTime DateTimeDay { get; set; }
      
        public Utilisateur Utilisateur { get; set; }
    }
}
