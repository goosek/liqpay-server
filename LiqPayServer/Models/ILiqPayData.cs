using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiqPayServer.Models
{
    public interface ILiqPayData
    {
         string public_key { get; set; }
         string version { get; set; }
         string action { get; set; }
         decimal amount { get; set; }
         string currency { get; set; }
         string description { get; set; }
         string order_id { get; set; }
         string result_url { get; set; }
         string server_url { get; set; }
         int sandbox { get; set; }
    }
}