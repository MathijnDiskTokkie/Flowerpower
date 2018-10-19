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
    public class bestellingsController : Controller
    {
        private FlowerpowerEntities db = new FlowerpowerEntities();

        // GET: bestellings

     
        

        public ActionResult Index()
        {




            var bestelling = db.bestelling.Include(b => b.klant).Include(b => b.medewerkers).Include(b => b.winkel);
            return View(bestelling.ToList());
        }

        // GET: bestellings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bestelling bestelling = db.bestelling.Find(id);
            if (bestelling == null)
            {
                return HttpNotFound();
            }
            return View(bestelling);
        }

        // GET: bestellings/Create
        public ActionResult Create()
        {
            ViewBag.klant_klantid = new SelectList(db.klant, "klantid", "naam");
            ViewBag.afgehandelddoor = new SelectList(db.medewerkers, "medewerkerid", "medewerkernaam");
            ViewBag.winkel_winkelcode = new SelectList(db.winkel, "winkelcode", "winkelnaam");
            return View();
        }

        // POST: bestellings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "bestellingid,winkelcode,klantcode,afgehandelddoor,bestellinggeplaatst,klant_klantid,winkel_winkelcode")] bestelling bestelling)
        {
            if (ModelState.IsValid)
            {
                db.bestelling.Add(bestelling);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.klant_klantid = new SelectList(db.klant, "klantid", "naam", bestelling.klant_klantid);
            ViewBag.afgehandelddoor = new SelectList(db.medewerkers, "medewerkerid", "medewerkernaam", bestelling.afgehandelddoor);
            ViewBag.winkel_winkelcode = new SelectList(db.winkel, "winkelcode", "winkelnaam", bestelling.winkel_winkelcode);
            return View(bestelling);
        }

        // GET: bestellings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bestelling bestelling = db.bestelling.Find(id);
            if (bestelling == null)
            {
                return HttpNotFound();
            }
            ViewBag.klant_klantid = new SelectList(db.klant, "klantid", "naam", bestelling.klant_klantid);
            ViewBag.afgehandelddoor = new SelectList(db.medewerkers, "medewerkerid", "medewerkernaam", bestelling.afgehandelddoor);
            ViewBag.winkel_winkelcode = new SelectList(db.winkel, "winkelcode", "winkelnaam", bestelling.winkel_winkelcode);
            return View(bestelling);
        }
        // POST: bestellings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "bestellingid,winkelcode,klantcode,afgehandelddoor,bestellinggeplaatst,klant_klantid,winkel_winkelcode")] bestelling bestelling)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bestelling).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.klant_klantid = new SelectList(db.klant, "klantid", "naam", bestelling.klant_klantid);
            ViewBag.afgehandelddoor = new SelectList(db.medewerkers, "medewerkerid", "medewerkernaam", bestelling.afgehandelddoor);
            ViewBag.winkel_winkelcode = new SelectList(db.winkel, "winkelcode", "winkelnaam", bestelling.winkel_winkelcode);
            return View(bestelling);
        }

        // GET: bestellings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bestelling bestelling = db.bestelling.Find(id);
            if (bestelling == null)
            {
                return HttpNotFound();
            }
            return View(bestelling);
        }

        // POST: bestellings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bestelling bestelling = db.bestelling.Find(id);
            db.bestelling.Remove(bestelling);
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
