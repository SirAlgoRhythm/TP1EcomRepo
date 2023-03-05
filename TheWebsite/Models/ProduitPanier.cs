using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheWebsite.Models
{
    public class ProduitPanier
    {
        public Guid ProduitPanierId { get; set; }
        
        public List<Produit> Produits { get; set; }

        //Test one-to-one
        //public Guid FactureId { get; set; }
        //public Facture Facture { get; set; }

        public Guid UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; }
        
    }
}
