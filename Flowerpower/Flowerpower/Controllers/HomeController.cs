﻿using Flowerpower.Models;
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
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}