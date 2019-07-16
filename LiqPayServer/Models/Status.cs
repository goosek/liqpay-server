using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiqPayServer.Models
{
    public class Status
    {
        public string public_key { get; set; }
        public string action { get; set; }
        public string version { get; set; }
        public string order_id { get; set; }   
    }
}