using System;
using System.Collections.Generic;

namespace Vital.Data.Models
{
    public partial class AccessorialCharge
    {
        public AccessorialCharge()
        {
            this.AccessorialChargeAmounts = new List<AccessorialChargeAmount>();
        }

        public System.Guid Id { get; set; }
        public string AccessorialChargeName { get; set; }
        public virtual ICollection<AccessorialChargeAmount> AccessorialChargeAmounts { get; set; }
    }
}
