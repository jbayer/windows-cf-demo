using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Index = Environment.GetEnvironmentVariable("INSTANCE_INDEX");
            if (ViewBag.Index == null)
                ViewBag.Index = "-";

            ViewBag.Uptime = UpTime().ToString();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page!";

            return View();
        }

        public TimeSpan UpTime()
        {
                using (var uptime = new PerformanceCounter("System", "System Up Time"))
                {
                    uptime.NextValue();       //Call this an extra time before reading its value
                    return TimeSpan.FromSeconds(uptime.NextValue());
                }
        }
    }
}