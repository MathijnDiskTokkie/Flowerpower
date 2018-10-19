using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flowerpower.Models
{
    public class Winkelwagen
    {
        public List<winkelmand> winkelwagen { get; set; }
        public decimal totaal { get; set; }
        public bool directwinkelwagen { get; set; }
    }
}