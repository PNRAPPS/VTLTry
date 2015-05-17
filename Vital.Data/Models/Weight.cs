using System;
using System.Collections.Generic;

namespace Vital.Data.Models
{
    public partial class Weight
    {
        public Weight()
        {
            this.ZoneRates = new List<ZoneRate>();
        }

        public int Id { get; set; }
        public int Low { get; set; }
        public int High { get; set; }
        public virtual ICollection<ZoneRate> ZoneRates { get; set; }
    }
}
