using CNPM_Tour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using System.Net;

namespace CNPM_Tour.Controllers
{
    public class AdminController : Controller
    {
        private CNPMEntities db = new CNPMEntities();
        public ActionResult TrangChu()
        {
            return View(db.Partners.ToList());
        }
        #region mình sẽ làm tất cả chức năng liên quan đén tour
        //danh sách tour
        public ActionResult QLTour()
        {
            var tours = db.Tours.Include(t => t.Partner);
            return View(tours.ToList());
        }
        //chi tiết tour
        public ActionResult TourDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tours.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        public ActionResult ChinhSuaTour(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tours.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDT = new SelectList(db.Partners, "MaDT", "TenDT", tour.MaDT);
            return View(tour);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChinhSuaTour([Bind(Include = "MaTour,TenTour,DiaDiem,MoTa,TTVC,State,BannerPic,MaDT")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDT = new SelectList(db.Partners, "MaDT", "TenDT", tour.MaDT);
            return View(tour);
        }

        public ActionResult XoaTour(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tours.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }
        [HttpPost, ActionName("XoaTour")]
        [ValidateAntiForgeryToken]
        public ActionResult XacNhanXoaTour(string id)
        {
            Tour tour = db.Tours.Find(id);
            db.Tours.Remove(tour);
            db.SaveChanges();
            return RedirectToAction("QLTour");
        }

        public ActionResult TaoTour()
        {
            ViewBag.MaDT = new SelectList(db.Partners, "MaDT", "TenDT");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TaoTour([Bind(Include = "MaTour,TenTour,DiaDiem,MoTa,TTVC,State,BannerPic,MaDT")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                Random rnd = new Random();
                string matour = "TO" + rnd.Next(10000, 1000000);
                tour.MaTour = matour;
                db.Tours.Add(tour);
                db.SaveChanges();
                return RedirectToAction("QLTour");
            }

            ViewBag.MaDT = new SelectList(db.Partners, "MaDT", "TenDT", tour.MaDT);
            return View(tour);
        }
        #endregion
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