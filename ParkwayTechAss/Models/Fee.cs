using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ParkwayTechAss.Models
{
    public class FeeElement
    {
        public decimal Amount { get; set; }
        public decimal TransferAmount { get; set; }
        public decimal Charge { get; set; }
        public decimal DebitAmount { get; set; }
    }
}
