using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyBandTour.Models;

namespace MyBandTour.Controllers
{
    public class BANDASController : Controller
    {
        private myBandTourEntities db = new myBandTourEntities();

        // GET: BANDAS
        public ActionResult Index()
        {
            return View(db.BANDAS.ToList());
        }

        // GET: BANDAS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BANDA bANDA = db.BANDAS.Find(id);
            if (bANDA == null)
            {
                return HttpNotFound();
            }
            return View(bANDA);
        }

        // GET: BANDAS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BANDAS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDBANDA,BANDA1")] BANDA bANDA)
        {
            if (ModelState.IsValid)
            {
                db.BANDAS.Add(bANDA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bANDA);
        }

        // GET: BANDAS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BANDA bANDA = db.BANDAS.Find(id);
            if (bANDA == null)
            {
                return HttpNotFound();
            }
            return View(bANDA);
        }

        // POST: BANDAS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDBANDA,BANDA1")] BANDA bANDA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bANDA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bANDA);
        }

        // GET: BANDAS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BANDA bANDA = db.BANDAS.Find(id);
            if (bANDA == null)
            {
                return HttpNotFound();
            }
            return View(bANDA);
        }

        // POST: BANDAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BANDA bANDA = db.BANDAS.Find(id);
            db.BANDAS.Remove(bANDA);
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
