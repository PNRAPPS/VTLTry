using System;
using System.Collections.Generic;

namespace Vital.Data.Models
{
    public partial class CustomerAccount : Repository.EntityBase
    {
        public CustomerAccount()
        {
            this.AccessorialChargeAmounts = new List<AccessorialChargeAmount>();
            this.ZoneDiscountPercentages = new List<ZoneDiscountPercentage>();
        }

        public string Id { get; set; }
        public int RateYear { get; set; }
        public bool UPSEnabled { get; set; }
        public System.Guid TermId { get; set; }
        public System.Guid CustomerId { get; set; }
        public virtual ICollection<AccessorialChargeAmount> AccessorialChargeAmounts { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Term Term { get; set; }
        public virtual ICollection<ZoneDiscountPercentage> ZoneDiscountPercentages { get; set; }
    }
}
