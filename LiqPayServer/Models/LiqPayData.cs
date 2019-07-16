﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiqPayServer.Models
{
    public class LiqPayData: ILiqPayData
    {
       public string public_key { get; set; }
        public string version { get; set; }
        public string action { get; set; }
        public decimal amount { get; set; }
        public string currency { get; set; }
        public string description { get; set; }
        public string order_id { get; set; }
        public string result_url { get; set; }
        public string server_url { get; set; }
        public int sandbox { get; set; }
    }
}