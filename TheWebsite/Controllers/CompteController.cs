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

        [HttpGet]
        public IActionResult Connexion(Models.Utilisateur utilisateur)
        {
            //chercher l'utilisateur dans la bd
            //Models.Utilisateur utilisateur = this.DbContext.Utilisateurs.Find(connexionUtilisateur.UtilisateurId);

            if (this.DbContext.Utilisateurs.Any(o=>o.UtilisateurId== utilisateur.UtilisateurId))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();

        }
        [HttpGet]
        public IActionResult ClientConnexion()
        {
            //TheWebsite.Models.ConnexionUtilisateur connexionUtilisateur = new TheWebsite.Models.ConnexionUtilisateur();

            //chercher la liste des clients
            List<Models.Utilisateur> utilisateurs = this.DbContext.Utilisateurs.Where(u => !u.IsVendor).ToList();

            //connexionUtilisateur.Utilisateurs = utilisateurs;

            ViewBag.UserType = "Client";
            ViewBag.Switch = "VendorConnexion";
            ViewBag.Add = "ClientAdd";
            ViewBag.ButtonText = "vendeur";
            ViewBag.Data = utilisateurs;

            return View("Connexion", utilisateurs);
        }
        [HttpGet]
        public IActionResult VendorConnexion()
        {
            Models.ConnexionUtilisateur connexionUtilisateur = new Models.ConnexionUtilisateur();

            //Chercher la liste des vendeurs
            List<Models.Utilisateur> utilisateurs = this.DbContext.Utilisateurs.Where(u => u.IsVendor).ToList();

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
            ViewBag.Id = Guid.NewGuid();
            ViewBag.forClient = true;
            ViewBag.actionForm = "ClientAded";
            return View("Inscription");
        }
        [HttpPost]
        public IActionResult ClientAded(Models.Utilisateur utilisateur)
        {
            utilisateur.IsVendor = false;

            if (ModelState.IsValid)
            {
                //mettre l'utilisateur dans la bd
                this.DbContext.Utilisateurs.Add(utilisateur);
                this.DbContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Id = Guid.NewGuid();
            ViewBag.forClient = true;
            ViewBag.actionForm = "ClientAded";
            return View("Inscription");
        }
        [HttpGet]
        public IActionResult VendorAdd()
        {
            ViewBag.Id = Guid.NewGuid();
            ViewBag.forClient = false;
            ViewBag.actionForm = "VendorAded";
            return View("Inscription");
        }
        [HttpPost]
        public IActionResult VendorAded(Models.Utilisateur utilisateur)
        {
            utilisateur.IsVendor = true;

            if (ModelState.IsValid)
            {
                //mettre l'utilisateur dans la bd
                this.DbContext.Utilisateurs.Add(utilisateur);
                this.DbContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Id = Guid.NewGuid();
            ViewBag.forClient = false;
            ViewBag.actionForm = "VendorAded";

            return View("Inscription");
        }
        [HttpGet]
        public IActionResult ClientUpdate(Models.Utilisateur tempUtilisateur)
        {
            //Trouver l'utilisateur dans la bd
            Models.Utilisateur utilisateur = this.DbContext.Utilisateurs.Find(tempUtilisateur.UtilisateurId);
            //faire les modifications
            utilisateur.Name = tempUtilisateur.Name;
            utilisateur.LastName = tempUtilisateur.LastName;
            this.DbContext.SaveChanges();
            return View("ClientModification", utilisateur);
        }
        public IActionResult VendorUpdate(Models.Utilisateur tempUtilisateur)
        {
            //Trouver l'utilisateur dans la bd
            Models.Utilisateur utilisateur = this.DbContext.Utilisateurs.Find(tempUtilisateur.UtilisateurId);
            //faire les modifications
            utilisateur.Name = tempUtilisateur.Name;
            utilisateur.LastName = tempUtilisateur.LastName;
            this.DbContext.SaveChanges();
            return View("VendorModification", utilisateur);
        }
    }
}
