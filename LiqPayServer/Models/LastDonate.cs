using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiqPayServer.Models
{
    public class LastDonate
    {
        public string Name { get; set; }
        public decimal? Sum { get; set; }
        public int index { get; set; }
    }
}