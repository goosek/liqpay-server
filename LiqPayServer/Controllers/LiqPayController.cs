using LiqPayServer.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using LiqPayServer.Utils;

namespace LiqPayServer.Controllers
{
    [RoutePrefix("liqpay")]
    public class LiqPayController : ApiController
    {
        readonly string _donatePrivateKey = ConfigurationManager.AppSettings["donatePrivateKey"];
        readonly string _donatePublicKey = ConfigurationManager.AppSettings["donatePublicKey"];
        readonly string _donateServerUrl = ConfigurationManager.AppSettings["donate_server_url"];
        const string _parentsPayer = "Parents";

        [HttpGet]
        [Route("liqpayinfo")]
        public HttpResponseMessage LiqpayInfo()
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("create-donate-liqpayinfo")]
        public HttpResponseMessage CreateDonateLiqpayInfo(LiqPayPostInfo liqPayInfo)
        {
            try
            {
                ILiqPayData liqPayData;
                string data;
                string signature;

                liqPayData = DataHelper.CreateLiqPayData(liqPayInfo, _donatePublicKey, _donateServerUrl);
                data = Convert.ToBase64String(Encoding.UTF8.GetBytes(new JavaScriptSerializer().Serialize(liqPayData)));
                signature = Convert.ToBase64String(SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(_donatePrivateKey + data + _donatePrivateKey)));

                using (LiqPayDBEntities db = new LiqPayDBEntities())
                {
                    db.rl_liqpay_donate_info.Add(new rl_liqpay_donate_info()
                    {
                        Action = liqPayData.action,
                        Amount = liqPayData.amount,
                        Currency = liqPayData.currency,
                        Email = liqPayInfo.Email,
                        Name = liqPayInfo.Name,
                        Order_id = liqPayData.order_id,
                        Signature = signature,
                        Status = "not paid yet",
                        Subscribe_amount = liqPayInfo.IsSubscribe ? liqPayInfo.Amount : 0,
                        Subscribe_date_start = liqPayInfo.IsSubscribe ? ((LiqPaySubData)liqPayData)?.subscribe_date_start : "",
                        Subscribe_periodicity = liqPayInfo.IsSubscribe ? "month" : "",
                        TypeOfPayer = liqPayInfo.TypeOfPayer,
                        Created_Date = DateTime.Now,
                    });
                    db.SaveChanges();
                }

                return Request.CreateResponse(HttpStatusCode.OK,
                new LiqPayInfo()
                {
                    Data = data,
                    Signature = signature
                });
            }
            catch(Exception ex)
            {
                using (LiqPayDBEntities db = new LiqPayDBEntities())
                {
                    db.Errors.Add(new Errors()
                    {
                        ErrorDate = DateTime.Now,
                        ErrorMessage = ex.Message,
                        ErrorInfo = ex.StackTrace
                    });
                    db.SaveChanges();
                }

                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [Route("donate-callback")]
        public HttpResponseMessage DonateCallBack(LiqPayInfo liqPayCallBack)
        {
            try
            {
                var data = System.Text.Encoding.Default.GetString(Convert.FromBase64String(liqPayCallBack.Data));
                dynamic dataObject = JObject.Parse(data);
                string serverSignature;
               
                using (LiqPayDBEntities db = new LiqPayDBEntities())
                {
                    var order_id = (string)dataObject?.order_id;
                    var liqpayPayInfo = db.rl_liqpay_donate_info.FirstOrDefault(p => p.Order_id == order_id);

                    serverSignature = Convert.ToBase64String(SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(_donatePrivateKey + liqPayCallBack.Data + _donatePrivateKey)));

                    if (serverSignature == liqPayCallBack.Signature)
                    {
                        if (liqpayPayInfo.Status != "not paid yet")
                        {
                            string description = "";
                            try
                            {
                                description = Encoding.UTF8.GetString(Encoding.GetEncoding(1252).GetBytes(dataObject?.description == null ? "" : dataObject?.description));
                            }
                            catch(Exception ex)
                            {

                            }

                            db.rl_liqpay_donate_info.Add(new rl_liqpay_donate_info
                            {
                                Status = dataObject?.status,
                                Agent_commission = dataObject?.agent_commission,
                                Receiver_commission = dataObject?.receiver_commission,
                                Sender_commission = dataObject?.sender_commission,
                                Sender_card_country = dataObject?.sender_card_country,
                                Amount = dataObject?.amount,
                                Ip = dataObject?.ip,
                                Description = description,
                                Action = dataObject?.action,
                                Currency = dataObject?.currency,
                                Email = liqpayPayInfo?.Email,
                                JsonData = data,
                                Name = liqpayPayInfo?.Name,
                                Order_id = dataObject?.order_id,
                                Signature = liqPayCallBack?.Signature,
                                PaimentDate = DateTime.Now,
                                TypeOfPayer = liqpayPayInfo?.TypeOfPayer,
                            });
                        }
                        else
                        {
                            liqpayPayInfo.Status = dataObject?.status;
                            liqpayPayInfo.JsonData = data;
                            liqpayPayInfo.Description = dataObject?.description;
                            liqpayPayInfo.Agent_commission = dataObject?.agent_commission;
                            liqpayPayInfo.Receiver_commission = dataObject?.receiver_commission;
                            liqpayPayInfo.Sender_commission = dataObject?.sender_commission;
                            liqpayPayInfo.Sender_card_country = dataObject?.sender_card_country;
                            liqpayPayInfo.Ip = dataObject?.ip;
                            liqpayPayInfo.PaimentDate = DateTime.Now;
                        }
                    }
                    db.SaveChanges();
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch(Exception ex)
            {
                using (LiqPayDBEntities db = new LiqPayDBEntities())
                {
                    db.Errors.Add(new Errors() {
                        ErrorDate = DateTime.Now,
                        ErrorMessage = ex.Message,
                        ErrorInfo = ex.StackTrace
                    });

                    db.SaveChanges();
                }

                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}
