using System.Web;
using System.Web.Optimization;

namespace Expenses
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            //bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
            //          "~/Scripts/angular.js",
            //          "~/Scripts/expenses.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css",
                      "~/Content/bootstrap.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
