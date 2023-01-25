using System.Web;
using System.Web.Optimization;

namespace MVC_Vaja1_25._01._2023
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            //dodano
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            "~/Scripts/cldr.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            "~/Scripts/globalize.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            "~/Scripts/globalize/date.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            "~/Scripts/globalize/number.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            "~/Scripts/jquery.validate.globalize.js"));
            //Konec dodano

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
