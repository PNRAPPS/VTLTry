using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vital.Model;
using Vital.Service;

namespace Vital.Web.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {

        private readonly ICustomerAccountService _customerAccountService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITermService _termService;
       

        public CustomerController(IUnitOfWork unitOfWork, ICustomerAccountService customerAccountService, ITermService termService)
        {
            this._unitOfWork = unitOfWork;
            this._termService = termService;
            this._customerAccountService = customerAccountService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ManageMyAccount()
        {
            IEnumerable<CustomerAccountModel> accounts = this._customerAccountService.GetListByUsername(User.Identity.Name);
            return View(accounts);
        }

        public ActionResult CreateAccount()
        {
            ViewBag.Terms = _termService.GetDropDownListData();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAccount(CustomerAccountModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CustomerAccountModel data = this._customerAccountService.Add(model, User.Identity.Name);
                    _unitOfWork.Save();
                    return RedirectToAction("ManageMyAccount", "Customer");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex);
                }
            }
            ViewBag.Terms = _termService.GetDropDownListData();
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteAccountNumber(string accountNumberId)
        {
            try
            {

                var check = _customerAccountService.deleteAccountNumber(accountNumberId);

                return Json(new
                {
                    status = "success",
                    data = check

                });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", data = ex.InnerException }, JsonRequestBehavior.AllowGet);
            }
        
        }

    }
}