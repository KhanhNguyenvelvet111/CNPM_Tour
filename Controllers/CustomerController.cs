using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNPM_Tour.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult HomePage()
        {
            return View();
        }
        public ActionResult AccountDetail()
        {
            return View();
        }
        public ActionResult TourPage()
        {
            return View();
        }
        public ActionResult TourDetail()
        {
            return View();
        }
        public ActionResult ConfirmTour()
        {
            return View();
        }
    }
}