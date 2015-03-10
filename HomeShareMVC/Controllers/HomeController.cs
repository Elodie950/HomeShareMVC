using HomeShare.DAL;
using HomeShareMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeShareMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            MesListesBiens meslistes = new MesListesBiens()
            {
                MeilleursBiens = BienEchange.getBestBien(),
                DerniersBiens = BienEchange.getLastBien(),
            };

            return View(meslistes);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        
    }
}