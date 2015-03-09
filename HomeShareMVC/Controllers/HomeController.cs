﻿using HomeShare.DAL;
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
            List<BienEchange> mesBien = BienEchange.getAllBienEchange();
            return View(mesBien);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}