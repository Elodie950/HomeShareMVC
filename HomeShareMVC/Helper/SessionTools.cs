using HomeShare.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeShareMVC.Helper
{
    public class SessionTools
    {
          public static string Login
        {
            get
            {
                try
                {
                    return HttpContext.Current.Session["Login"].ToString();
                }
                catch
                {
                    return null;
                }
            }
            set { HttpContext.Current.Session["Login"] = value; }
        }

        public static Membre Membre
        {
            get
            {
                if (HttpContext.Current.Session["Membre"] == null)
                {
                    HttpContext.Current.Session["Membre"] = new Membre();
                }
                return (Membre)HttpContext.Current.Session["Membre"];
            }
            set
            {
                HttpContext.Current.Session["Membre"] = value;
            }
        }
    }
}
