using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TheWebsite.Models;

namespace TheWebsite.Controllers
{
    public class StatistiqueController : Controller
    {
        public TheWebsiteContext DbContext { get; set; }
        public StatistiqueController()
        {
            this.DbContext = new TheWebsiteContext();
        }
        // À tester
        public IActionResult VendorStatistique(Guid utilisateurId)
        {
            int totalArticleSold = 0;
            Double totalCashReceved = 0;
            Double profit = 0;

            StatistiqueVendeur statistique = new StatistiqueVendeur()
            {
                StatistiqueVendeurId = utilisateurId,
                TotalArticleSold = totalArticleSold,
                TotalCashReceved = totalCashReceved,
                Profit = profit
            };
            //ajouter la statistique dans la bd
            this.DbContext.StatistiqueVendeurs.Add(statistique);
            //this.DbContext.SaveChanges();

            // pour la view
            StatistiqueUtilisateurVM statistiqueUtilisateurVM = new StatistiqueUtilisateurVM()
            {
                Utilisateur = this.DbContext.Utilisateurs.Find(utilisateurId),
                StatistiqueVendeur = statistique
            };

            return View(statistiqueUtilisateurVM);
        }

        // À tester
        public IActionResult ClientStatistique(Guid utilisateurId)
        {
            Double totalCashSpent = 0;
            int totalArticleBought = 0;

            StatistiqueClient statistique = new StatistiqueClient()
            {
                StatistiqueClientId = utilisateurId,
                //Ou c'est l'id de la statistique ?
                //StatistiqueClientId = Guid.NewGuid(),
                TotalCashSpent = totalCashSpent,
                TotalArticleBought = totalArticleBought
            };
            //ajouter la statistique dans la bd
            this.DbContext.StatistiqueClients.Add(statistique);
            //this.DbContext.SaveChanges();

            // pour la view
            StatistiqueUtilisateurVM statistiqueUtilisateurVM = new StatistiqueUtilisateurVM()
            {
                Utilisateur = this.DbContext.Utilisateurs.Find(utilisateurId),
                StatistiqueClient = statistique
            };

            return View(statistiqueUtilisateurVM);
        }
    }
}
