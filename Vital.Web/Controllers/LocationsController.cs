using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vital.Model;
using UPS.Service;

namespace Vital.Web.Controllers
{
    public class LocationsController : Controller
    {

        readonly ILocationService _locationService;

        public LocationsController(ILocationService locationService)
        {
            this._locationService = locationService;
        }

        // GET: Locations
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LocationsModel model)
        {

            var data = _locationService.SearchLocation(model);
            ViewBag.LocationResponse = data;

            return View();
        }
    }
}
