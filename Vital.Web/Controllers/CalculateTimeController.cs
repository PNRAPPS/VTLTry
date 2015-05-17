using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UPS.Service;
using Vital.Model;
using Vital.Service;

namespace Vital.Web.Controllers
{
    public class CalculateTimeController : Controller
    {

        readonly IShippingTransitService _shippingTransitService;
        readonly ICustomerService _customerService;
        readonly ICustomerAccountService _customerAccountService;

        public CalculateTimeController(IShippingTransitService shippingTransitService, ICustomerService customerService, ICustomerAccountService customerAccountService)
        {
            this._shippingTransitService = shippingTransitService;
            this._customerService = customerService;
            this._customerAccountService = customerAccountService;
        }

        public ActionResult Index()
        {
            var model = new Model.CalculateRequestModel();
            if (User.Identity.IsAuthenticated)
            {
                model = new Model.CalculateRequestModel()
                {
                    Accounts = _customerAccountService.GetListByUsername(User.Identity.Name).ToList()
                };
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult CalculateTimeAjax(CalculateRequestModel model)
        {
            if (Request.IsAjaxRequest())
            {
                try
                {
                    model = _shippingTransitService.Calculate(model);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error", ex.Message);
                }
                return PartialView("_CalculateTimePartial", model);
            }
            return PartialView("_CalculateTimePartial", model);
        }

    }
}