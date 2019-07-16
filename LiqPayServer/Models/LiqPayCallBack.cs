using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiqPayServer.Models
{
    public class LiqPayCallBack
    {
        public string data { get; set; }
        public string signature { get; set; }
    }
}