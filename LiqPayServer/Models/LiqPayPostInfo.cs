using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiqPayServer.Models
{
    public class LiqPayPostInfo
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal Amount { get; set; }
        public bool IsSubscribe { get; set; }
        public string TypeOfPayer { get; set; }
    }
}