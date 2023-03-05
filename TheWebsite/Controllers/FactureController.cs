using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheWebsite.Models;

namespace TheWebsite.Controllers
{
    public class FactureController : Controller
    {
        public TheWebsiteContext DbContext { get; set; }
        public FactureController()
        {
            this.DbContext = new TheWebsiteContext();
        }

        [HttpGet]
        public IActionResult Facture(Guid utilisateurId)
        {
            Utilisateur utilisateur = this.DbContext.Utilisateurs.Find(utilisateurId);

            return View(utilisateur);
        }
    }
}
