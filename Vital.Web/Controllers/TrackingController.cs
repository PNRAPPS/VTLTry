using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vital.Web.Controllers
{
    public class TrackingController : Controller
    {
        //
        // GET: /Tracking/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Tools() {
            return View();
        }

        public ActionResult AirCargo()
        {
            return View();
        }

        public ActionResult Container()
        {
            return View();
        }

        public ActionResult Parcel()
        {
            return View();
        }
    }
}
