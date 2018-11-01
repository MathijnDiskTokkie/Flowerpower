using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Flowerpower.Models
{
    public class PlaatsDatumModel
    {
        public List<SelectListItem> winkels { get; set; }
        public int? Winkelcode { get; set; }
        public DateTime datumgekozen { get; set; }
        public int bestellingid { get; set; }


    }
}