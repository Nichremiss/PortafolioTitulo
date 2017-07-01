using System.Web;
using System.Web.Optimization;

namespace CentroMedico.Mvc
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                 "~/Scripts/jquery-{version}.js"));

            bundles.Add(new StyleBundle("~/bundles/Cssassets").Include(
                        "~/Scripts/assets/css/custom.css",
                        "~/Scripts/assets/css/neon-forms.css",
                        "~/Scripts/assets/css/neon-theme.css",
                        "~/Scripts/assets/css/neon-core.css",
                        "~/Scripts/assets/css/bootstrap.css",
                        "~/Scripts/assets/css/font-icons/entypo/css/entypo.css",
                        "~/Scripts/assets/js/jquery-ui/css/no-theme/jquery-ui-1.10.3.custom.min.css"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                       "~/Scripts/jquery.validate*"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/site.css",
                        "~/Content/bootstrap.css",
                        "~/Content/bootstrap.min.css",
                        "~/Content/bootstrap.min.css"
                        ));


            bundles.Add(new ScriptBundle("~/bundles/assets").Include(
                        "~/Scripts/assets/js/neon-custom.js",
                        "~/Scripts/assets/js/neon-chat.js",
                        "~/Scripts/assets/js/resizeable.js",
                        "~/Scripts/assets/js/joinable.js",
                        "~/Scripts/assets/js/bootstrap.js",
                        "~/Scripts/assets/js/jquery-ui/js/jquery-ui-1.10.3.minimal.min.js",
                        "~/Scripts/assets/js/gsap/main-gsap.js",
                        "~/Scripts/assets/js/bootstrap.js",
                        "~/Scripts/assets/js/neon-demo.js",
                        "~/Scripts/assets/js/jquery-ui/js/jquery-ui-1.10.3.minimal.min.js" ,
                        "~/Scripts/assets/js/neon-api.js" ,
                        "~/Scripts/assets/js/bootstrap-datepicker.js",
                         "~/Scripts/assets/js/daterangepicker/daterangepicker-bs3.css",
                         "~/Scripts/assets/js/bootstrap-datepicker.js",
                         "~/Scripts/assets/js/bootstrap-timepicker.min.js",
                         "~/Scripts/assets/js/bootstrap-colorpicker.min.js",
                         "~/Scripts/assets/js/daterangepicker/moment.min.js",
                         "~/Scripts/assets/js/daterangepicker/daterangepicker.js",
                         "~/Scripts/assets/js/toastr.js",
                         "~/Scripts/assets/js/neon-chat.js",
                        "~/Scripts/assets/js/toastr.js" ,
                         "~/Scripts/assets/js/neon-chat.js",
                     
"~/Scripts/assets/js/datatables/responsive/css/datatables.responsive.css" ,
"~/Scripts/assets/js/select2/select2-bootstrap.css" ,
"~/Scripts/assets/js/select2/select2.css" ,


"~/Scripts/assets/js/gsap/main-gsap.js" ,
"~/Scripts/assets/js/jquery-ui/js/jquery-ui-1.10.3.minimal.min.js",
 "~/Scripts/assets/js/bootstrap.js" ,
 "~/Scripts/assets/js/joinable.js" ,
 "~/Scripts/assets/js/resizeable.js" ,
 "~/Scripts/assets/js/neon-api.js",
 "~/Scripts/assets/js/jquery.dataTables.min.js",
"~/Scripts/assets/js/datatables/TableTools.min.js",
"~/Scripts/assets/js/dataTables.bootstrap.js" ,
 "~/Scripts/assets/js/datatables/jquery.dataTables.columnFilter.js" ,
"~/Scripts/assets/js/datatables/lodash.min.js" ,
"~/Scripts/assets/js/datatables/responsive/js/datatables.responsive.js" ,
 "~/Scripts/assets/js/select2/select2.min.js",
"~/Scripts/assets/js/neon-chat.js",

"~/Scripts/assets/js/gsap/main-gsap.js" ,
 "~/Scripts/assets/js/jquery-ui/js/jquery-ui-1.10.3.minimal.min.js" ,
"~/Scripts/assets/js/bootstrap.js",
"~/Scripts/assets/js/joinable.js" ,
"~/Scripts/assets/js/resizeable.js",
"~/Scripts/assets/js/neon-api.js"
                         ));


            bundles.Add(new StyleBundle("~/bundles/CssjQWidget").Include(
                        "~/Scripts/jQWidget/styles/jqx.base.css",
                        "~/Scripts/jQWidget/styles/jqx.ui-start.css"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jQWidget").Include(
                        "~/Scripts/jQWidget/jquery-1.11.2.js",
                        "~/Scripts/jQWidget/jqxcore.js",
                        "~/Scripts/jQWidget/jqxdata.js",
                        "~/Scripts/jQWidget/jqxbuttons.js",
                        "~/Scripts/jQWidget/jqxscrollbar.js",
                        "~/Scripts/jQWidget/jqxmenu.js",
                        "~/Scripts/jQWidget/jqxlistbox.js",
                        "~/Scripts/jQWidget/jqxdropdownlist.js",
                        "~/Scripts/jQWidget/jqxgrid.js",
                        "~/Scripts/jQWidget/jqxgrid.selection.js",
                        "~/Scripts/jQWidget/jqxgrid.columnsresize.js",
                        "~/Scripts/jQWidget/jqxgrid.filter.js",
                        "~/Scripts/jQWidget/jqxgrid.sort.js",
                        "~/Scripts/jQWidget/jqxgrid.pager.js",
                        "~/Scripts/jQWidget/jqxgrid.grouping.js",
                        "~/Scripts/jQWidget/globalization/globalize.js",
                        "~/Scripts/jQWidget/globalization/localization.js",
                        "~/Scripts/jQWidget/jqxcore.js",
                        "~/Scripts/jQWidget/jqxdata.js",
                        "~/Scripts/jQWidget/jqxbuttons.js",
                        "~/Scripts/jQWidget/jqxscrollbar.js",
                        "~/Scripts/jQWidget/jqxcombobox.js",
                        "~/Scripts/jQWidget/jqxlistbox.js",
                        "~/Scripts/jQWidget/jqxdatatable.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootstrap.min.js"
                       ));





        }
    }
}
