using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vital.Service;
using Vital.Model;

namespace Vital.Web.Controllers
{
    public class ServicesController : Controller
    {
       

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Freightforwarding() {

            return View();

        }

        public ActionResult Support()
        {

            return View();

        }

    }
}
