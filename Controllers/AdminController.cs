using CNPM_Tour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNPM_Tour.Controllers
{
    public class AdminController : Controller
    {
        private CNPMEntities db = new CNPMEntities();
        public ActionResult TrangChu()
        {
            return View(db.Partners.ToList());
        }
        public ActionResult QLTour()
        {

            return View();
        }
        public ActionResult QLNhanVien()
        {

            return View();
        }
        public ActionResult QLKhachHang()
        {

            return View();
        }
        public ActionResult ChuongTrinhKhuyenMai()
        {

            return View();
        }
        public ActionResult QLDoiTac()
        {

            return View();
        }
        public ActionResult BaoCaoTaiChinh()
        {

            return View();
        }
        public ActionResult HoTroKH()
        {

            return View();
        }
        public ActionResult CTTour()
        {

            return View();
        }
        public ActionResult CTCTKM()
        {

            return View();
        }
        public ActionResult CTDoiTac()
        {

            return View();
        }



    }
}