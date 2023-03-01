using System.ComponentModel.DataAnnotations;

namespace TheWebsite.Models
{
    public class ConnexionUtilisateur
    {
        public List<Utilisateur> Utilisateurs { get; set; }
        public Guid UtilisateurId { get; set; }

    }
}
