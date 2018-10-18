public class WinkelwagenController : Controller
{
    FlowerpowerEntities db = new FlowerpowerEntities();

    //private List<winkelmand> shoppingCartList = new List<winkelmand>();



    // GET: Cart
    public ActionResult Index(int productid, int winkelid)
    {
        int klantid = (from i in db.klant where i.email == User.Identity.Name select i.klantid).FirstOrDefault();

        if (klantid != 0)
        {
                / int bestellingid = ((from i in db.bestelling select i).OrderByDescending(x => x.bestellingid).FirstOrDefault().bestellingid) + 1;/

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
                else
                {

                    winkelmand wk = new winkelmand();
                    wk.productid = productid;
                    wk.aantal = 1;
                    wk.bestellingid = Convert.ToInt16(cookie.Value);

                    db.winkelmand.Add(wk);

                }

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

                winkelmand wk = new winkelmand();
                wk.productid = productid;
                wk.aantal = 1;
                wk.bestellingid = bes.bestellingid;


                db.winkelmand.Add(wk);
                db.SaveChanges();

                HttpCookie cookie1 = new HttpCookie("Winkelmand");
                cookie1.Value = "" + bes.bestellingid; // bestelling id
                HttpContext.Response.SetCookie(cookie1);

                List<winkelmand> winkelwagen = (from i in db.winkelmand where i.bestellingid == bes.bestellingid select i).ToList();

                foreach (var item in winkelwagen)
                {

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

        }
        else
        {

            RedirectToAction("Register", "Account", null);
        }

        return null;

    }

    [HttpPost]
    public ActionResult Index(List<Flowerpower.Models.winkelmand> model)
    {

        HttpCookie cookie = HttpContext.Request.Cookies.Get("Winkelmand");
        int bestellingid = Convert.ToInt16(cookie.Value);

        var dd = from i in db.bestelling where i.bestellingid == bestellingid select i;

        for (int i = 0; i < model.Count; i++)
        {
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
            return RedirectToAction("Afronden", "Winkelwagen", new { bestelid = bestelling.bestellingid });


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
            byte[] stream = factuur.GenerateInvoice(bestelling);

            return File(stream, "application/pdf", "FlowerpowerFactuur" + bestelidd + ".pdf");
            //return View((from i in db.bestelling where i.bestellingid == bestelid select i).FirstOrDefault());



        }
        catch (Exception ex)
        {

            return View();
        }

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
        }

        return item;

    }


}

    }