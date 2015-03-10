using HomeShare.DAL;
using HomeShareMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeShareMVC.Controllers
{
    public class BienController : Controller
    {
        //
        // GET: /Bien/
        public ActionResult Index()
        {
            List<BienEchange> lesBiens = BienEchange.getAllBienEchange();
            return View(lesBiens);
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            PaysBienMembre pbm = new PaysBienMembre()
            {
                UnBien = BienEchange.getUnBienEchange(id),
                UnMembre = Membre.getUnMembreParBien(id),
                UnPays = Pays.getUnPaysParBien(id)

            };
         
            return View(pbm);
        }

        //[HttpPost]
        //public ActionResult InsererAvis(string txtAvis, int noteAvis)
        //{

        //}
	}
}