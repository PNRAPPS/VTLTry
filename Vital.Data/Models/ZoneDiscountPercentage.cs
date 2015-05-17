using System;
using System.Collections.Generic;

namespace Vital.Data.Models
{
    public partial class ZoneDiscountPercentage
    {
        public System.Guid Id { get; set; }
        public double Content { get; set; }
        public double PAKDiscountPercentage { get; set; }
        public double LTRDiscountPercentage { get; set; }
        public string CustomerAccountId { get; set; }
        public int ZoneId { get; set; }
        public virtual CustomerAccount CustomerAccount { get; set; }
        public virtual Zone Zone { get; set; }
    }
}
