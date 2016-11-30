using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace ERP
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            bundles.Add(new ScriptBundle("~/scripts").Include("~/scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/scripts").Include("~/scripts/bootstrap.js", "~/scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/Content").Include("~/Content/bootstrap.css",
                "~/Content/bootstrap-theme.css", 
                "~/Content/custom.css"));
        }
    }
}