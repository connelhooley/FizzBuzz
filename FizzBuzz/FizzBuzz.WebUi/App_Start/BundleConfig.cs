using System.Web.Optimization;
using FizzBuzz.WebUi.Extensions;

namespace FizzBuzz.WebUi
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(
                new ScriptBundle("~/bundles/jquery")
                    .Include("~/Scripts/jquery-{version}.js")
                    .WithLastModifiedToken());

            bundles.Add(
                new ScriptBundle("~/bundles/jqueryval")
                    .Include("~/Scripts/jquery.validate*")
                    .WithLastModifiedToken());

            bundles.Add(
                new StyleBundle("~/Content/css")
                    .Include("~/Content/site.css")
                    .WithLastModifiedToken());
        }
    }
}