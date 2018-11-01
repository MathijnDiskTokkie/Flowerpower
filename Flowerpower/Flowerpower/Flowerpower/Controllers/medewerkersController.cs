using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Flowerpower.Models;

namespace Flowerpower.Controllers
{
    public class medewerkersController : Controller
    {
        private FlowerpowerEntities db = new FlowerpowerEntities();

        // GET: medewerkers
        public ActionResult Index()
        {
            var medewerkers = db.medewerkers.Include(m => m.winkel);
            return View(medewerkers.ToList());
        }

        // GET: medewerkers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medewerkers medewerkers = db.medewerkers.Find(id);
            if (medewerkers == null)
            {
                return HttpNotFound();
            }
            return View(medewerkers);
        }

        // GET: medewerkers/Create
        public ActionResult Create()
        {
            ViewBag.winkelcode = new SelectList(db.winkel, "winkelcode", "winkelnaam");
            return View();
        }

        // POST: medewerkers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "medewerkerid,medewerkernaam,medewerkerachternaam,winkelcode")] medewerkers medewerkers)
        {
            if (ModelState.IsValid)
            {
                db.medewerkers.Add(medewerkers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.winkelcode = new SelectList(db.winkel, "winkelcode", "winkelnaam", medewerkers.winkelcode);
            return View(medewerkers);
        }

        // GET: medewerkers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medewerkers medewerkers = db.medewerkers.Find(id);
            if (medewerkers == null)
            {
                return HttpNotFound();
            }
            ViewBag.winkelcode = new SelectList(db.winkel, "winkelcode", "winkelnaam", medewerkers.winkelcode);
            return View(medewerkers);
        }

        // POST: medewerkers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "medewerkerid,medewerkernaam,medewerkerachternaam,winkelcode")] medewerkers medewerkers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medewerkers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.winkelcode = new SelectList(db.winkel, "winkelcode", "winkelnaam", medewerkers.winkelcode);
            return View(medewerkers);
        }

        // GET: medewerkers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medewerkers medewerkers = db.medewerkers.Find(id);
            if (medewerkers == null)
            {
                return HttpNotFound();
            }
            return View(medewerkers);
        }

        // POST: medewerkers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            medewerkers medewerkers = db.medewerkers.Find(id);
            db.medewerkers.Remove(medewerkers);
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
