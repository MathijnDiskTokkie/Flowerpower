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
    [Authorize(Roles = "Manager")]
    public class winkelsController : Controller
    {
        private FlowerpowerEntities db = new FlowerpowerEntities();

        // GET: winkels
        public ActionResult Index()
        {
            return View(db.winkel.ToList());
        }

        // GET: winkels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            winkel winkel = db.winkel.Find(id);
            if (winkel == null)
            {
                return HttpNotFound();
            }
            return View(winkel);
        }

        // GET: winkels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: winkels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "winkelcode,winkelnaam,winkelstraatnaam,winkelpostcode,winkelstad,winkeltelefoonnummer,winkelmail,winkelactief")] winkel winkel)
        {
            if (ModelState.IsValid)
            {
                db.winkel.Add(winkel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(winkel);
        }

        // GET: winkels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            winkel winkel = db.winkel.Find(id);
            if (winkel == null)
            {
                return HttpNotFound();
            }
            return View(winkel);
        }

        // POST: winkels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "winkelcode,winkelnaam,winkelstraatnaam,winkelpostcode,winkelstad,winkeltelefoonnummer,winkelmail,winkelactief")] winkel winkel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(winkel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(winkel);
        }

        // GET: winkels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            winkel winkel = db.winkel.Find(id);
            if (winkel == null)
            {
                return HttpNotFound();
            }
            return View(winkel);
        }

        // POST: winkels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            winkel winkel = db.winkel.Find(id);
            db.winkel.Remove(winkel);
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
