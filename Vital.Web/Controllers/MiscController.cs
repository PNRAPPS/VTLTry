using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vital.Web.Controllers
{
    public class MiscController : Controller
    {
        //
        // GET: /Misc/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PrivacyPolicy()
        {
            return View();
        }

        public ActionResult SiteMap()
        {
            return View();
        }

    }
}
