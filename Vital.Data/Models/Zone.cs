using System;
using System.Collections.Generic;

namespace Vital.Data.Models
{
    public partial class Zone
    {
        public Zone()
        {
            this.PostalCodeZones = new List<PostalCodeZone>();
            this.ZoneDiscountPercentages = new List<ZoneDiscountPercentage>();
            this.ZoneRates = new List<ZoneRate>();
        }

        public int Id { get; set; }
        public string ZoneName { get; set; }
        public virtual ICollection<PostalCodeZone> PostalCodeZones { get; set; }
        public virtual ICollection<ZoneDiscountPercentage> ZoneDiscountPercentages { get; set; }
        public virtual ICollection<ZoneRate> ZoneRates { get; set; }
    }
}
