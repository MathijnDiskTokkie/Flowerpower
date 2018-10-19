using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Flowerpower.Models;


namespace FlowerPower.Controllers
{
    public class WinkelwagenController : Controller
    {
        FlowerpowerEntities db = new FlowerpowerEntities();

        //private List<winkelmand> shoppingCartList = new List<winkelmand>();
        //public ActionResult deleteItem(int? productid) {

<<<<<<< HEAD
        //    return RedirectToAction("Index","Home");
        //}

=======
      
>>>>>>> parent of 0a538ef... mooiste update van je welkomst

        // GET: Cart
        public ActionResult Index(int productid , int winkelid)
        {
            int klantid = (from i in db.klant where i.email == User.Identity.Name select i.klantid).FirstOrDefault();

            if (klantid != 0)
            {
                /*int bestellingid = ((from i in db.bestelling select i).OrderByDescending(x => x.bestellingid).FirstOrDefault().bestellingid)+1;*/

                //int last = db.bestelling.Count() == 0 ? 0 : db.bestelling.OrderByDescending(b => b.bestellingid).First().bestellingid + 1;

                //var w = from i in db.winkelmand where i.bestellingid == last select i;

                HttpCookie cookie = HttpContext.Request.Cookies.Get("Winkelmand");
<<<<<<< HEAD
                if (productid != 0 && winkelid != 0)
                {

                    if (cookie != null)
=======
               

                if (cookie != null)
                {

                    int bestll = Convert.ToInt16(cookie.Value);

                    var aant = from i in db.winkelmand where i.bestellingid == bestll && i.productid == productid select i;
                    if (aant.Any())
>>>>>>> parent of 0a538ef... mooiste update van je welkomst
                    {
                        int nieuwe = (int)(aant.FirstOrDefault().aantal) + 1;
                        aant.FirstOrDefault().aantal = nieuwe;
                        db.SaveChanges();
                    }
                    else
                    {

                        winkelmand wk = new winkelmand();
                        wk.productid = productid;
                        wk.aantal = 1;
                        wk.bestellingid = Convert.ToInt16(cookie.Value);

                        db.winkelmand.Add(wk);

<<<<<<< HEAD
                        HttpCookie cookie1 = new HttpCookie("Winkelmand");
                        cookie1.Value = "" + bes.bestellingid; // bestelling id
                        HttpContext.Response.SetCookie(cookie1);
=======
                    }
>>>>>>> parent of 0a538ef... mooiste update van je welkomst

                    db.SaveChanges();

                }
                else
                {

                    bestelling bes = new bestelling();
                    bes.winkel_winkelcode = winkelid;
                    bes.winkelcode = winkelid;
                    bes.klant_klantid = klantid;
                    bes.bestellinggeplaatst = DateTime.Today;
                    db.bestelling.Add(bes);
                    db.SaveChanges();

<<<<<<< HEAD
=======
                    winkelmand wk = new winkelmand();
                    wk.productid = productid;
                    wk.aantal = 1;
                    wk.bestellingid = bes.bestellingid;

>>>>>>> parent of 0a538ef... mooiste update van je welkomst

                    db.winkelmand.Add(wk);
                    db.SaveChanges();

<<<<<<< HEAD
                        return View(winkelwagen);
=======
                    HttpCookie cookie1 = new HttpCookie("Winkelmand");
                    cookie1.Value = "" + bes.bestellingid; // bestelling id
                    HttpContext.Response.SetCookie(cookie1);
>>>>>>> parent of 0a538ef... mooiste update van je welkomst

                    List<winkelmand> winkelwagen = (from i in db.winkelmand where i.bestellingid == bes.bestellingid select i).ToList();

                    foreach (var item in winkelwagen)
                    {
<<<<<<< HEAD
                        int bestllj = Convert.ToInt16(cookie.Value);
                        List<winkelmand> winkelwagen = (from i in db.winkelmand where i.bestellingid == bestllj select i).ToList();
=======

                        item.producten = (from i in db.producten where i.productid == item.productid select i).FirstOrDefault();
                    }
>>>>>>> parent of 0a538ef... mooiste update van je welkomst



<<<<<<< HEAD
                        return View(winkelwagen);

                    }

=======
                    return View(winkelwagen);


>>>>>>> parent of 0a538ef... mooiste update van je welkomst
                }
                if (cookie != null)
                {
<<<<<<< HEAD

                    HttpCookie cookies = HttpContext.Request.Cookies.Get("Winkelmand");

                    if (cookies != null)
                    {
                        int bestllj = Convert.ToInt16(cookies.Value);
                        List<winkelmand> winkelwagen = (from i in db.winkelmand where i.bestellingid == bestllj select i).ToList();

                        foreach (var item in winkelwagen)
                        {

                            item.producten = (from i in db.producten where i.productid == item.productid select i).FirstOrDefault();
                        }

                        return View(winkelwagen);

                    }
                    else
                    {
                        return Content("<script language='javascript' type='text/javascript'>alert('Winkelmand is leeg');window.location = '/Home/Index';</script>");
                    }
=======
                    int bestllj = Convert.ToInt16(cookie.Value);
                    List<winkelmand> winkelwagen = (from i in db.winkelmand where i.bestellingid == bestllj select i).ToList();

                    foreach (var item in winkelwagen)
                    {

                        item.producten = (from i in db.producten where i.productid == item.productid select i).FirstOrDefault();
                    }

                    return View(winkelwagen);
>>>>>>> parent of 0a538ef... mooiste update van je welkomst

                }
            }
            else
            {

<<<<<<< HEAD
                return RedirectToAction("Register", "Account", null);
            }

            return null;

        }

        [HttpPost]
        public ActionResult Index(List<Flowerpower.Models.winkelmand> model)
        {
=======
                RedirectToAction("Register", "Account", null);            }

            return null;
            
        }

        [HttpPost]
        public ActionResult Index(List<Flowerpower.Models.winkelmand> model) {
>>>>>>> parent of 0a538ef... mooiste update van je welkomst

            HttpCookie cookie = HttpContext.Request.Cookies.Get("Winkelmand");
            int bestellingid = Convert.ToInt16(cookie.Value);

            var dd = from i in db.bestelling where i.bestellingid == bestellingid select i;

<<<<<<< HEAD
            for (int i = 0; i < model.Count; i++)
            {
=======
            for (int  i = 0; i < model.Count; i++) {
>>>>>>> parent of 0a538ef... mooiste update van je welkomst
                dd.FirstOrDefault().winkelmand.ElementAt(i).aantal = model[i].aantal;
            }

            db.SaveChanges();



            return RedirectToAction("");
        }



        public ActionResult PlaatsDatumKiezen(int bestelid)
        {

            PlaatsDatumModel model = new PlaatsDatumModel();
            var bestelling = from i in db.bestelling where i.bestellingid == bestelid select i;
            model.bestellingid = bestelling.FirstOrDefault().bestellingid;
            model.winkels = PopulateWinkels();

            return View(model);

        }

        [HttpPost]
        public ActionResult PlaatsDatumKiezen(PlaatsDatumModel model)
        {

            //update
            
            model.winkels = PopulateWinkels();
            var selectedItem = model.winkels.Find(p => p.Value == model.Winkelcode.ToString());
            if (selectedItem != null)
            {
                selectedItem.Selected = true;


                var bestelling = (from i in db.bestelling where i.bestellingid == model.bestellingid select i).FirstOrDefault();
                bestelling.bestellinggeplaatst = model.datumgekozen;
                bestelling.winkelcode = model.Winkelcode;
                db.SaveChanges();

                //return RedirectToAction("AfrondenFile", "Winkelwagen", new { bestelid = bestelling.bestellingid });
                return RedirectToAction("Afronden","Winkelwagen", new {bestelid = bestelling.bestellingid });


            }

            return View(model);
        }


        public ActionResult AfrondenFile(string bestelidd)
        {

            int bestelid = Convert.ToInt16(bestelidd);
            try
            {
                var bestelling = (from i in db.bestelling where i.bestellingid == bestelid select i).FirstOrDefault();

                if (Request.Cookies["Winkelmand"] != null)
                {

                    var c = new HttpCookie("Winkelmand");
                    c.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(c);
                }
                // factuur uitdraaien

                Flowerpower.Functions.Factuur factuur = new Flowerpower.Functions.Factuur();
                byte[] stream= factuur.GenerateInvoice(bestelling);
      
                return File(stream, "application/pdf", "FlowerpowerFactuur"+bestelidd+".pdf");
                //return View((from i in db.bestelling where i.bestellingid == bestelid select i).FirstOrDefault());

                

            }
<<<<<<< HEAD
            winkelmand winkelmand = db.winkelmand.Find(id);
            if ( winkelmand == null)
            {
                return HttpNotFound();
            }
            return View(winkelmand);
        }

        // POST: Boeketten/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
      /*  [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "aantal")] winkelmand winkelmand)
        {
            if (ModelState.IsValid)
            {
                db.Entry(winkelmand).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(winkelmand);
        }
        */
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
=======
            catch (Exception ex) {

                return View();
            }
<<<<<<< HEAD

        }





        public ActionResult Afronden(int? bestelid)
        {

            var bestelling = from i in db.bestelling where i.bestellingid == bestelid select i;
            return View(bestelling.FirstOrDefault());

        }


        public List<SelectListItem> PopulateWinkels()
        {

            List<SelectListItem> item = new List<SelectListItem>();
            var winkels = (from i in db.winkel select i).ToList();

            foreach (var its in winkels)
            {

                item.Add(new SelectListItem
                {

                    Text = its.winkelstad,
                    Value = its.winkelcode.ToString()



                });
=======
        }


        public ActionResult Afronden(int? bestelid) {

            var bestelling = from i in db.bestelling where i.bestellingid == bestelid select i;
            return View(bestelling.FirstOrDefault());

        }


        public List<SelectListItem> PopulateWinkels() {

            List<SelectListItem> item = new List<SelectListItem>();
            var winkels = (from i in db.winkel select i).ToList();

            foreach (var its in winkels) {

                item.Add(new SelectListItem {

                    Text = its.winkelstad,
                    Value = its.winkelcode.ToString()
                    


                });
>>>>>>> ebdec68977a5cc72f1868b0e11742d78600dd19c
>>>>>>> parent of 0a538ef... mooiste update van je welkomst
            }

            return item;

        }


    }
<<<<<<< HEAD

=======
   
>>>>>>> parent of 0a538ef... mooiste update van je welkomst
}