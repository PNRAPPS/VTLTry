using System;
using System.Collections.Generic;

namespace Vital.Data.Models
{
    public partial class ZoneRate
    {
        public System.Guid Id { get; set; }
        public string Type { get; set; }
        public double Minimum { get; set; }
        public double Rate { get; set; }
        public int RateYear { get; set; }
        public int ZoneId { get; set; }
        public int WeightId { get; set; }
        public virtual Weight Weight { get; set; }
        public virtual Zone Zone { get; set; }
    }
}
