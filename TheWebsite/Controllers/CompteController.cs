using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using TheWebsite.Models;

namespace TheWebsite.Controllers
{
    public class CompteController : Controller
    {
        public TheWebsiteContext DbContext { get; set; }
        public CompteController()
        {
            this.DbContext = new TheWebsiteContext();
        }
        //à enlever quand on va utiliser la bd
        List<Models.Utilisateur> allUtilisateurs = new List<Models.Utilisateur>() {
            new Models.Utilisateur { UtilisateurId=Guid.NewGuid(), Name="Nom1", LastName="LastName1", IsVendor=false},
            new Models.Utilisateur { UtilisateurId=Guid.NewGuid(), Name="Nom2", LastName="LastName2", IsVendor=true},
            new Models.Utilisateur { UtilisateurId=Guid.NewGuid(), Name="Nom3", LastName="LastName3", IsVendor=false}
        };

        [HttpGet]
        public IActionResult Connexion(TheWebsite.Models.ConnexionUtilisateur connexionUtilisateur)
        {
            //à mettre quand on va utiliser la bd
            //TheWebsiteContext theWebsiteContext = new TheWebsiteContext();
            //Models.Utilisateur utilisateur = theWebsiteContext.Utilisateurs.Where(u => !u.UtilisateurId == utilisateurId).First();

            if (connexionUtilisateur.UtilisateurId != default(Guid))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();

        }
        [HttpGet]
        public IActionResult ClientConnexion()
        {
            TheWebsite.Models.ConnexionUtilisateur connexionUtilisateur = new TheWebsite.Models.ConnexionUtilisateur();
            //à mettre quand on va utiliser la bd
            //TheWebsiteContext theWebsiteContext = new TheWebsiteContext();
            //List<Models.Utilisateur> utilisateurs = theWebsiteContext.Utilisateurs.Where(u => !u.IsVendor).ToList();

            //à enlever quand on va utiliser la bd
            List<TheWebsite.Models.Utilisateur> utilisateurs = new List<TheWebsite.Models.Utilisateur>();
            foreach (var utilisateur in allUtilisateurs)
            {
                if (!utilisateur.IsVendor)
                {
                    utilisateurs.Add(utilisateur);
                }
            }
            connexionUtilisateur.Utilisateurs = utilisateurs;

            ViewBag.UserType = "Client";
            ViewBag.Switch = "VendorConnexion";
            ViewBag.Add = "ClientAdd";
            ViewBag.ButtonText = "vendeur";

            return View("Connexion", connexionUtilisateur);
        }
        [HttpGet]
        public IActionResult VendorConnexion()
        {
            Models.ConnexionUtilisateur connexionUtilisateur = new Models.ConnexionUtilisateur();
            //à mettre quand on va utiliser la bd
            //List<Models.Utilisateur> utilisateurs = this.DbContext.Utilisateurs.Where(u => u.IsVendor).ToList();

            //à enlever quand on va utiliser la bd
            List<Models.Utilisateur> utilisateurs = new List<Models.Utilisateur>();
            foreach (var utilisateur in allUtilisateurs)
            {
                if (utilisateur.IsVendor)
                {
                    utilisateurs.Add(utilisateur);
                }
            }
            connexionUtilisateur.Utilisateurs = utilisateurs;


            ViewBag.UserType = "Vendeur";
            ViewBag.Switch = "ClientConnexion";
            ViewBag.Add = "VendorAdd";
            ViewBag.ButtonText = "client";


            return View("Connexion", connexionUtilisateur);
        }
        [HttpGet]
        public IActionResult ClientAdd()
        {
            //ViewBag.Id = Guid.NewGuid();
            ViewBag.Partial = "        <div class=\"mb-3 row\">\r\n            <label asp-for=\"Solde\" class=\"col-sm-2 col-form-label\">Solde</label>\r\n            <div class=\"col-sm-10\">\r\n                <input asp-for=\"Solde\" type=\"text\" class=\"form-control\" placeholder=\"Solde\">\r\n                <span asp-validation-for=\"Solde\" class=\"text-danger\"></span>\r\n            </div>\r\n        </div>";
            return View("Inscription");
        }
        [HttpGet]
        public IActionResult ClientAdded(Models.Utilisateur utilisateur)
        {
            //utilisateur.IsVendor = false;

            if (ModelState.IsValid)
            {
                //mettre l'utilisateur dans la bd
                this.DbContext.Utilisateurs.Add(utilisateur);
                this.DbContext.SaveChanges();
                return RedirectToAction("InscriptionResult", utilisateur);
            }

            ViewBag.Id = Guid.NewGuid();
            ViewBag.Partial = "        <div class=\"mb-3 row\">\r\n            <label asp-for=\"Solde\" class=\"col-sm-2 col-form-label\">Solde</label>\r\n            <div class=\"col-sm-10\">\r\n                <input asp-for=\"Solde\" type=\"text\" class=\"form-control\" placeholder=\"Solde\">\r\n                <span asp-validation-for=\"Solde\" class=\"text-danger\"></span>\r\n            </div>\r\n        </div>";
            return View("Inscription");
        }
        public IActionResult InscriptionResult(Models.Utilisateur utilisateur)
        {
            return View(utilisateur);
        }
        [HttpGet]
        public IActionResult VendorAdd()
        {
            ViewBag.Id = Guid.NewGuid();
            ViewBag.Partial = " ";
            return View("Inscription");
        }
        [HttpPost]
        public IActionResult VendorAdd(Models.Utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
                utilisateur.IsVendor = true;
                //mettre l'utilisateur dans la bd
                this.DbContext.Utilisateurs.Add(utilisateur);
                this.DbContext.SaveChanges();
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            return View("Inscription");
        }
        [HttpGet]
        public IActionResult ClientUpdate(Models.Utilisateur tempUtilisateur)
        {
            ////Trouver l'utilisateur dans la bd
            //Models.Utilisateur utilisateur = this.DbContext.Utilisateurs.Find(tempUtilisateur.UtilisateurId);
            ////faire les modifications
            //utilisateur.Name = tempUtilisateur.Name;
            //utilisateur.LastName = tempUtilisateur.LastName;
            //this.DbContext.SaveChanges();
            return View("ClientModification", allUtilisateurs[0]);
        }
        public IActionResult VendorUpdate(Models.Utilisateur tempUtilisateur)
        {
            ////Trouver l'utilisateur dans la bd
            //Models.Utilisateur utilisateur = this.DbContext.Utilisateurs.Find(tempUtilisateur.UtilisateurId);
            ////faire les modifications
            //utilisateur.Name = tempUtilisateur.Name;
            //utilisateur.LastName = tempUtilisateur.LastName;
            //this.DbContext.SaveChanges();
            return View("VendorModification", allUtilisateurs[0]);
        }
    }
}
