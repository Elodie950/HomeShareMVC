using System.Web;
using System.Web.Optimization;

namespace HomeShareMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/css/bootstrap/bootstrap.css", "~/Content/css/owl-carousel/owl.carousel.css", "~/Content/css/owl-carousel/owl.theme.css",
                "~/Content/css/styles.css", "~/Content/css/slitslider/style.css", "~/Content/css/slitslider/custom.css"));

            bundles.Add(new ScriptBundle("~/Scripts/Jquery").Include("~/Scripts/slitslider/jquery.ba-cond.min.js", "~/Scripts/slitslider/jquery.slitslider.js", "~/Scripts/jquery-1.9.1.min.js"));

            bundles.Add(new ScriptBundle("~/Scripts/bootstrap").Include("~/Scripts/bootstrap/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Custom").Include("~/Scripts/script.js", "~/Scripts/owl-carousel/owl.carousel.js", "~/Scripts/slitslider/modernizr.custom.79639.js"));
  
        }
   
    }
}
