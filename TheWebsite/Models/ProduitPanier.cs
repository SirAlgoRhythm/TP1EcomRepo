using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheWebsite.Models
{
    public class ProduitPanier
    {
        public Guid ProduitPanierId { get; set; }
        
        public Guid ProduitId { get; set; }
        public Produit Produit { get; set; }
        public int Number { get; set; }

        public Guid FactureId { get; set; }
        public Facture Facture { get; set; }
        
    }
}
