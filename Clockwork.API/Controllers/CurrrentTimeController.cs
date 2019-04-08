using System;
using Microsoft.AspNetCore.Mvc;
using Clockwork.API.Models;
using System.Linq;

namespace Clockwork.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CurrentTimeController : Controller
    {
        private ClockworkContext db = new ClockworkContext();
        private DateTime utcTime = DateTime.UtcNow;
        private DateTime serverTime = DateTime.Now;

        // GET api/currenttime
        [HttpGet]
        public IActionResult Get(string id)
        {
            try
            {
                //var utcTime = DateTime.UtcNow;
                //var serverTime = DateTime.Now;
                var ip = this.HttpContext.Connection.RemoteIpAddress.ToString();
                var requestedServerTime = TimeZoneInfo.ConvertTime(serverTime, TimeZoneInfo.FindSystemTimeZoneById(id));

                var returnVal = new CurrentTimeQuery
                {
                    UTCTime = utcTime,
                    ClientIp = ip,
                    Time = requestedServerTime
                };

                using (var db = new ClockworkContext())
                {
                    db.CurrentTimeQueries.Add(returnVal);
                    var count = db.SaveChanges();
                    //Console.WriteLine("{0} records saved to database", count);

                    //Console.WriteLine();
                    //foreach (var CurrentTimeQuery in db.CurrentTimeQueries)
                    //{
                    //    Console.WriteLine(" - {0}", CurrentTimeQuery.UTCTime);
                    //}
                }

                return Ok(returnVal);
            } 
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        [HttpGet]
        public IQueryable<CurrentTimeQuery> GetList()
        {
            var data = db.CurrentTimeQueries;
            return data;
        }
    }
}
