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
        public IActionResult VendorStatistique(Guid vendeurId)
        {
            int totalArticleSold = 0;
            Double totalCashReceved = 0;
            Double profit;

            //Trouver toutes les factures
            List<Facture> factures = this.DbContext.Factures.ToList();
            foreach(var facture in factures)
            {
                //Pour tous les produits dans une facture
                foreach(var produit in facture.ProduitPanierList)
                {
                    //Si le vendeur est lui qu'on veut 
                    if(produit.Produit.UtilisateurId == vendeurId)
                    {
                        totalArticleSold += produit.Number;
                        totalCashReceved += (produit.Produit.Price) * produit.Number;
                    }
                }
            }
            profit = (totalCashReceved * 15d / 100d);

            StatistiqueVendeur statistique = new StatistiqueVendeur() { StatistiqueVendeurId = vendeurId,
                                                                        //Ou c'est l'id de la statistique ?
                                                                        //StatistiqueVendeurId = Guid.NewGuid(),
                                                                        TotalCashReceved = totalCashReceved,
                                                                        Profit = profit, 
                                                                        TotalArticleSold = totalArticleSold };
            //ajouter la statistique dans la bd
            this.DbContext.StatistiqueVendeurs.Add(statistique);
            this.DbContext.SaveChanges();

            //vendeur pour navbar
            Models.Utilisateur vendeur = this.DbContext.Utilisateurs.Find(vendeurId);
            ViewBag.Vendeur = vendeur;

            return View(statistique);
        }
    }
}
