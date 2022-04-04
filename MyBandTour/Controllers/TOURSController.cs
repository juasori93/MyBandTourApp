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
    public class TOURSController : Controller
    {
        private myBandTourEntities db = new myBandTourEntities();

        // GET: TOURS
        public ActionResult Index()
        {
            var tOURS = db.TOURS.Include(t => t.BANDA1);
            return View(tOURS.ToList());
        }

        // GET: TOURS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TOUR tOUR = db.TOURS.Find(id);
            if (tOUR == null)
            {
                return HttpNotFound();
            }
            return View(tOUR);
        }

        // GET: TOURS/Create
        public ActionResult Create()
        {
            ViewBag.BANDA = new SelectList(db.BANDAS, "IDBANDA", "BANDA1");
            return View();
        }

        // POST: TOURS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BANDA,PAIS,LUGAR,GENERO,FECHA,LUGARCOMPRA")] TOUR tOUR)
        {
            if (ModelState.IsValid)
            {
                db.TOURS.Add(tOUR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BANDA = new SelectList(db.BANDAS, "IDBANDA", "BANDA1", tOUR.BANDA);
            return View(tOUR);
        }

        // GET: TOURS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TOUR tOUR = db.TOURS.Find(id);
            if (tOUR == null)
            {
                return HttpNotFound();
            }
            ViewBag.BANDA = new SelectList(db.BANDAS, "IDBANDA", "BANDA1", tOUR.BANDA);
            return View(tOUR);
        }

        // POST: TOURS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BANDA,PAIS,LUGAR,GENERO,FECHA,LUGARCOMPRA")] TOUR tOUR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tOUR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BANDA = new SelectList(db.BANDAS, "IDBANDA", "BANDA1", tOUR.BANDA);
            return View(tOUR);
        }

        // GET: TOURS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TOUR tOUR = db.TOURS.Find(id);
            if (tOUR == null)
            {
                return HttpNotFound();
            }
            return View(tOUR);
        }

        // POST: TOURS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TOUR tOUR = db.TOURS.Find(id);
            db.TOURS.Remove(tOUR);
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
