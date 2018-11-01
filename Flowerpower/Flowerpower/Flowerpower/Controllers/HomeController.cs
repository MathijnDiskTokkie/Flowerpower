using Flowerpower.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Flowerpower.Controllers
{
    public class HomeController : Controller
    {

        FlowerpowerEntities db = new FlowerpowerEntities();


        public ActionResult Index()
        {

            List<producten> listboek = new List<producten>();
            listboek = (from i in db.producten where i.gearchiveerd == true select i).ToList();
            return View(listboek);
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {
            List<winkel> Winkels = new List<winkel>();
            Winkels = (from i in db.winkel where i.winkelactief == true select i).ToList();
            return View(Winkels);
        }
    }
}