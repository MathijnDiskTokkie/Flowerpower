using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Flowerpower.Models;

namespace FlowerPower.Controllers
{
    public class WinkelwagenController : Controller
    {
        FlowerpowerEntities db = new FlowerpowerEntities();

        //private List<winkelmand> shoppingCartList = new List<winkelmand>();

        // GET: Cart
        public ActionResult Index(int productid , int winkelid)
        {

            

            int klantid = (from i in db.klant where i.email == User.Identity.Name select i.klantid).FirstOrDefault();


            /*int bestellingid = ((from i in db.bestelling select i).OrderByDescending(x => x.bestellingid).FirstOrDefault().bestellingid)+1;*/

            //int last = db.bestelling.Count() == 0 ? 0 : db.bestelling.OrderByDescending(b => b.bestellingid).First().bestellingid + 1;

            //var w = from i in db.winkelmand where i.bestellingid == last select i;

            HttpCookie cookie = HttpContext.Request.Cookies.Get("Winkelmand");





            if (cookie != null)
            {

                int bestll = Convert.ToInt16(cookie.Value);

                var aant = from i in db.winkelmand where i.bestellingid == bestll && i.productid == productid select i;
                if (aant.Any())
                {
                    int nieuwe = (int)(aant.FirstOrDefault().aantal) + 1;
                    aant.FirstOrDefault().aantal = nieuwe;
                    db.SaveChanges();
                }
                else {

                    winkelmand wk = new winkelmand();
                    wk.productid = productid;
                    wk.aantal = 1;
                    wk.bestellingid = Convert.ToInt16(cookie.Value);

                    db.winkelmand.Add(wk);

                }

                db.SaveChanges();

            }
            else {

                bestelling bes = new bestelling();
                bes.winkel_winkelcode = winkelid;
                bes.winkelcode = winkelid;
                bes.klant_klantid = klantid;
                db.bestelling.Add(bes);
                db.SaveChanges();

                winkelmand wk = new winkelmand();
                wk.productid = productid;
                wk.aantal = 1;
                wk.bestellingid = bes.bestellingid;


                db.winkelmand.Add(wk);
                db.SaveChanges();

                HttpCookie cookie1 = new HttpCookie("Winkelmand");
                cookie1.Value = ""+bes.bestellingid; // bestelling id
                HttpContext.Response.SetCookie(cookie1);

                List<winkelmand> winkelwagen = (from i in db.winkelmand where i.bestellingid == bes.bestellingid select i).ToList();

                foreach (var item in winkelwagen) {

                    item.producten = (from i in db.producten where i.productid == item.productid select i).FirstOrDefault();
                }



                return View(winkelwagen);


            }
            if (cookie != null)
            {
                int bestllj = Convert.ToInt16(cookie.Value);
                List<winkelmand> winkelwagen = (from i in db.winkelmand where i.bestellingid == bestllj select i).ToList();

                foreach (var item in winkelwagen)
                {

                    item.producten = (from i in db.producten where i.productid == item.productid select i).FirstOrDefault();
                }

                return View(winkelwagen);

            }

            return null;
            
        }



        public ActionResult PlaatsDatumKiezen() {
            return View();

        }



        public ActionResult Afronden(DateTime gekozen)
        {
            HttpCookie cookie = HttpContext.Request.Cookies.Get("Winkelmand");
            int bestellingid = Convert.ToInt16(cookie.Value);





            HttpContext.Response.Cookies.Remove("Winkelwagen");


            return View();
        }

        //[HttpPost]
        //public ActionResult Delete(int id)
        //{
        //    winkelmand winkelmand = new winkelmand();
        //    winkelmand.Deleteproduct(id);
        //    return RedirectToAction("Winkelwagen");
        //}



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
        public ActionResult Edit([Bind(Include = "productid,productnaam,prijs,productomschrijving,gearchiveerd")] producten producten)
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

    }
   
}