using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeShareMVC.Areas.Membre.Controllers
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
             
        }
	}
}