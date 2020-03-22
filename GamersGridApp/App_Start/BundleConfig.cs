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
                        "~/Scripts/jquery.signalR-2.4.1.js",
                         "~/Scripts/jquery.signalR-2.4.1.min.js",
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                         "~/Scripts/Datatables/jquery.dataTables.js",
                        "~/Scripts/typeahead.bundle.js",
                        "~/Scripts/typeahead.jquery.js"
                        //"~/Scripts/popper.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/popper").Include(
                        "~/Scripts/umd/popper.js"

                        ));
            bundles.Add(new ScriptBundle("~/bundles/RegisterJs").Include(
                        "~/Scripts/RegisterJs/gsdk-bootstrap-wizard.js",
                        "~/Scripts/RegisterJs/jquery.bootstrap.wizard.js",
                        "~/Scripts/RegisterJs/jquery.validate.min.js",
                        "~/Scripts/typeahead.bundle.js",
                        "~/Scripts/typeahead.jquery.js",
                        "~/Scripts/Custom/TypeAheadSearchBar.js"
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
                      "~/Content/DataTables/css/dataTables.bootstrap4.css",
                      "~/Content/typeahead.css"));

            bundles.Add(new StyleBundle("~/Content/RegisterCss").Include(
                "~/Content/bootstrapFlatly.css",
             "~/Content/RegisterCss/avraam2NotAll.css",
             "~/Content/RegisterCss/gsdk-bootstrap-wizardAllagi.css",
             "~/Content/RegisterCss/PROFILE_GG.css",
              "~/Content/typeahead.css"));

            //Search results css file
            bundles.Add(new StyleBundle("~/Content/SearchCss").Include(
                "~/Content/SearchResults/SearchResultStyle.css"
                ));
            //User edit css file
            bundles.Add(new StyleBundle("~/Content/UserEditCss").Include(
                "~/Content/UserEditCss/style.css"));

            //Toastr css
            bundles.Add(new StyleBundle("~/Content/toastrcss").Include(
                "~/Content/toastr.css"));

            bundles.Add(new ScriptBundle("~/Scripts/toastrjs")
                .Include("~/Scripts/toastr.js"));
        }
    }
}
