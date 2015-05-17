using Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using UPS.Service;
using Vital.Model;
using Vital.Service;

namespace Vital.Web.Controllers
{
    public class QuantumController : Controller
    {

        readonly IUnitOfWork _unitOfWork;
        readonly IQuantumService _QuantumService;
        readonly IQVService _QvService;
        readonly ITrackShipmentService _trackShipmentService;

        private static QuantumViewResponse _SourceQuantumModel;
        private static QuantumViewResponse _FilteredQuantumModel;

        public QuantumController(IUnitOfWork unitOfWork,
            IQuantumService quantumService,
            IQVService qvService,
            ITrackShipmentService trackShipmentService)
        {
            this._unitOfWork = unitOfWork;
            this._QvService = qvService;
            this._QuantumService = quantumService;
            this._trackShipmentService = trackShipmentService;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            string username = form.Get("userName");
            string password = form.Get("password");

            if (username.Equals("qvm.rhenson3") & password.Equals("Ah7pH987"))
            {
                Session["IsQuantumAuthorized"] = true;
            }
            else
            {
                Session["IsQuantumAuthorized"] = false;
            }

            return RedirectToAction("Index");
        }

        [Authorize]
        // GET: Quantum
        public ActionResult Index()
        {
            #region Quantum Login
            if (Session["IsQuantumAuthorized"] != null)
            {
                if ((bool)Session["IsQuantumAuthorized"])
                {

                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            else
            {
                return RedirectToAction("Login");
            }
            #endregion

            ViewBag.OutboundCustomViews = _QuantumService.GetOutboundCustomViews()
                .Select(r => new SelectListItem() { Text = r, Value = r });

            ViewBag.OutboundSearchFilters = _QuantumService.GetOutboundSearchFilters()
                .Select(r => new SelectListItem() { Text = r, Value = r });

            //if (_QuantumModel == null)
            //{
            //    var data = _QuantumService.GetQuantumData();

            //    List<string> QVEvents = new List<string>();

            //    foreach (var events in data.QuantumViewEvents.SubscriptionEvents)
            //    {
            //        int filecount = 0;

            //        foreach (var item in events.SubscriptionFile)
            //        {
            //            filecount += item.Delivery.Count;
            //        }

            //        QVEvents.Add(string.Format("{0} ({1})", events.Name, filecount.ToString()));
            //    }

            //    ViewBag.QVEvents = QVEvents;

            //    var OutboundModel = new QuantumViewOutbound();
            //    List<QuantumViewOutboundShipment> OutboundShipmentData = _QuantumService.GetSubscriptionEventData(data, "OVS");

            //    foreach (var item in OutboundShipmentData)
            //    {
            //        TrackingResultModel inquiryResult = _trackShipmentService.SearchInquiry(item.TrackingNumber);

            //        item.Service = inquiryResult.Description;
            //        item.Status = inquiryResult.Status;
            //    }

            //    List<QuantumViewOutboundSummary> OutboundShipmentSummary = _QuantumService.GetSubscriptionSummary(OutboundShipmentData, "OVS");
            //    List<QuantumViewOutboundShipment> InboundShipmentData = _QuantumService.GetSubscriptionEventData(data, "IVS");

            //    foreach (var item in InboundShipmentData)
            //    {
            //        TrackingResultModel inquiryResult = _trackShipmentService.SearchInquiry(item.TrackingNumber);

            //        item.Service = inquiryResult.Description;
            //        item.Status = inquiryResult.Status;
            //    }

            //    List<QuantumViewOutboundShipment> CombinedShipmentData = new List<QuantumViewOutboundShipment>();
            //    CombinedShipmentData.AddRange(OutboundShipmentData);
            //    CombinedShipmentData.AddRange(InboundShipmentData);

            //    _QuantumModel = new QuantumViewModel()
            //        {
            //            Outbound = new QuantumViewOutbound()
            //            {
            //                OutboundSummary = OutboundShipmentSummary,
            //                OutboundShipmentDetails = OutboundShipmentData
            //            },
            //            Inbound = new QuantumViewOutbound()
            //            {
            //                OutboundShipmentDetails = InboundShipmentData
            //            },
            //            Combined = new QuantumViewOutbound()
            //            {
            //                OutboundShipmentDetails = CombinedShipmentData
            //            }

            //        };
            //}

            //if (!string.IsNullOrEmpty(outShipNum))
            //{
            //    _QuantumModel.Outbound.OutboundShipmentDetails = _QuantumModel.Outbound.OutboundShipmentDetails.Where(r => r.ShipperNumber == outShipNum).ToList();
            //    _QuantumModel.Outbound.OutboundSummary = _QuantumModel.Outbound.OutboundSummary.Where(r => r.UPSAccount == outShipNum).ToList();
            //}

            return View();
        }

        [HttpPost]
        public ActionResult GetSubscriptionData()
        {
            try
            {

                List<string> data = new List<string>();
                _SourceQuantumModel = _QuantumService.GetQuantumData();
                _FilteredQuantumModel = _SourceQuantumModel;

                data = _FilteredQuantumModel.QuantumViewEvents.SubscriptionEvents.Select(r => r.Name).ToList();


                return Json(new { status = "success", msg = "Data Loaded.", data = data });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult GetShipmentDetails(string eventName, string shipmentNumber, string filter, string tag, string status, string fromDate, string toDate)
        {
            try
            {
                List<QuantumViewShipmentDetail> data = _QvService.GetShipmentData(eventName, status, filter, tag, shipmentNumber, fromDate, toDate).ToList();

                var summary = _QuantumService.GetSubscriptionSummary(data, eventName);

                return Json(new { status = "success", msg = "Data Loaded.", data = data, summary = summary });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Manage()
        {
            return View();
        }

        public ActionResult _Outbound()
        {
            return PartialView();
        }

        public ActionResult _Inbound()
        {
            return PartialView();
        }

        public ActionResult _Combined()
        {
            return PartialView();
        }

        public ActionResult ExportToExcel(string eventName, string filter, string tag, string fromDate, string toDate)
        {
            List<QuantumViewShipmentDetail> data = _QvService.GetShipmentData(eventName, "", filter, tag, "", fromDate, toDate).ToList();

            var grid = new GridView();
            grid.DataSource = data;
            grid.DataBind();

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=" + eventName + DateTime.Now.ToShortDateString().Replace("/", "") + ".xls");
            Response.ContentType = "application/ms-excel";

            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);

            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

            return View("MyView");
        }
    }
}