using Microsoft.AspNetCore.Mvc;

namespace TheWebsite.Controllers
{
    public class ConnexionController : Controller
    {
        //à enlever quand on va utiliser la bd
        List<Models.Utilisateur> allUtilisateurs = new List<Models.Utilisateur>() { 
            new Models.Utilisateur { Name="Nom1", IsVendor=false},
            new Models.Utilisateur { Name="Nom2", IsVendor=true},
            new Models.Utilisateur { Name="Nom3", IsVendor=false}
        };

        public IActionResult ClientConnexion()
        {
            //à mettre quand on va utiliser la bd
            //TheWebsiteContext theWebsiteContext = new TheWebsiteContext();
            //List<Models.Utilisateur> utilisateurs = theWebsiteContext.Utilisateurs.Where(u => !u.IsVendor).ToList();

            //à enlever quand on va utiliser la bd
            List<Models.Utilisateur> utilisateurs = new List<Models.Utilisateur>();
            foreach (var utilisateur in allUtilisateurs)
            {
                if (!utilisateur.IsVendor)
                {
                    utilisateurs.Add(utilisateur);
                }
            }

            ViewBag.UserType = "Client";
            ViewBag.Action = "VendorConnexion";
            ViewBag.ButtonText = "vendeur";


            return View("Connexion", utilisateurs);
        }
        public IActionResult VendorConnexion()
        {
            //à mettre quand on va utiliser la bd
            //TheWebsiteContext theWebsiteContext = new TheWebsiteContext();
            //List<Models.Utilisateur> utilisateursq = theWebsiteContext.Utilisateurs.Where(u=>u.IsVendor).ToList();

            //à enlever quand on va utiliser la bd
            List<Models.Utilisateur> utilisateurs = new List<Models.Utilisateur>();
            foreach (var utilisateur in allUtilisateurs)
            {
                if (utilisateur.IsVendor)
                {
                    utilisateurs.Add(utilisateur);
                }
            }

            ViewBag.UserType = "Vendeur";
            ViewBag.Action = "ClientConnexion";
            ViewBag.ButtonText = "client";

            return View("Connexion", utilisateurs);
        }
    }
}
