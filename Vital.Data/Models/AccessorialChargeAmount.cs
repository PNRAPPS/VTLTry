using System;
using System.Collections.Generic;

namespace Vital.Data.Models
{
    public partial class AccessorialChargeAmount
    {
        public System.Guid Id { get; set; }
        public decimal Content { get; set; }
        public string Remarks { get; set; }
        public System.Guid AccessorialChargeId { get; set; }
        public string CustomerAccountId { get; set; }
        public virtual AccessorialCharge AccessorialCharge { get; set; }
        public virtual CustomerAccount CustomerAccount { get; set; }
    }
}
