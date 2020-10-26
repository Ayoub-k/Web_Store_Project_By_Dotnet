using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Web;
using System.Web;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;  

using Microsoft.Extensions.Logging;
using Finalproject.Models;
namespace Finalproject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static int  countpanier=0;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Buy1()
        {
            Client client   = new Client();
            client.nom      = Request.Form["nom"];
            client.prenom   = Request.Form["prenom"];
            client.phone    = Request.Form["nombre"];
            client.email    = Request.Form["email"];
            client.password = Request.Form["password"];
            if(client.nom=="" || client.prenom=="" || client.phone=="" || client.email=="" || client.password=="")
            {
                return View("Buy");
            }
            DAO.adduser(client);
            return View("Buy");
        }
        [HttpPost]
        public IActionResult Login()
        {   
            string email    =Request.Form["textemail"];
            string password =Request.Form["textpassword"];
            Client client=DAO.login(email,password);
            // var client1=DAO.login()
            if(client!=null)
            {
                HttpContext.Session.SetString("email_user",client.email);
                HttpContext.Session.SetString("nom_user",client.nom);
                HttpContext.Session.SetString("prenom_user",client.prenom);
                HttpContext.Session.SetString("user", JsonConvert.SerializeObject(client)); 
                var user=HttpContext.Session.Get("user");
                ViewBag.user=user;
                return RedirectToAction("Affichierlivres");
            }
            return View("Buy");
        }
        public IActionResult Affichierlivres(string nomcatalogue)
        {
            // String type1 = Request.Form["idcatalogue"];
            
            if(nomcatalogue==null)
            {
                nomcatalogue="Science";
            }
            HttpContext.Session.SetString("nomcatalog",nomcatalogue);
            var nomcataloguesession=HttpContext.Session.GetString("nomcatalog");
            if(nomcataloguesession==null)
            {
                nomcataloguesession="Science";
            }
            List<Livre> livres = new List<Livre>();
            livres = DAO.afficher(nomcataloguesession);
            ViewBag.type=nomcatalogue;
            return View(livres);
        }

        public IActionResult Buy()
        {
            return View();
        }
        public IActionResult donneeslivre(int ID)
        {

            var h= HttpContext.Session.GetString("email_user");
            HttpContext.Session.SetInt32("IDBOOK",ID);
            // HttpContext.Session.SetString("nom_user",client.nom);
            // HttpContext.Session.SetString("prenom_user",client.prenom);
            if(h!=null)
            {
                Livre livre=new Livre();
                livre=DAO.afficherlivre(ID);
                return View(livre);
            }else
            {
                return View("Buy");
            }
            
        }
        public IActionResult Privacy()
        {
            return View();
        }

         public IActionResult Logout()
        {
            HttpContext.Session.Remove("nom_user");
            HttpContext.Session.Remove("prenom_user");
            HttpContext.Session.Remove("email_user");
            HttpContext.Session.Remove("nomcatalogue");
            HttpContext.Session.Remove("IDBOOK");
            
            return RedirectToAction("Index");
        }

        public IActionResult AjoutAupanier()
        {
            // countpanier++;
            Livre livre=new Livre();
            
            string email=HttpContext.Session.GetString("email_user");
            int Id=(int)HttpContext.Session.GetInt32("IDBOOK");
            livre=DAO.afficherlivre(Id);
            // Panier panier = new Panier();

            DAO.addCommande(email,livre.Nom);
            
            // panier.email=HttpContext.Session.GetString("email_user");
            // HttpContext.Session.SetInt32("CountPanier",countpanier);

            // panier.Ajouter(livre);
            return RedirectToAction("Affichierlivres");
        }

        public IActionResult supprimerlignecommande(int ID)
        {
            DAO.supprimerlignecommande(ID);
            return RedirectToAction("Panier");
        }
        public IActionResult Panier()
        {
            List<Commande> commandes=new List<Commande>();
            commandes=DAO.affichercommande();
            int prix=0;
            for(int i=0;i<commandes.Count;i++)
            {
                prix=prix+154;
            }

            ViewBag.prixt=prix;
            ViewBag.commandes=commandes;
            return View(commandes);
        }

        public IActionResult supprimertablecommande()
        {
            DAO.Supprimertablecommande();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}