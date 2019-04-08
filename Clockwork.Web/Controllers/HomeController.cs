using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace Clockwork.Web.Controllers
{
    public class HomeController : Controller
    {
        private TimeZoneInfo localTimeZone = TimeZoneInfo.Local;
        public ActionResult Index()
        {
            ViewData["LocalTimeZone"] = localTimeZone.Id;
            return View("Index");
        }

        public ActionResult TimeZone()
        {
            List<string> tz = new List<string>();            
            foreach (TimeZoneInfo timeZoneInfo in TimeZoneInfo.GetSystemTimeZones())
            {
                tz.Add(timeZoneInfo.Id);
            }
            SelectList timeZone = new SelectList(tz);            
            ViewData["TimeZone"] = timeZone;
            return PartialView("TimeZone");
        }
    }
}
