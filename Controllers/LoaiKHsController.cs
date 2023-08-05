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
    public class LoaiKHsController : Controller
    {
        private CNPMEntities db = new CNPMEntities();

        // GET: LoaiKHs
        public ActionResult Index()
        {
            return View(db.LoaiKHs.ToList());
        }

        // GET: LoaiKHs/Details/5
        public ActionResult Details(string id)
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

        // GET: LoaiKHs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiKHs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLKH,LoaiKH1")] LoaiKH loaiKH)
        {
            if (ModelState.IsValid)
            {
                db.LoaiKHs.Add(loaiKH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiKH);
        }

        // GET: LoaiKHs/Edit/5
        public ActionResult Edit(string id)
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

        // POST: LoaiKHs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLKH,LoaiKH1")] LoaiKH loaiKH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiKH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiKH);
        }

        // GET: LoaiKHs/Delete/5
        public ActionResult Delete(string id)
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

        // POST: LoaiKHs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LoaiKH loaiKH = db.LoaiKHs.Find(id);
            db.LoaiKHs.Remove(loaiKH);
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
