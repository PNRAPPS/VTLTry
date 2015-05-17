using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vital.Service;
using Vital.Model;

namespace Vital.Web.Controllers
{
    public class NewsController : Controller
    {
        //
        // GET: /News/

        private readonly INewsService _newsService;

        public NewsController(INewsService newsService) {
            this._newsService = newsService;
        }

        public ActionResult Index()
        {

            IEnumerable<NewsModel> news = this._newsService.GetAllNews();
            

            return View(news);
        }

    }
}
