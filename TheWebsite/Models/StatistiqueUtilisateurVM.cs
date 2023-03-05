namespace TheWebsite.Models
{
    public class StatistiqueUtilisateurVM
    {
        public Utilisateur Utilisateur { get; set; }
        public StatistiqueClient StatistiqueClient { get; set; }
        public StatistiqueVendeur StatistiqueVendeur { get; set; }
    }
}
