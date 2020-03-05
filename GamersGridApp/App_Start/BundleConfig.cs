using System.Web;
using System.Web.Optimization;

namespace GamersGridApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/mainLib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                        //"~/Scripts/datatables/jquery.datatables.js",
                        //"~/Scripts/datatables/datatables.bootstrap.js",
                        "~/Scripts/datatables.js",
                        "~/Scripts/typeahead.bundle.js",
<<<<<<< Updated upstream
                        "~/Scripts/typeahead.jquery.js",
                        "~/Scripts/bootstrap.js"
                        //"~/Scripts/popper.js"

=======
                        "~/Scripts/typeahead.jquery.js"
>>>>>>> Stashed changes
                        ));

            bundles.Add(new ScriptBundle("~/bundles/popper").Include(
                        "~/Scripts/umd/popper.js"

                        ));

            bundles.Add(new ScriptBundle("~/bundles/TypeAheadSearchBar").Include(
                        "~/Scripts/Custom/TypeAheadSearchBar.js"));


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/IndexCss").Include(
                "~/Content/fontawesome-all.css",
                 "~/Content/IndexStyle.css"));





            bundles.Add(new StyleBundle("~/Content/SiteCss").Include(
                 "~/Content/Site.css"));
            bundles.Add(new StyleBundle("~/Content/css").Include(

                      "~/Content/bootstrapFlatly.css",
<<<<<<< Updated upstream
                      "~/Content/typeahead.css"));
=======
                      "~/Content/typeahead.css",
                      "~/Content/DataTables/css/dataTables.css",
                      //"~/Content/DataTables/css/dataTables.bootstrap.css",
                      "~/Content/site.css"));
>>>>>>> Stashed changes
        }
    }
}
