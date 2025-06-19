using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace EduConnect.Web
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			// Bundle style
			bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include(
				"~/Content/bootstrap.min.css", new CssRewriteUrlTransform()));
               bundles.Add(new StyleBundle("~/bundles/loader/css").Include(
                    "~/Content/loader.css", new CssRewriteUrlTransform()));

               // Font Awesome icons style
               bundles.Add(new StyleBundle("~/bundles/font-awesome/css").Include(
				"~/Content/font-awesome.min.css", new CssRewriteUrlTransform()));

			bundles.Add(new StyleBundle("~/bundles/materialdesignicons/css").Include(
				"~/Content/materialdesignicons.min.css", new CssRewriteUrlTransform()));

               bundles.Add(new StyleBundle("~/bundles/peicon7stroke/css").Include(
                    "~/Content/pe-icon-7-stroke.css", new CssRewriteUrlTransform()));

               bundles.Add(new StyleBundle("~/bundles/style/css").Include(
                    "~/Content/style.css", new CssRewriteUrlTransform()));





               // Boostrap
               bundles.Add(new ScriptBundle("~/bundles/scrollspy/js").Include(
                    "~/Scripts/bootstrap.bundle.min.js"));

               bundles.Add(new ScriptBundle("~/bundles/loader/js").Include(
                    "~/Scripts/loader.js"));

               bundles.Add(new ScriptBundle("~/bundles/jquery/js").Include(
                    "~/Scripts/jquery.min.js", "~/Scripts/jquery.easing.min.js"));

               bundles.Add(new ScriptBundle("~/bundles/scrollspy/js").Include(
                    "~/Scripts/scrollspy.min.js"));

               bundles.Add(new ScriptBundle("~/bundles/counter/js").Include(
                    "~/Scripts/counter.init.js"));

               bundles.Add(new ScriptBundle("~/bundles/app/js").Include(
                    "~/Scripts/app.js"));
          }
	}
}