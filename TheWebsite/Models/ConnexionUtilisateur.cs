using System.ComponentModel.DataAnnotations;

namespace TheWebsite.Models
{
    public class ConnexionUtilisateur
    {
        public List<Utilisateur> Utilisateurs { get; set; }

        [Required(ErrorMessage = "Champs Requis !")]
        public Guid UtilisateurId { get; set; }

    }
}
