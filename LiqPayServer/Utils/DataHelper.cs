using LiqPayServer.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace LiqPayServer.Utils
{
    public class DataHelper
    {
        public static ILiqPayData CreateLiqPayData(LiqPayPostInfo liqPayInfo,string publicKey, string serverUrl) {
            ILiqPayData liqPayData;
            var orderId = Guid.NewGuid().ToString();
            var subStartDate = DateTime.Now.ToString("yyyy-MM-dd") + " " + DateTime.Now.ToString("hh:mm:ss");

            if (liqPayInfo.IsSubscribe)
            {
                liqPayData = new LiqPaySubData()
                {
                    public_key = publicKey,
                    version = "3",
                    action = "subscribe",
                    amount = liqPayInfo.Amount,
                    currency = "UAH",
                    description = ConfigurationManager.AppSettings["description"],
                    order_id = orderId,
                    subscribe = liqPayInfo.Amount,
                    subscribe_date_start = subStartDate,
                    subscribe_periodicity = ConfigurationManager.AppSettings["subscribe_periodicity"],
                    result_url = ConfigurationManager.AppSettings["result_url"],
                    server_url = serverUrl,
                    sandbox = int.Parse(ConfigurationManager.AppSettings["test_mode"])

                };
            }
            else
            {
                liqPayData = new LiqPayData()
                {
                    public_key = publicKey,
                    version = "3",
                    action = "pay",
                    amount = liqPayInfo.Amount,
                    currency = "UAH",
                    description = ConfigurationManager.AppSettings["description"],
                    order_id = orderId,
                    result_url = ConfigurationManager.AppSettings["result_url"],
                    server_url = serverUrl,
                    sandbox = int.Parse(ConfigurationManager.AppSettings["test_mode"])
                };
            }

            return liqPayData;
        }
    }
}