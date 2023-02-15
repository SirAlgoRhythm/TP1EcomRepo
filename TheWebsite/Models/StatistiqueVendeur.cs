namespace TheWebsite.Models
{
    public class StatistiqueVendeur
    {
        public Guid StatistiqueVendeurId { get; set; }
        public Double TotalCashReceved { get; set; }
        public Double Profit { get; set; }
        public int TotalArticleSold { get; set; }
    }
}
