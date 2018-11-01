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
    public class BoekettenController : Controller
    {
        private FlowerpowerEntities db = new FlowerpowerEntities();

        // GET: Boeketten
        public ActionResult Index()
        {
            return View(db.producten.ToList());
        }

        // GET: Boeketten/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producten producten = db.producten.Find(id);
            if (producten == null)
            {
                return HttpNotFound();
            }
            return View(producten);
        }

        // GET: Boeketten/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Boeketten/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "productid,productnaam,prijs,productomschrijving,gearchiveerd, url")] producten producten)
        {
            if (ModelState.IsValid)
            {
                db.producten.Add(producten);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(producten);
        }

        // GET: Boeketten/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producten producten = db.producten.Find(id);
            if (producten == null)
            {
                return HttpNotFound();
            }
            return View(producten);
        }

        // POST: Boeketten/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "productid,productnaam,prijs,productomschrijving,gearchiveerd, url")] producten producten)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producten).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producten);
        }

        // GET: Boeketten/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producten producten = db.producten.Find(id);
            if (producten == null)
            {
                return HttpNotFound();
            }
            return View(producten);
        }

        // POST: Boeketten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            producten producten = db.producten.Find(id);
            db.producten.Remove(producten);
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
