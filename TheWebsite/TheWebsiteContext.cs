using Microsoft.EntityFrameworkCore;

namespace TheWebsite
{
    public class TheWebsiteContext: DbContext
    {
        public DbSet<Models.Facture> Factures { get; set; }
        public DbSet<Models.Produit> Produits { get; set; }
        public DbSet<Models.StatistiqueClient> StatistiqueClients { get; set; }
        public DbSet<Models.StatistiqueVendeur> StatistiqueVendeurs { get; set; }
        public DbSet<Models.ProduitPanier> ProduitsPanier { get; set; }
        public DbSet<Models.Utilisateur> Utilisateurs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TheWebsiteDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string dbName = "TheWebsiteDB";
            dbContextOptionsBuilder.UseSqlServer($"{connStr};Database={dbName};");
        }

    }
}
