namespace TheWebsite.Models
{
    public class Utilisateur
    {
        public Guid UtilisateurId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public bool IsVendor { get; set; }
        public float Solde { get; set; }
    }
}
