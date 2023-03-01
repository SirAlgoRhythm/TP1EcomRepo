using System.ComponentModel.DataAnnotations;

namespace TheWebsite.Models
{
    public class Utilisateur
    {
        public Guid UtilisateurId { get; set; }
        [Required(ErrorMessage = "Champs Requis !")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Champs Requis !")]
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public bool IsVendor { get; set; }
        public float Solde { get; set; }
    }
}
