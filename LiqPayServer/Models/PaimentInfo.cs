using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiqPayServer.Models
{
    public class PaimentInfo
    {
        public decimal? TheBiggestContribution { get; set; }
        public decimal? LastContribution { get; set; }
    }
}