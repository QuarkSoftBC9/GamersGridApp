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

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                        "~/Scripts/app/services/followsService.js",
                        "~/Scripts/app/services/messagesService.js",
                        "~/Scripts/app/controllers/followsController.js"
                        
                ));
            bundles.Add(new ScriptBundle("~/bundles/searchEngine").Include(
                    "~/Scripts/app/services/lolSearchService.js",
                        "~/Scripts/app/userInterface/lolSearchUI.js",
                        "~/Scripts/app/controllers/lolSearchController.js"
                ));


            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.4.1.js",
                        "~/Scripts/jquery.signalR-2.4.1.js",
                        "~/Scripts/jquery-{version}.js",
                         "~/Scripts/Datatables/jquery.dataTables.js"
                        ));



            bundles.Add(new ScriptBundle("~/bundles/typeahead").Include(
                        "~/Scripts/typeahead.bundle.js",
                        "~/Scripts/typeahead.jquery.js",
                        "~/Scripts/Custom/TypeAheadSearchBar.js"
                ));



            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                         "~/Scripts/umd/popper.js",
                         "~/Scripts/bootstrap.js"
                 ));


            bundles.Add(new ScriptBundle("~/bundles/loginnew").Include(
                         "~/Scripts/NewLogin/login.js"
                 ));
            bundles.Add(new ScriptBundle("~/bundles/Message").Include(
                          "~/Scripts/Message/Message.js"
                 ));        
            bundles.Add(new ScriptBundle("~/bundles/underscore").Include(
                        "~/Scripts/underscore.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/gameProfile").Include(
                            "~/Scripts/GameProfile.js"
            ));



            bundles.Add(new ScriptBundle("~/bundles/RegisterJs").Include(
                        //"~/Scripts/RegisterJs/jquery.min.js",
                        //"~/Scripts/bootstrap.js",
                        "~/Scripts/RegisterJs/popper.min.js",
                        "~/Scripts/RegisterJs/jquery.bootstrap.wizard.js",
                        "~/Scripts/RegisterJs/gsdk-bootstrap-wizard.js",
                        "~/Scripts/typeahead.bundle.js",
                        "~/Scripts/typeahead.jquery.js",
                        "~/Scripts/Custom/TypeAheadSearchBar.js",
                        "~/Scripts/RegisterJs/Custom.js",
                       "~/Scripts/toastr.js"

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

            bundles.Add(new StyleBundle("~/Content/SearchEngine").Include(
                "~/Content/SearchEngine/search.css"));

            bundles.Add(new StyleBundle("~/Content/GameProfile").Include(
                 "~/Content/GameProfile.css"));

            bundles.Add(new StyleBundle("~/Content/LeaderBoard").Include(
                 "~/Content/LeaderBoard.css"));

            bundles.Add(new StyleBundle("~/Content/Message").Include(
                 "~/Content/MessageCss/Message.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                       //"~/Content/bootstrapFlatly.css",
                       "~/Content/bootstrap.css",
                      "~/Content/DataTables/css/dataTables.bootstrap4.css",
                      "~/Content/typeahead.css",
                        "~/Content/animate.min.css",
                        "~/Content/fontawesome-all.css",
                        "~/Content/toastr.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/NewRegisterCss").Include(
                //"~/Content/NewRegisterCss/bootstrap.min.css",
            "~/Content/NewRegisterCss/demo.css",
            "~/Content/NewRegisterCss/gsdk-bootstrap-wizard.css",
             "~/Content/typeahead.css"));

            //bundles.Add(new StyleBundle("~/Content/RegisterCss").Include(
            //    "~/Content/bootstrapFlatly.css",
            // "~/Content/RegisterCss/avraam2NotAll.css",
            // "~/Content/RegisterCss/gsdk-bootstrap-wizardAllagi.css",
            // "~/Content/RegisterCss/PROFILE_GG.css",
            //  "~/Content/typeahead.css"));

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

            bundles.Add(new StyleBundle("~/Content/newLogin").Include(
                "~/Content/NewLoginCss/login.css"));
            //Edit
            bundles.Add(new StyleBundle("~/Content/Edit").Include(
             "~/Content/Site.css"));


        }
    }
}
