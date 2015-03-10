using System.Web;
using System.Web.Optimization;

namespace HomeShareMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/css/bootstrap/css/bootstrap.css", "~/Content/css/owl-carousel/owl.carousel.css", "~/Content/css/owl-carousel/owl.theme.css",
                "~/Content/css/style.css", "~/Content/css/slitslider/css/style.css", "~/Content/css/slitslider/css/custom.css"));

            bundles.Add(new ScriptBundle("~/Scripts/Jquery").Include("~/Scripts/slitslider/js/jquery.ba-cond.min.js", "~/Scripts/slitslider/js/jquery.slitslider.js"));

            bundles.Add(new ScriptBundle("~/Scripts/bootstrap").Include("~/Scripts/bootstrap/js/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Custom").Include("~/Scripts/script.js", "~/Scripts/owl-carousel/owl.carousel.js", "~/Scripts/slitslider/js/modernizr.custom.79639.js"));
  
        }
   
    }
}
