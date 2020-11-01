using System;
using System.Web;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ParkwayTechAss.Models;
using System.Data;
using Microsoft.VisualBasic;

namespace ParkwayTechAss.Controllers
{
    public class FeeCalculatorController : Controller
    {
        private decimal expectedAmount;
        private decimal charge;
        public IActionResult Index()
        {
            var fc = CalculateCharge("4900");
            return View(fc);
        }

        public JsonResult CalculateCharge(string amount)
        {
            var amt = Convert.ToDecimal(amount);
            using (StreamReader sr = System.IO.File.OpenText("FeeConfig\\fees.config1.json"))
            using (JsonTextReader reader = new JsonTextReader(sr))
            {
                JObject o = (JObject)JToken.ReadFrom(reader);

                foreach (var f in o["fees"])
                {
                    if(amt < (decimal)f["maxAmount"])
                    {
                        charge = (decimal)f["feeAmount"];
                        break;
                    }
                }

                return Json(charge);
            }
        }

        public JsonResult CalculateSurCharge(string amount)
        {
            var amt = Convert.ToDecimal(amount);
            using (StreamReader sr = System.IO.File.OpenText("FeeConfig\\fees.config1.json"))
            using (JsonTextReader reader = new JsonTextReader(sr))
            {
                JObject o = (JObject)JToken.ReadFrom(reader);

                foreach (var f in o["fees"])
                {
                    if (amt < (decimal)f["maxAmount"])
                    {
                        expectedAmount = amt - (decimal)f["feeAmount"];
                        break;
                    }
                }

                return Json(expectedAmount);
            }
        }
    }
}
