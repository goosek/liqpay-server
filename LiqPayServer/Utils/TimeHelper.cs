using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiqPayServer.Utils
{
    public class TimeHelper
    {
        const string _TIME_ZONE = "FLE Standard Time";
        public static DateTime GetUkTime()
        {
            TimeZoneInfo est;
            try
            {
                est = TimeZoneInfo.FindSystemTimeZoneById(_TIME_ZONE);
            }
            catch (TimeZoneNotFoundException)
            {
                return DateTime.Now;
            }
            var timeToConvert = DateTime.Now;

            return TimeZoneInfo.ConvertTime(timeToConvert, est);
        }
    }
}