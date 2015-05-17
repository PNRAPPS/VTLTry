
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vital.Model;
using Vital.Service;
namespace Vital.Web.Controllers
{

  
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        private readonly IAdminUserService _adminUserService;
        private readonly ICustomerService _customerService;
        private readonly INewsService _newsService;
        private readonly IInvoiceService _invoiceRepository;
        private readonly ICustomerAccountService _customerAccountService;

        public AdminController(IAdminUserService adminUserService,ICustomerService customerService,INewsService newsService,
            IInvoiceService _invoiceRepository, ICustomerAccountService _customerAccountService)
        {
            this._adminUserService = adminUserService;
            this._customerService = customerService;
            this._newsService = newsService;
            this._invoiceRepository = _invoiceRepository;
            this._customerAccountService = _customerAccountService;
        }
        public ActionResult Index()
        {
            
            return PartialView();
        }

        public ActionResult Search(string search)
        {

            String s = Request.QueryString["search"];

            IEnumerable<CustomerModel> m = this._customerService.GetListSearchResult(s);

            return PartialView("_SearchResult", m);
        }
        public ActionResult Accounts() {

            IEnumerable<CustomerModel> accounts = this._customerService.GetAllCustomer();
            return PartialView(accounts);
        
        }

        public ActionResult News() {

            IEnumerable<NewsModel> news = this._newsService.GetAllNews();
            return PartialView(news);
        }

        public ActionResult AddNews() {

           

            return PartialView();
        }

        public ActionResult ViewNews()
        {

            String s = Request.QueryString["newsid"];

            NewsModel news = _newsService.GetNewsId(Int32.Parse(s));

            return PartialView(news);
        }

        [HttpPost]
        public ActionResult saveNews(string title, System.DateTime fulldate, string caption, string content) {

            
            try
            {
                NewsModel news = new NewsModel();
        
                news.NewsTitle = title;
                news.NewsDate = fulldate;
                news.NewsCaption = caption;
                news.NewsContent = content;

                _newsService.Add(news);

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

        [HttpPost]
        public ActionResult updateNews(string title, System.DateTime fulldate, string caption, string content, int id) {

            try
            {
                NewsModel news = new NewsModel();

                news.NewsTitle = title;
                news.NewsDate = fulldate;
                news.NewsCaption = caption;
                news.NewsContent = content;
                news.ID = id;

                _newsService.Update(news, id);

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

        [HttpPost]
        public ActionResult deleteNews(int id)
        {

            try
            {

                var check = _newsService.deleteNews(id);

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

        [HttpPost]
        public ActionResult validateLogin(string uname, string pword) {

            try
            {

                var check = _adminUserService.ValidateLogin(uname, pword);

                return Json(new
                {
                    status = "success",
                    data = check
                });
            }
            catch (Exception ex) {
                return Json(new { status = "error", data = ex.InnerException }, JsonRequestBehavior.AllowGet );
            }


        }

        public ActionResult ViewAccounts() {

            String s = Request.QueryString["username"];

           CustomerModel customer = _customerService.GetByUsername(s);

           return PartialView(customer);
        
        }

        [HttpPost]
        public ActionResult updateAccount(string uname, string pword, string name, string email, string company, string country,
            string address1, string address2, string city, string province, string postal, string tel) {

                try
                {
                    CustomerModel c = new CustomerModel();
                    c.Username = uname;
                    c.Password = pword;
                    c.ContactPerson = name;
                    c.Email = email;
                    c.CompanyName = company;
                    c.Country = country;
                    c.Address1 = address1;
                    c.Address2 = address2;
                    c.City = city;
                    c.State = province;
                    c.Zip = postal;
                    c.PhoneExt = tel;
                    c.Phone = tel;

                    _customerService.Update(c, uname);
                    
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

        [HttpPost]
        public ActionResult deleteUserAccount(string username) {

            try
            {

                var check = _customerService.deleteUserAccount(username);

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

        public ActionResult AddInvoice() {

            String s = Request.QueryString["username"];
            IEnumerable<CustomerAccountModel> accounts = this._customerAccountService.GetListByUsername(s);
            
            CustomerModel customer = _customerService.GetByUsername(s);

            return PartialView(accounts);
        }

        [HttpPost]
        public ActionResult AddInvoice(HttpPostedFileBase file, string username, string accountnumber, string invoicesubject, string datemonth, string dateday, string dateyear, string invoicedetails)
        {
            try
            {
                if (file.ContentLength > 0)
                {

                    var binary = new byte[file.ContentLength];
                    file.InputStream.Read(binary, 0, file.ContentLength);

                    String idate = dateyear + "-" + datemonth + "-" + dateday;

                    InvoiceModel data = new InvoiceModel();
                    data.invoiceSubject = invoicesubject;
                    data.invoiceDetails = invoicedetails;
                    data.invoiceFileName = binary;
                    data.invoiceDate = Convert.ToDateTime(idate);
                    data.dateUpload = System.DateTime.Now;
                    data.username = username;
                    data.accountnumber = accountnumber;

                    _invoiceRepository.Add(data);

                }

                return Redirect("?username="+username+"");
            }
            catch (Exception e) {
                Console.Write(e.Message);
                return null; 
            }
            
        }

    }
}
