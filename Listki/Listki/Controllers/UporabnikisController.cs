using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Listki.Data;
using Listki.Models;

namespace Listki.Controllers
{
    public class UporabnikisController : Controller
    {
        private ListkiContext db = new ListkiContext();

        // GET: Uporabnikis
        public ActionResult Index()
        {
            return View(db.Uporabnikis.ToList());
        }

        // GET: Uporabnikis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uporabniki uporabniki = db.Uporabnikis.Find(id);
            if (uporabniki == null)
            {
                return HttpNotFound();
            }
            return View(uporabniki);
        }

        // GET: Uporabnikis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Uporabnikis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ime,Priimek,Uporabnisko,Geslo,Email")] Uporabniki uporabniki)
        {
            if (ModelState.IsValid)
            {
                db.Uporabnikis.Add(uporabniki);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uporabniki);
        }

        // GET: Uporabnikis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uporabniki uporabniki = db.Uporabnikis.Find(id);
            if (uporabniki == null)
            {
                return HttpNotFound();
            }
            return View(uporabniki);
        }

        // POST: Uporabnikis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ime,Priimek,Uporabnisko,Geslo,Email")] Uporabniki uporabniki)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uporabniki).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uporabniki);
        }

        // GET: Uporabnikis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uporabniki uporabniki = db.Uporabnikis.Find(id);
            if (uporabniki == null)
            {
                return HttpNotFound();
            }
            return View(uporabniki);
        }

        // POST: Uporabnikis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Uporabniki uporabniki = db.Uporabnikis.Find(id);
            db.Uporabnikis.Remove(uporabniki);
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
