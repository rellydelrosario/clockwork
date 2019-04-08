using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clockwork.Web.Helpers
{
    public class Skins
    {
        public const string BundleBase = "~/Content/themes/";

        public class Theme
        {
            public const string Bare = "Bare";
            public const string Cerulean = "Cerulean";
            public const string Cosmo = "Cosmo";
            public const string Flatly = "Flatly";
            public const string Journal = "Journal";
            public const string Lumen = "Lumen";
            public const string Paper = "Paper";
            public const string Readable = "Readable";
            public const string Sandstone = "Sandstone";
            public const string Simplex = "Simplex";
            public const string Spacelab = "Spacelab";
            public const string United = "United";
            public const string Yeti = "Yeti";
        }

        public static HashSet<string> Themes = new HashSet<string>
        {
            Theme.Bare,
            Theme.Cerulean,
            Theme.Cosmo,
            Theme.Flatly,
            Theme.Journal,
            Theme.Lumen,
            Theme.Paper,
            Theme.Readable,
            Theme.Sandstone,
            Theme.Simplex,
            Theme.Spacelab,
            Theme.United,
            Theme.Yeti,
        };

        public static string Bundle(string themename)
        {
            return BundleBase + themename;
        }
    }
}