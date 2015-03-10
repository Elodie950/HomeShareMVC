using HomeShare.DAL;
using HomeShareMVC.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeShareMVC.Areas.Membres.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Membre/Login/
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SeConnecter(string txtlogin, string txtpass)
        {
            
            if (SessionTools.Login == null)
            {
                Membre m = Membre.AuthentifieMoi(txtlogin, txtpass);
                if (m == null)
                {
                    ViewBag.error = "Ce login et/ou ce password est incorrect!";
                    return View("Index");
                }
                else
                {
                    SessionTools.Login = txtlogin;
                    SessionTools.Membre = m;
                }
            }
            return RedirectToRoute(new { controller = "Home", action = "Index", area = "" });
        }

        public ActionResult Logoff()
        {
            SessionTools.Login = null;
            Session.Abandon();
            return RedirectToRoute(new { controller = "Home", action = "Index", area = "" });
        }

        public ActionResult Inscription()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EnrInscr(string txtnom, string txtprenom, string txtemail, int txtPays, string txttel, string txtlogin, string txtpass, string txtpass1)
        {
            if (txtnom != "" && txtprenom != "" && txtemail != "" && txttel != "" && txtlogin !="" && txtpass!="" && txtpass == txtpass1)
            {
                Membre m = new Membre();
                m.InsererMembre(txtnom, txtprenom, txtemail, txtPays, txttel, txtlogin, txtpass);

                return RedirectToRoute(new { controller = "Login", action = "Index", area = "Membres" });

            }
            else if (txtnom != "" && txtprenom != "" && txtemail != "" && txttel != "" && txtlogin != "" && txtpass != "" && txtpass != txtpass1)
            {
                ViewBag.Erreur = "Le password n'est pas correct! Vous devez remplir tous les champs!";
                return View("Inscription");
            }
            else {
                ViewBag.Erreur = "Vous n'avez pas rempli tous les champ";
                return View("Inscription");
            }
 
        }
	}
}