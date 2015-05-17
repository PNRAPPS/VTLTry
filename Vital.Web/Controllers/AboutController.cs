using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vital.Web.Controllers
{
    public class AboutController : Controller
    {
        //
        // GET: /About/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VitalDifference()
        {
            return View();
        }

        public ActionResult VitalNetwork()
        {
            return View();
        }

        public ActionResult UPSPartnership()
        {
            return View();
        }
    }
}
