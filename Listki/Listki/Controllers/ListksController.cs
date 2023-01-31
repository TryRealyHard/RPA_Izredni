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
    public class ListksController : Controller
    {
        private ListkiContext db = new ListkiContext();

        // GET: Listks
        public ActionResult Index()
        {
            var listks = db.Listks.Include(l => l.Uporabniki);
            return View(listks.ToList());
        }

        // GET: Listks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listk listk = db.Listks.Find(id);
            if (listk == null)
            {
                return HttpNotFound();
            }
            return View(listk);
        }

        // GET: Listks/Create
        public ActionResult Create()
        {
            ViewBag.UporabnikiId = new SelectList(db.Uporabnikis, "Id", "Ime");
            return View();
        }

        // POST: Listks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UporabnikiId,Naslov,Vsebina,Datum_kreiranja")] Listk listk)
        {
            if (ModelState.IsValid)
            {
                db.Listks.Add(listk);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UporabnikiId = new SelectList(db.Uporabnikis, "Id", "Ime", listk.UporabnikiId);
            return View(listk);
        }

        // GET: Listks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listk listk = db.Listks.Find(id);
            if (listk == null)
            {
                return HttpNotFound();
            }
            ViewBag.UporabnikiId = new SelectList(db.Uporabnikis, "Id", "Ime", listk.UporabnikiId);
            return View(listk);
        }

        // POST: Listks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UporabnikiId,Naslov,Vsebina,Datum_kreiranja")] Listk listk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UporabnikiId = new SelectList(db.Uporabnikis, "Id", "Ime", listk.UporabnikiId);
            return View(listk);
        }

        // GET: Listks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listk listk = db.Listks.Find(id);
            if (listk == null)
            {
                return HttpNotFound();
            }
            return View(listk);
        }

        // POST: Listks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Listk listk = db.Listks.Find(id);
            db.Listks.Remove(listk);
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
