using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clockwork.Web.Helpers
{
    public static class AssemblyInfo
    {
        public static MvcHtmlString GetAssemblyVersion(this HtmlHelper helper)
        {
            var mvcName = typeof(Controller).Assembly.GetName();
            var version = mvcName.Version.Major + "." + mvcName.Version.Minor;
            return MvcHtmlString.Create(version);
        }

        public static MvcHtmlString GetTypeMono(this HtmlHelper helper)
        {
            var isMono = Type.GetType("Mono.Runtime") != null;
            var runtime = isMono ? "Mono" : ".NET";
            return MvcHtmlString.Create(runtime);
        }
    }
}