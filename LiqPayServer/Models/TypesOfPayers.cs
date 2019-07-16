using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace LiqPayServer.Models
{
    public enum TypesOfPayers
    {
        [StringValue("Benefactors")]
        Benefactors = 1,
        [StringValue("Graduates")]
        Graduates = 2,
        [StringValue("Parents")]
        Parents = 3
    }

    public class StringValueAttribute : System.Attribute
    {

        private string _value;

        public StringValueAttribute(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }

    }
}