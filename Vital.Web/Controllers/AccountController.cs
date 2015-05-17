using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vital.Model;
using Vital.Service;
using Repository;
using System.Web.Security;
using System.Web.UI;
using System.IO;

namespace Vital.Web.Controllers
{
    public class AccountController : Controller
    {

        private readonly ICustomerService _customerService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConsigneeService _consigneeService;
        private readonly ICalculateRateLTLService _calculateRateLTLService;
        private readonly ICustomerAccountService _customerAccountService;
        private readonly IInvoiceService _invoiceService;

        public AccountController(IUnitOfWork unitOfWork, ICustomerService customerService, IConsigneeService consigneeService,
           ICalculateRateLTLService calculateRateLTLService, ICustomerAccountService customerAccountService,
            IInvoiceService _invoiceService)
        {
            this._unitOfWork = unitOfWork;
            this._customerService = customerService;
            this._consigneeService = consigneeService;
            this._calculateRateLTLService = calculateRateLTLService;
            this._customerAccountService = customerAccountService;
            this._invoiceService = _invoiceService;
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {

            var msg = "";

            try
            {
                if (ModelState.IsValid)
                {
                    string hashPasword = "";
                    if (_customerService.ValidateLogin(model.UserName, model.Password, out hashPasword))
                    {
                        if (System.Web.Helpers.Crypto.VerifyHashedPassword(hashPasword, model.Password))
                        {
                            FormsAuthentication.SetAuthCookie(model.UserName, true);
                            return RedirectToAction("../Customer/");
                        }
                        else
                        {
                            ModelState.AddModelError("", new Exception("Invalid Username or password"));
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", new Exception("Invalid Username or password"));
                        return View(model);
                    }
                }
                else
                {

                    ModelState.AddModelError("", new Exception("Invalid Username or password"));
                    return View(model);
                }
                return View(model);
            }
            catch (Exception e)
            {

                throw e;
            }

        }


         [Authorize]
        public ActionResult InvoiceUpload(int id) {

            var data = _invoiceService.GetInvoiceById(id);

            ViewBag.Image = _invoiceService.GetImageFromStream(data.invoiceFileName);

           
            return PartialView();

        }

        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        public ActionResult UpdateMyProfile()
        {

            CustomerModel data = this._customerService.GetByUsername(User.Identity.Name);

            return View(data);
        }

        public ActionResult ChangePassword()
        {

            CustomerModel data = this._customerService.GetByUsername(User.Identity.Name);

            return View(data);
        }

        public ActionResult MyVital()
        {
            return View();
        }

        public ActionResult ManageInvoices()
        {
            IEnumerable<CustomerAccountModel> accounts = this._customerAccountService.GetListByUsername(User.Identity.Name);
            return View(accounts);
        }

        public ActionResult LoadInvoiceList() { 
        
            String s = Request.QueryString["accountnumber"];
            String fromdate = Request.QueryString["fromdate"];
            String todate = Request.QueryString["todate"];
            DateTime dt= Convert.ToDateTime(fromdate);
            DateTime dt2= Convert.ToDateTime(todate);
       
            IEnumerable<InvoiceModel> m = this._invoiceService.GetInvoiceListByAccountNumber(s, dt, dt2);

            return PartialView("_InvoiceList", m);
        
        }

        [HttpPost]
        public ActionResult UpdateProfileInfo(string name, string company, string email, string country, string address1
            , string address2, string city, string province, string postal, string telephone)
        {
            try
            {

                CustomerModel c = new CustomerModel();

                c.ContactPerson = name;
                c.Email = email;
                c.CompanyName = company;
                c.Country = country;
                c.Address1 = address1;
                c.Address2 = address2;
                c.City = city;
                c.State = province;
                c.Zip = postal;
                c.PhoneExt = telephone;
                c.Phone = telephone;

                _customerService.Update(c, User.Identity.Name);

                return Json(new
                {
                    status = "success",
                    data = true
                });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", data = ex.InnerException }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Register()
        {
            var model = new CustomerModel() { Country = "CA" };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(CustomerModel model)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Model State Invalid");
                }
                model.Password = System.Web.Helpers.Crypto.HashPassword(model.Password);
                _customerService.Add(model);
                _unitOfWork.Save();

                FormsAuthentication.SetAuthCookie(model.Username, true);
                return RedirectToAction("", "Account");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex);
            }
            return View(model);
        }

        public ActionResult AccessAddressBook()
        {


            IEnumerable<ConsigneeModel> consignee = this._consigneeService.GetListByUserName(User.Identity.Name);

            return View(consignee);
        }

        [HttpPost]
        public ActionResult DeleteAddressBook(Guid bookid)
        {

            try
            {
                _consigneeService.DeleteAddressBook(bookid);

                return Json(new
                {
                    status = "success",
                    data = true
                });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", msg = ex.InnerException }, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult CreateConsignee()
        {

            return View();

        }

        [HttpPost]
        public ActionResult SaveConsignee(string consigneeName, string consigneeContactPerson, string consigneeAddr1,
            string consigneeAddr2, string consigneeCountry, string consigneeCity, string consigneeStateOrProvince,
            string consigneePostalOrZip, string consigneePhone, string consigneeEmail)
        {
            try
            {

                ConsigneeModel consignee = new ConsigneeModel();
                consignee.ConsigneeName = consigneeName;
                consignee.ConsigneeContactPerson = consigneeContactPerson;
                consignee.ConsigneeAddress1 = consigneeAddr1;
                consignee.ConsigneeAddress2 = consigneeAddr2;
                consignee.ConsigneeCountry = consigneeCountry;
                consignee.ConsigneeCity = consigneeCity;
                consignee.ConsigneeStateOrProvince = consigneeStateOrProvince;
                consignee.COnsigneePostalOrZip = consigneePostalOrZip;
                consignee.ConsigneePhone = consigneePhone;
                consignee.ConsigneeEmail = consigneeEmail;

                _consigneeService.Add(consignee, User.Identity.Name);
                _unitOfWork.Save();

                return Json(new
                {
                    status = "success",
                    data = true
                });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", msg = ex.InnerException }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult CalculateRateLTL(string fromcountry, string fromcity, string fromstate, string tocountry,
            string tocity, string tostate, int totalweight)
        {

                try
                {

                    decimal rateResult = _calculateRateLTLService.getRateResultLTL(totalweight, fromcity, fromstate, fromcountry, tocity, tostate, tocountry);

                    return Json(new
                    {
                        status = "success",
                        data = rateResult
                    });
                }
                catch (Exception ex)
                {
                    return Json(new { status = "error", msg = ex.InnerException }, JsonRequestBehavior.AllowGet);
                }
        
        }

       

    }
}