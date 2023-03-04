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

        [HttpPost]
        public IActionResult Connexion(Models.Utilisateur utilisateur)
        {
            if (this.DbContext.Utilisateurs.Any(o=>o.UtilisateurId == utilisateur.UtilisateurId))
            {
                //chercher l'utilisateur dans la bd
                Models.Utilisateur user = this.DbContext.Utilisateurs.Find(utilisateur.UtilisateurId);
                return RedirectToAction("Index", "Home", user);
            }
            return RedirectToAction("ClientConnexion", "Compte");

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
            Models.Utilisateur connexionUtilisateur = new Models.Utilisateur();

            //Chercher la liste des vendeurs
            List<Models.Utilisateur> utilisateurs = this.DbContext.Utilisateurs.Where(u => u.IsVendor).ToList();
            
            ViewBag.UserType = "Vendeur";
            ViewBag.Switch = "ClientConnexion";
            ViewBag.Add = "VendorAdd";
            ViewBag.ButtonText = "client";
            ViewBag.Data = utilisateurs;


            return View("Connexion", utilisateurs);
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
                return RedirectToAction("Index", "Home", utilisateur);
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
                return RedirectToAction("Index", "Home", utilisateur);
            }
            ViewBag.Id = Guid.NewGuid();
            ViewBag.forClient = false;
            ViewBag.actionForm = "VendorAded";

            return View("Inscription");
        }
        [HttpPost]
        public IActionResult Update(Guid UtilisateurId)
        {
            //Trouver l'utilisateur dans la bd
            Models.Utilisateur utilisateur = this.DbContext.Utilisateurs.Find(UtilisateurId);
            return View("Modification", utilisateur);
        }
        [HttpPost]
        public IActionResult Updated(Models.Utilisateur tempUtilisateur)
        {
            if (ModelState.IsValid)
            {
                //Trouver l'utilisateur dans la bd
                Models.Utilisateur utilisateur = this.DbContext.Utilisateurs.Find(tempUtilisateur.UtilisateurId);
                //faire les modifications
                utilisateur.Name = tempUtilisateur.Name;
                utilisateur.LastName = tempUtilisateur.LastName;
                this.DbContext.SaveChanges();
                return View("Modification", utilisateur);
            }
            return View("Modification", tempUtilisateur);
        }
    }
}
