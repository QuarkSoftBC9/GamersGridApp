using System.Web;
using System.Web.Optimization;

namespace GamersGridApp
{
    public class BundleConfig
    {
        //Test Comment on FrontEnd Branch
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.signalR-2.4.1.js",
                         "~/Scripts/jquery.signalR-2.4.1.min.js",
                        "~/Scripts/jquery-{version}.js",
                         "~/Scripts/Datatables/jquery.dataTables.js"
                        ));



            bundles.Add(new ScriptBundle("~/bundles/typeahead").Include(
                        "~/Scripts/typeahead.bundle.js",
                        "~/Scripts/typeahead.jquery.js",
                        "~/Scripts/Custom/TypeAheadSearchBar.js"
                ));

            

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                         "~/Scripts//umd/popper.js",
                         "~/Scripts/bootstrap.js"
                 ));

            bundles.Add(new ScriptBundle("~/bundles/underscore").Include(
                        "~/Scripts/underscore.js"
                        ));


            bundles.Add(new ScriptBundle("~/bundles/RegisterJs").Include(
                        "~/Scripts/RegisterJs/jquery.min.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/RegisterJs/popper.min.js",
                        "~/Scripts/RegisterJs/jquery.bootstrap.wizard.js",
                        "~/Scripts/RegisterJs/gsdk-bootstrap-wizard.js",
                        "~/Scripts/typeahead.bundle.js",
                        "~/Scripts/typeahead.jquery.js",
                        "~/Scripts/Custom/TypeAheadSearchBar.js",
                        "~/Scripts/RegisterJs/Custom.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/TypeAheadSearchBar").Include(
                        "~/Scripts/Custom/TypeAheadSearchBar.js"));


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //bundles.Add(new StyleBundle("~/Content/IndexCss").Include(
            //    //"~/Content/fontawesome-all.css",
            //     "~/Content/IndexStyle.css"));

            bundles.Add(new StyleBundle("~/Content/SiteCss").Include(
                 "~/Content/Site.css"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                       //"~/Content/bootstrapFlatly.css",
                       "~/Content/bootstrap.css",
                      "~/Content/DataTables/css/dataTables.bootstrap4.css",
                      "~/Content/typeahead.css",
                        "~/Content/animate.min.css",
                        "~/Content/fontawesome-all.css"
                      ));

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
            //Login Form 
            bundles.Add(new StyleBundle("~/Content/LoginForm").Include(
                "~/Content/loginStyle.css"));
            //Edit
            bundles.Add(new StyleBundle("~/Content/Edit").Include(
             "~/Content/Site.css"));


        }
    }
}
