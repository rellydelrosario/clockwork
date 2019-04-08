using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using Clockwork.Web.Helpers;

namespace Clockwork.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            foreach (var theme in Skins.Themes)
            {
                var stylePath = string.Format("~/Content/themes/{0}/bootstrap.css", theme);

                bundles.Add(new StyleBundle(Skins.Bundle(theme)).Include(
                                        "~/Content/css/reset.css",
                                        "~/Content/css/bootstrap.css",
                                        stylePath,
                                        "~/Content/css/site.css"));
            }

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/clockwork.js"));
        }
    }
}