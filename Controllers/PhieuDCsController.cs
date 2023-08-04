using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CNPM_Tour.Models;

namespace CNPM_Tour.Controllers
{
    public class PhieuDCsController : Controller
    {
        private CNPMEntities db = new CNPMEntities();

        // GET: PhieuDCs
        public ActionResult Index()
        {
            var phieuDCs = db.PhieuDCs.Include(p => p.KhachHang).Include(p => p.PacketTour).Include(p => p.PhuongThucThanhToan);
            return View(phieuDCs.ToList());
        }

        // GET: PhieuDCs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuDC phieuDC = db.PhieuDCs.Find(id);
            if (phieuDC == null)
            {
                return HttpNotFound();
            }
            return View(phieuDC);
        }

        // GET: PhieuDCs/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH");
            ViewBag.MaPT = new SelectList(db.PacketTours, "MaPT", "MaTour");
            ViewBag.MaPTTT = new SelectList(db.PhuongThucThanhToans, "MaPTTT", "TenPTTT");
            return View();
        }

        // POST: PhieuDCs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDC,MaKH,MaPT,MaPTTT,NgayDatCho,Ngaythamquan,TenKH,SDTKH,EmailKH,YCThem,PickUp,Invoice,SLAdult,SLChild")] PhieuDC phieuDC)
        {
            if (ModelState.IsValid)
            {
                db.PhieuDCs.Add(phieuDC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH", phieuDC.MaKH);
            ViewBag.MaPT = new SelectList(db.PacketTours, "MaPT", "MaTour", phieuDC.MaPT);
            ViewBag.MaPTTT = new SelectList(db.PhuongThucThanhToans, "MaPTTT", "TenPTTT", phieuDC.MaPTTT);
            return View(phieuDC);
        }

        // GET: PhieuDCs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuDC phieuDC = db.PhieuDCs.Find(id);
            if (phieuDC == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH", phieuDC.MaKH);
            ViewBag.MaPT = new SelectList(db.PacketTours, "MaPT", "MaTour", phieuDC.MaPT);
            ViewBag.MaPTTT = new SelectList(db.PhuongThucThanhToans, "MaPTTT", "TenPTTT", phieuDC.MaPTTT);
            return View(phieuDC);
        }

        // POST: PhieuDCs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDC,MaKH,MaPT,MaPTTT,NgayDatCho,Ngaythamquan,TenKH,SDTKH,EmailKH,YCThem,PickUp,Invoice,SLAdult,SLChild")] PhieuDC phieuDC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuDC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH", phieuDC.MaKH);
            ViewBag.MaPT = new SelectList(db.PacketTours, "MaPT", "MaTour", phieuDC.MaPT);
            ViewBag.MaPTTT = new SelectList(db.PhuongThucThanhToans, "MaPTTT", "TenPTTT", phieuDC.MaPTTT);
            return View(phieuDC);
        }

        // GET: PhieuDCs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuDC phieuDC = db.PhieuDCs.Find(id);
            if (phieuDC == null)
            {
                return HttpNotFound();
            }
            return View(phieuDC);
        }

        // POST: PhieuDCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PhieuDC phieuDC = db.PhieuDCs.Find(id);
            db.PhieuDCs.Remove(phieuDC);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
