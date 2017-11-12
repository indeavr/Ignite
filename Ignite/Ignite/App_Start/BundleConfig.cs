using System.Web;
using System.Web.Optimization;

namespace Ignite
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

            bundles.Add(new ScriptBundle("~/bundles/ajax").Include(
                        "~/Scripts/jquery.unobtrusive-ajax.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            bundles.Add(new StyleBundle("~/Content/homePage").Include(
                      "~/Content/homePage.css"));

            bundles.Add(new StyleBundle("~/Content/uploadCourse").Include(
                    "~/Content/uploadCourse.css"));

            bundles.Add(new StyleBundle("~/Content/imageUpload").Include(
                    "~/Content/imageUpload.css"));

            bundles.Add(new ScriptBundle("~/bundles/uploadCourse").Include(
                     "~/Scripts/uploadCourse.js"));

            bundles.Add(new ScriptBundle("~/bundles/dropzonescripts").Include(
                     "~/Scripts/dropzone/dropzone-amd-module.js",
                     "~/Scripts/dropzone/dropzone.js"));

            bundles.Add(new StyleBundle("~/Content/dropzonescss").Include(
                     "~/Scripts/dropzone/basic.css",
                     "~/Scripts/dropzone/dropzone.css"));

            bundles.Add(new StyleBundle("~/Content/jquery-ui.css").Include(
               "~/Content/themes/base/jquery-ui.css"));

            bundles.Add(new StyleBundle("~/Content/jqgrid.css").Include(
                "~/Content/jquery.jqGrid/ui.jqgrid.css"));

            bundles.Add(new ScriptBundle("~/bundles/jqGrid").Include(
                "~/Scripts/i18n/grid.locale-en.js",
                "~/Scripts/jquery.jqGrid.js",
                "~/Scripts/jquery-ui-{version}.js",
                "~/Scripts/JqGridTables.js"));

            bundles.Add(new StyleBundle("~/Content/statistics.css").Include(
              "~/Content/statistics.css"));

            bundles.Add(new StyleBundle("~/Content/slider.css").Include(
             "~/Content/slider/hover.css",
             "~/Content/slider/home-page.css",
             "~/Content/slider/slick-theme.css",
             "~/Content/slider/slick.css"));

            bundles.Add(new ScriptBundle("~/bundles/VisualSettings").Include(
                     "~/Scripts/slider/slick.min.js",
                     "~/Scripts/VisualSettings.js"));

            bundles.Add(new ScriptBundle("~/bundles/quizTest.js").Include(
             "~/Scripts/quizTest.js"));
        }
    }
}
