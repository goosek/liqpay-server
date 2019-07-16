using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiqPayServer.Models
{
    public class LiqPaySubData: LiqPayData,ILiqPayData
    {
        
        public decimal subscribe { get; set; }
        public string subscribe_date_start { get; set; }
        public string subscribe_periodicity { get; set; }
    }
}