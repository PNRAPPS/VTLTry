using System;
using System.Collections.Generic;

namespace Vital.Data.Models
{
    public partial class Carrier
    {
        public Carrier()
        {
            this.ShipmentRequests = new List<ShipmentRequest>();
            this.SkidRates = new List<SkidRate>();
            this.SpecialInstructionAmounts = new List<SpecialInstructionAmount>();
        }

        public System.Guid Id { get; set; }
        public string BillToAdd { get; set; }
        public string Company { get; set; }
        public string AccountNumber { get; set; }
        public string ContactPerson { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public virtual ICollection<ShipmentRequest> ShipmentRequests { get; set; }
        public virtual ICollection<SkidRate> SkidRates { get; set; }
        public virtual ICollection<SpecialInstructionAmount> SpecialInstructionAmounts { get; set; }
    }
}
