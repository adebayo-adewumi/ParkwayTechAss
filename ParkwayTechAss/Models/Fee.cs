using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ParkwayTechAss.Models
{
    public partial class Fee
    {
        [JsonProperty("fees")]
        public Fee[] Fees { get; set; }
    }

    public partial class FeeElement
    {
        [JsonProperty("minAmount")]
        public long MinAmount { get; set; }

        [JsonProperty("maxAmount")]
        public long MaxAmount { get; set; }

        [JsonProperty("feeAmount")]
        public long FeeAmount { get; set; }
    }
}
