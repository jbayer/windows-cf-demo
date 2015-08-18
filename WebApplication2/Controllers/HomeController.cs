using System;
using System.Diagnostics;
using System.Web.Mvc;
using System.Threading;

namespace WebApplication2.Controllers
{
    public class ExitHelper
    {
        public void exitAfterDelay()
        {
            //call exit after 500ms
            Timer timer = new System.Threading.Timer(obj => { exit(); }, null, 500, System.Threading.Timeout.Infinite);
        }

        public void exit()
        {
            Process.GetCurrentProcess().Kill();
        }
    }

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

        public ActionResult env()
        {
            ViewBag.Message = "Your application description page!";

            return View();
        }

        public ActionResult exit()
        {
            ViewBag.Index = Environment.GetEnvironmentVariable("INSTANCE_INDEX");
            if (ViewBag.Index == null)
                ViewBag.Index = "-";

            //new ExitHelper().exitAfterDelay();
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