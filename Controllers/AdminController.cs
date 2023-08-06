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
        #region mình sẽ làm tất cả chức năng liên quan đến tour
        private CNPMEntities db = new CNPMEntities();
        public ActionResult TrangChu()
        {
            return View(db.Tours.ToList());
        }
        
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
        public ActionResult ChinhSuaTour([Bind(Include = "MaTour,TenTour,DiaDiem,MoTa,TTVC,forsale,BannerUrl,MaDT")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("QLTour");
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
        public ActionResult TaoTour([Bind(Include = "MaTour,TenTour,DiaDiem,MoTa,TTVC,forsale,BannerUrl,MaDT")] Tour tour)
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
        #region mình sẽ làm tất cả chức năng liên quan đến nhân viên
        


        public ActionResult QLNhanvien()
        {
            return View(db.NhanViens.ToList());
        }

        public ActionResult NhanVienDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        
        public ActionResult TaoNhanVien()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TaoNhanVien([Bind(Include = "MaNV,TenNV,ChucVu,TrangThai")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                Random rnd = new Random();
                string nhanvien = "NV" + rnd.Next(10000, 1000000);
                nhanVien.MaNV = nhanvien;
                db.NhanViens.Add(nhanVien);
                db.SaveChanges();
                return RedirectToAction("QLNhanVien");
            }
            return View(nhanVien);
        }     
        public ActionResult ChinhSuaNV(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChinhSuaNV([Bind(Include = "MaNV,TenNV,ChucVu,TrangThai")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("QLNhanVien");
            }
            return View(nhanVien);
        }
        #endregion
        #region mình sẽ làm tất cả chức năng liên quan đén khách hàng
        public ActionResult QLKhachHang()
        {
            var khachHangs = db.KhachHangs.Include(k => k.LoaiKH).Include(k => k.UserPoint);
            return View(khachHangs.ToList());
        }
        public ActionResult KhachHangDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }
        public ActionResult TaoKhachHang()
        {
            ViewBag.MaLKH = new SelectList(db.LoaiKHs, "MaLKH", "LoaiKH1");
            ViewBag.MaKH = new SelectList(db.UserPoints, "MaKH", "MaKH");
            return View();
        }   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TaoKhachHang([Bind(Include = "MaKH,TenKH,GioiTinh,NgaySinh,MatKhau,Email,SDT,SDT2,SDT3,Email2,Email3,MaLKH")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                Random rnd = new Random();
                string khachhang = "KH" + rnd.Next(10000, 1000000);
                khachHang.MaKH = khachhang;
                db.KhachHangs.Add(khachHang);
                db.SaveChanges();
                return RedirectToAction("QLKhachHang");
            }
            ViewBag.MaLKH = new SelectList(db.LoaiKHs, "MaLKH", "LoaiKH1", khachHang.MaLKH);
            ViewBag.MaKH = new SelectList(db.UserPoints, "MaKH", "MaKH", khachHang.MaKH);
            return View(khachHang);
        }


        #endregion
        #region mình sẽ làm tất cả chức năng liên quan đén CTKM
       
        public ActionResult ChuongTrinhKhuyenMai()
        {
            return View(db.Coupons.ToList());
        }

     
        public ActionResult CTKMDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coupon coupon = db.Coupons.Find(id);
            if (coupon == null)
            {
                return HttpNotFound();
            }
            return View(coupon);
        }

       
        public ActionResult TaoCTKM()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TaoCTKM([Bind(Include = "MaCoupon,Discount")] Coupon coupon)
        {
            if (ModelState.IsValid)
            {
                Random rnd = new Random();
                string khuyenmai = "KM" + rnd.Next(10000, 1000000);
                coupon.MaCoupon = khuyenmai;
                db.Coupons.Add(coupon);
                db.SaveChanges();
                return RedirectToAction("ChuongTrinhKhuyenMai");
            }
            return View(coupon);
        }

    
        public ActionResult ChinhSuaCTKM(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coupon coupon = db.Coupons.Find(id);
            if (coupon == null)
            {
                return HttpNotFound();
            }
            return View(coupon);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChinhSuaCTKM([Bind(Include = "MaCoupon,Discount")] Coupon coupon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coupon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ChuongTrinhKhuyenMai");
            }
            return View(coupon);
        }

        public ActionResult XoaCTKM(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coupon coupon = db.Coupons.Find(id);
            if (coupon == null)
            {
                return HttpNotFound();
            }
            return View(coupon);
        }

        [HttpPost, ActionName("XoaCTKM")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Coupon coupon = db.Coupons.Find(id);
            db.Coupons.Remove(coupon);
            db.SaveChanges();
            return RedirectToAction("ChuongTrinhKhuyenMai");
        }


        #endregion
        #region mình sẽ làm tất cả chức năng liên quan đến Đối tác

       
        public ActionResult QLDoiTac()
        {
            return View(db.Partners.ToList());
        }

        public ActionResult DoiTacDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partner partner = db.Partners.Find(id);
            if (partner == null)
            {
                return HttpNotFound();
            }
            return View(partner);
        }

        public ActionResult TaoDoiTac()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TaoDoiTac([Bind(Include = "MaDT,TenDT,MaQG,SDT,DiaChi,Email,Website")] Partner partner)
        {
            if (ModelState.IsValid)
            {
                Random rnd = new Random();
                string doitac = "DT" + rnd.Next(10000, 1000000);
                partner.MaDT = doitac;
                db.Partners.Add(partner);
                db.SaveChanges();
                return RedirectToAction("QLDoiTac");
            }
           

            return View(partner);
        }

        public ActionResult ChinhSuaDoiTac(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partner partner = db.Partners.Find(id);
            if (partner == null)
            {
                return HttpNotFound();
            }
            return View(partner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChinhSuaDoiTac([Bind(Include = "MaDT,TenDT,MaQG,SDT,DiaChi,Email,Website")] Partner partner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("QLDoiTac");
            }
            return View(partner);
        }
        public ActionResult XoaDoiTac(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partner partner = db.Partners.Find(id);
            if (partner == null)
            {
                return HttpNotFound();
            }
            return View(partner);
        }

        [HttpPost, ActionName("XoaDoiTac")]
        [ValidateAntiForgeryToken]
        public ActionResult Deleteconfirm(string id)
        {
            Partner partner = db.Partners.Find(id);
            db.Partners.Remove(partner);
            db.SaveChanges();
            return RedirectToAction("QLDoiTac");
        }

        #endregion
        #region mình sẽ làm tất cả chức năng liên quan đến BCTC
        public ActionResult BaoCaoTaiChinh()
        {
            var tours = db.Tours.Include(t => t.Partner);
            return View(tours.ToList());
        }
        public ActionResult TaoBCTC()
        {
            return View(db.LoaiKHs.ToList());
        }
        public ActionResult BCTCDetails()
        {
            return View(db.LoaiKHs.ToList());
        }



        #endregion
        #region mình sẽ làm tất cả chức năng liên quan đến HTKH
        public ActionResult HoTroKH()
        { 

            return View();
        }
        #endregion
        #region mình sẽ làm tất cả chức năng liên quan đến LKH
       
        public ActionResult LoaiKH()
        {
            return View(db.LoaiKHs.ToList());
        }

       
        public ActionResult TaoLoaiKH()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TaoLoaiKH([Bind(Include = "MaLKH,LoaiKH1")] LoaiKH loaiKH)
        {
            if (ModelState.IsValid)
            {
                Random rnd = new Random();
                string loaikh = "LK" + rnd.Next(10000, 1000000);
                loaiKH.MaLKH = loaikh;
                db.LoaiKHs.Add(loaiKH);
                db.SaveChanges();
                return RedirectToAction("LoaiKH");
            }

            return View(loaiKH);
        }

       
        
        public ActionResult XoaLoaiKH(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiKH loaiKH = db.LoaiKHs.Find(id);
            if (loaiKH == null)
            {
                return HttpNotFound();
            }
            return View(loaiKH);
        }
        [HttpPost, ActionName("XoaLoaiKH")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmez(string id)
        {
            LoaiKH loaiKH = db.LoaiKHs.Find(id);
            db.LoaiKHs.Remove(loaiKH);
            db.SaveChanges();
            return RedirectToAction("LoaiKH");
        }

       


        #endregion


    }
}