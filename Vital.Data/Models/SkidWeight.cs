using System;
using System.Collections.Generic;

namespace Vital.Data.Models
{
    public partial class SkidWeight : Repository.EntityBase
    {
        public SkidWeight()
        {
            this.SkidRates = new List<SkidRate>();
        }

        public int Id { get; set; }
        public string Label { get; set; }
        public decimal Low { get; set; }
        public decimal High { get; set; }
        public virtual ICollection<SkidRate> SkidRates { get; set; }
    }
}
