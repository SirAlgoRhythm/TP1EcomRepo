using Microsoft.EntityFrameworkCore;

namespace TheWebsite
{
    public class TheWebsiteContext : DbContext
    {
        public DbSet<Models.Facture> Factures { get; set; }
        public DbSet<Models.Produit> Produits { get; set; }
        public DbSet<Models.StatistiqueClient> StatistiqueClients { get; set; }
        public DbSet<Models.StatistiqueVendeur> StatistiqueVendeurs { get; set; }
        public DbSet<Models.ProduitPanier> ProduitsPanier { get; set; }
        public DbSet<Models.Utilisateur> Utilisateurs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            //Antoine
            //string connStr = "Data Source=(localdb)\\ProjectModels;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            
            //Élizabeth
            string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TheWebsiteDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            
            string dbName = "TheWebsiteDB";
            dbContextOptionsBuilder.UseSqlServer($"{connStr};Database={dbName};");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Utilisateur>().HasData(
                new Models.Utilisateur() {UtilisateurId= Guid.NewGuid(), IsVendor=false, LastName="nom1", Name="prenom1", PasswordHash="motdepasse",Solde=123 },
                new Models.Utilisateur() { UtilisateurId = Guid.NewGuid(), IsVendor = true, LastName = "nom2", Name = "prenom2", PasswordHash = "motdepasse", Solde = 13 }
                );
        }

    }
}
