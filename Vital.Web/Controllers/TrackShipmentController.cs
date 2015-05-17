using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vital.Model;

namespace Vital.Web.Controllers
{
    public class TrackShipmentController : Controller
    {

        readonly UPS.Service.ITrackShipmentService _trackShipmentService;

        public TrackShipmentController(UPS.Service.ITrackShipmentService trackShipmentService)
        {
            this._trackShipmentService = trackShipmentService;
        }

        public ActionResult Index()
        {
            List<TrackingResultModel> model = new List<TrackingResultModel>();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(string trackingNumbers)
        {
            List<TrackingResultModel> model = _trackShipmentService.Search(trackingNumbers);
            return View(model);
        }

        public ActionResult Info(string id)
        {
            var model = new List<TrackingModel>();
            try
            {
                model = _trackShipmentService.GetInformation(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
            }
            return View(model);
        }

    }
}