using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Trendbase.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult SsasService()
        {
            return View();
        }

        public ActionResult TrendbaseService()
        {
            return View();
        }

        public ActionResult AzureMachineLearningService()
        {
            return View();
        }
    }
}
