using Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UPS.Service;
using Vital.Model;
using Vital.Service;
using Vital.Web.Models;

namespace Vital.Web.Controllers
{
    public class ShipmentController : Controller
    {
        readonly IAddressBookInfoService _addressBookInfoService;
        readonly IConsigneeService _consigneeService;
        readonly ICustomerAccountService _customerAccountService;
        readonly ICustomerService _customerService;
        readonly ICustomerShipmentService _customerShipmentService;
        readonly IShippingService _shippingService;
        readonly IPickupService _pickupService;
        readonly ILabelRecoveryService _labelService;
        readonly ILookupService _lookupService;
        readonly IUnitOfWork _unitOfWork;
        readonly IRateService _rateService;
        readonly ITimeInTransitService _transitService;
        readonly IShipmentDraftService _shipmentDraftService;

        public ShipmentController(IUnitOfWork unitOfWork,
            IShippingService shippingService,
            IPickupService pickupService,
            ILabelRecoveryService labelService,
            ICustomerService customerService,
            IConsigneeService consigneeService,
            ICustomerAccountService customerAccountService,
            ICustomerShipmentService customerShipmentService,
            ILookupService lookupService,
            IAddressBookInfoService addressBookInfoService,
            IRateService rateService,
            ITimeInTransitService transitService,
            IShipmentDraftService shipmentDraftService)
        {
            this._customerAccountService = customerAccountService;
            this._unitOfWork = unitOfWork;
            this._customerService = customerService;
            this._consigneeService = consigneeService;
            this._addressBookInfoService = addressBookInfoService;
            this._shippingService = shippingService;
            this._customerShipmentService = customerShipmentService;
            this._pickupService = pickupService;
            this._labelService = labelService;
            this._lookupService = lookupService;
            this._rateService = rateService;
            this._transitService = transitService;
            this._shipmentDraftService = shipmentDraftService;
        }

        [Authorize]
        public ActionResult Label(string t)
        {
            var data = _customerShipmentService.GetShipment(t);

            ViewBag.Image = _labelService.GetImageFromStream(data.shipmentLabel);

            return View();
        }

        [Authorize]
        public ActionResult AddressBook(Guid? id)
        {
            var model = new ShipmentModel();

            if (id.HasValue)
            {
                var data = _consigneeService.GetAddressInformation(id.Value);
                model.ConsigneeAddressBookId = data.Id.ToString();
                model.ConsigneeAddress1 = data.Address1;
                model.ConsigneeAddress2 = data.Address2;
                model.ConsigneeAddress3 = data.Address3;
                model.ConsigneeCity = data.City;
                model.ConsigneeProvince = data.StateOrProvince;
                model.ConsigneeCountry = data.Country;
                model.ConsigneeTelephone = data.Phone;
                model.ConsigneeTelephoneExt = data.PhoneExt;
                model.ConsigneePostalCode = data.PostalOrZip;
                model.ConsigneeEmail = data.Email;
                model.ConsigneeContactName = data.ContactName;
                model.ConsigneeCompanyName = data.CompanyName;
            }
            return PartialView("_AddressBook", model);
        }

        [Authorize]
        public ActionResult AddressBookViewInfo(Guid id)
        {
            var model = _consigneeService.GetAddressInformation(id);
            return PartialView("_AddressBookViewInfo", model);
        }

        [Authorize]
        public ActionResult Create(string s)
        {
            var model = new ShipmentModel();
            SetViewBagSelectList();

            if (string.IsNullOrEmpty(s))
            {
                var currentCustomer = _customerService.GetByUsername(User.Identity.Name);

                model = new ShipmentModel()
                {
                    ConsignorAddress1 = currentCustomer.Address1,
                    ConsignorAddress2 = currentCustomer.Address2,
                    ConsignorAddress3 = "",
                    ConsignorCompanyName = currentCustomer.CompanyName,
                    ConsignorContactName = currentCustomer.ContactPerson,
                    ConsignorCountry = currentCustomer.Country,
                    ConsignorCity = currentCustomer.City,
                    ConsignorProvince = currentCustomer.State,
                    ConsignorPostalCode = currentCustomer.Zip,
                    ConsignorTelephone = currentCustomer.Phone,
                    ConsignorTelephoneExt = currentCustomer.PhoneExt,
                    ConsignorEmail = currentCustomer.Email,
                    IsForReview = true,
                    IsScheduledPickup = false
                };
            }
            else
            {
                model = _shipmentDraftService.GetShipmentData(new Guid(s));
                model.DraftId = s;
            }

            ViewBag.PickupMinutes = _lookupService.GetMinutes();
            ViewBag.PickupHours = _lookupService.GetHours();
            ViewBag.CollectionDates = _lookupService.GetCollectionDates();
            ViewBag.PickupLocations = _lookupService.GetPickupLocations();

            return View(model);
        }

        public ActionResult Review(string s)
        {

            var model = _shipmentDraftService.GetShipmentData(new Guid(s));

            ViewBag.ServiceType = _lookupService.GetLookupText("SERVICE", model.ServiceType);
            ViewBag.PackagingType = _lookupService.GetLookupText("PACKAGING", model.PackagingType);

            var timeInTransitData = _transitService.GetTimeInTransit(model);

            List<PaymentInformationModel> ListOfPayments = new List<PaymentInformationModel>();

            foreach (var item in timeInTransitData.TransitResponse.ServiceSummary)
            {
                string service = item.Service.Description;

                if (item.Service.Description.ToLower().Equals("ups express plus"))
                    service = "UPS Express Early A.M.";

                string code = _lookupService.GetLookupValue("SERVICE", service);

                UPS.Service.RateWebService.RateResponse charge = _rateService.GetRate(model, code);

                if (charge != null)
                {
                    PaymentInformationModel paymentModel = new PaymentInformationModel()
                    {
                        ChargeValue = charge.RatedShipment[0].TotalCharges.MonetaryValue,
                        EstimatedArrival = item.EstimatedArrival.Date + " " + item.EstimatedArrival.Time,
                        ServiceName = service,
                        CurrencyCode = charge.RatedShipment[0].TotalCharges.CurrencyCode
                    };

                    ListOfPayments.Add(paymentModel);
                }
            }

            ViewBag.GuaranteedBy = ListOfPayments.First(r => r.ServiceName == ViewBag.ServiceType).EstimatedArrival;
            ViewBag.CurrentCharge = ListOfPayments.First(r => r.ServiceName == ViewBag.ServiceType).ChargeValue;

            ViewBag.PaymentList = ListOfPayments;

            return View(model);
        }

        [HttpPost]
        public ActionResult CheckReview(ShipmentModel model)
        {
            model.ServiceType = _lookupService.GetLookupValue("SERVICE", model.ReviewServiceName);

            if (ModelState.IsValid)
            {
                try
                {

                    _shippingService.ProcessShipment(model);

                    if (model.IsSuccess)
                    {

                        //Relocated to ensure that it will only create a pickup schedule only when the model is valid.
                        if (model.IsScheduledPickup)
                        {
                            model = _pickupService.SchedulePickup(model);
                        }

                        //Relocated to ensure that the system will only create a label once it has been parsed.
                        model = _labelService.CreateProcessLabel(model);

                        UpdateConsigneeData(model);

                        _customerShipmentService.Add(new CustomerShipmentModel()
                        {
                            status = "New",
                            trackingNumber = model.ShipmentIdentificationNumber,
                            pickupNumber = model.pickupIdentificationNumber,
                            shipmentLabel = model.ShipmentLabel
                        }, User.Identity.Name);

                        model.LabelGenerate = _labelService.GetImageFromStream(model.ShipmentLabel);

                        _shipmentDraftService.FinalizeShipmentDraft("Submitted", new Guid(model.DraftId));
                        _unitOfWork.Save();

                        return View("ShipmenResult", model);
                    }
                    else
                    {
                        SetViewBagSelectList();
                        return RedirectToAction("Create", new { s = model.DraftId });
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);

                    model.IsSuccess = false;
                    model.ResultMessage = ex.Message;

                    _shipmentDraftService.UpdateShipmentDraft(model, new Guid(model.DraftId));
                    _unitOfWork.Save();

                    SetViewBagSelectList();
                    return RedirectToAction("Create", new { s = model.DraftId });
                }
            }
            else
            {
                SetViewBagSelectList();
                return RedirectToAction("Create", new { s = model.DraftId });
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(ShipmentModel model)
        {
            var cust = _customerService.GetByUsername(User.Identity.Name);
            model.ConsignorAddress1 = cust.Address1;
            model.ConsignorAddress2 = cust.Address2;
            model.ConsignorAddress3 = "";
            model.ConsignorCompanyName = cust.CompanyName;
            model.ConsignorContactName = cust.ContactPerson;
            model.ConsignorCountry = cust.Country;
            model.ConsignorCity = cust.City;
            model.ConsignorProvince = cust.State;
            model.ConsignorPostalCode = cust.Zip;
            model.ConsignorTelephone = cust.Phone;
            model.ConsignorTelephoneExt = cust.PhoneExt;
            model.ConsignorEmail = cust.Email;
            model.UPS_Username = cust.UPSUsername;
            model.UPS_Password = cust.UPSPassword;

            Guid consigneeId;
            if (model.ConsigneeIsEditMode != "Y" && Guid.TryParse(model.ConsigneeAddressBookId, out consigneeId))
            {
                var cons = _consigneeService.GetById(consigneeId);
                model.ConsigneeCompanyName = cons.ConsigneeName;
                model.ConsigneeContactName = cons.ConsigneeContactPerson;
                model.ConsigneeCountry = cons.ConsigneeCountry;
                model.ConsigneeAddress1 = cons.ConsigneeAddress1;
                model.ConsigneeAddress2 = cons.ConsigneeAddress2;
                model.ConsigneeAddress3 = cons.ConsigneeAddress3;
                model.ConsigneeCity = cons.ConsigneeCity;
                model.ConsigneeProvince = cons.ConsigneeStateOrProvince;
                model.ConsigneePostalCode = cons.COnsigneePostalOrZip;
                model.ConsigneeTelephone = cons.ConsigneePhone;
                model.ConsigneeTelephoneExt = cons.ConsigneePhoneExt;
                model.ConsigneeEmail = cons.ConsigneeEmail;
            }

            if (string.IsNullOrEmpty(model.PackageDeclaredValueCAD))
            {
                model.PackageDeclaredValueCAD = "0";
            }

            int x;

            if (!Int32.TryParse(model.PackageDeclaredValueCAD, out x))
            {
                model.PackageDeclaredValueCAD = "0";
            }

            //Save draft data
            string id = _shipmentDraftService.SaveShipment(model, User.Identity.Name);
            _unitOfWork.Save();
            return RedirectToAction("Review", new { s = id });
        }

        [Authorize]
        public ActionResult GetCustomerInfo()
        {
            var model = _customerService.GetByUsername(User.Identity.Name);
            return PartialView("_CustomerProfile", model);
        }

        [Authorize]
        public ActionResult Index()
        {
            var model = new DataPagingModel<CustomerShipmentModel>() { Page = 1 };
            int _totalCount = 0;
            var data = _customerShipmentService.GetAll(User.Identity.Name, out _totalCount);
            model.TotalCount = _totalCount;
            model.Data = data;
            return View(model);
        }

        [Authorize]
        public ActionResult ShipmentPaging(int id)
        {
            var model = new DataPagingModel<CustomerShipmentModel>() { Page = id };
            int _totalCount = 0;
            var data = _customerShipmentService.GetListByPage(User.Identity.Name, model.Page, out _totalCount);
            model.TotalCount = _totalCount;
            model.Data = data;
            return View("Index", model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult UpdateCustomerProfile(CustomerModel data)
        {
            _customerService.Update(data, User.Identity.Name);
            _unitOfWork.Save();

            var currentCustomer = _customerService.GetByUsername(User.Identity.Name);

            var model = new ShipmentModel()
            {
                ConsignorAddress1 = currentCustomer.Address1,
                ConsignorAddress2 = currentCustomer.Address2,
                ConsignorAddress3 = "",
                ConsignorCompanyName = currentCustomer.CompanyName,
                ConsignorContactName = currentCustomer.ContactPerson,
                ConsignorCountry = currentCustomer.Country,
                ConsignorCity = currentCustomer.City,
                ConsignorProvince = currentCustomer.State,
                ConsignorPostalCode = currentCustomer.Zip,
                ConsignorTelephone = currentCustomer.Phone,
                ConsignorTelephoneExt = currentCustomer.PhoneExt,
                ConsignorEmail = currentCustomer.Email,
            };

            return PartialView("_ShipmentComingFrom", model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult VoidShipment(string id)
        {
            try
            {
                string message = "";
                _shippingService.Void(id, User.Identity.Name, _customerService.GetPassword(User.Identity.Name), out message);
                _customerShipmentService.Void(id);
                _unitOfWork.Save();
                return Json(new { status = "success", msg = message });
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", msg = ex.Message });
            }
        }
        private void SetViewBagSelectList()
        {
            var consigneeAddress = _consigneeService.GetValueTextListByUserName(User.Identity.Name).ToList();
            consigneeAddress.Insert(0, new ValueText() { Value = "-99", Text = "-- Select Address --" });
            ViewBag.ConsigneeAddress = consigneeAddress;

            string companyName = _customerService.GetByUsername(User.Identity.Name).CompanyName;
            var accounts = _customerAccountService
                .GetListByUsername(User.Identity.Name)
                .Select(x => new ValueText() { Value = x.Id, Text = x.Id + " - " + companyName }).ToList();

            accounts.Insert(0, new ValueText() { Value = "-99", Text = "-- Select Account --" });
            ViewBag.CustomerAccountNumber = accounts.ToSelectList();
        }


        [Authorize]
        public ActionResult SchedulePickup()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CancelScheduledPickup(string id)
        {
            try
            {
                _shipmentDraftService.CancelScheduledPickup(new Guid(id));
                _unitOfWork.Save();
                return Json(new { status = "success", msg = "Scheduled Pickup Cancelled" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        private void UpdateConsigneeData(ShipmentModel model)
        {
            if (model.ConsigneeIsEditMode == "Y")
            {
                if (string.IsNullOrEmpty(model.ConsigneeAddressBookId) || model.ConsigneeAddressBookId == "-99")
                {
                    model.ConsigneeSaveOptionForAddress = 1;
                }
                switch (model.ConsigneeSaveOptionForAddress)
                {
                    case 1: //Save New Entry
                        var insertConsignee = new ConsigneeModel()
                        {
                            ConsigneeCity = model.ConsigneeCity,
                            ConsigneeCountry = model.ConsigneeCountry,
                            ConsigneeEmail = model.ConsigneeEmail,
                            ConsigneePhone = model.ConsigneeTelephone,
                            ConsigneePhoneExt = model.ConsigneeTelephoneExt,
                            ConsigneeStateOrProvince = model.ConsigneeProvince,
                            ConsigneeAddress1 = model.ConsigneeAddress1,
                            ConsigneeAddress2 = model.ConsigneeAddress2,
                            ConsigneeAddress3 = model.ConsigneeAddress3,
                            ConsigneeName = model.ConsigneeCompanyName,
                            AddressBookName = model.ConsigneeSaveAddressBookAs,
                            ConsigneeContactPerson = model.ConsigneeContactName,
                            COnsigneePostalOrZip = model.ConsigneePostalCode,
                            ConsigneeIsResidential = model.ConsigneeIsResidential,
                        };
                        _consigneeService.Add(insertConsignee, User.Identity.Name);
                        _unitOfWork.Save();
                        model.ConsigneeAddressBookId = insertConsignee.Id.ToString();
                        break;
                    case 2: //Update Entry
                        Guid consigneeId;
                        if (Guid.TryParse(model.ConsigneeAddressBookId, out consigneeId))
                        {
                            _consigneeService.Update(new ConsigneeModel()
                            {
                                ConsigneeCity = model.ConsigneeCity,
                                ConsigneeCountry = model.ConsigneeCountry,
                                ConsigneeEmail = model.ConsigneeEmail,
                                ConsigneePhone = model.ConsigneeTelephone,
                                ConsigneePhoneExt = model.ConsigneeTelephoneExt,
                                ConsigneeStateOrProvince = model.ConsigneeProvince,
                                ConsigneeAddress1 = model.ConsigneeAddress1,
                                ConsigneeAddress2 = model.ConsigneeAddress2,
                                ConsigneeAddress3 = model.ConsigneeAddress3,
                                ConsigneeName = model.ConsigneeCompanyName,
                                AddressBookName = model.ConsigneeSaveAddressBookAs,
                                ConsigneeContactPerson = model.ConsigneeContactName,
                                COnsigneePostalOrZip = model.ConsigneePostalCode,
                                ConsigneeIsResidential = model.ConsigneeIsResidential,
                            }, consigneeId);
                            _unitOfWork.Save();
                        }
                        else
                        {
                            throw new Exception("Unable to get Consignee ID");
                        }
                        break;
                    default:
                        break;
                }
            }
        }

    }
}