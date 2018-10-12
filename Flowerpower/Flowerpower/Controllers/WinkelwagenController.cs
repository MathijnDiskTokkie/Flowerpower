using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Flowerpower.Models;

namespace FlowerPower.Controllers
{
    public class CartController : Controller
    {
        FlowerpowerEntities db = new FlowerpowerEntities();

        private List<producten> shoppingCartList = new List<producten>();

        // GET: Cart
        public ActionResult Index()
        {
            shoppingCartList.OrderByDescending(s => s.prijs);

            return View(shoppingCartList);
        }
    }
}