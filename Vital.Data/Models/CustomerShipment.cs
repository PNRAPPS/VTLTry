using System;
using System.Collections.Generic;

namespace Vital.Data.Models
{
    public partial class CustomerShipment : Repository.EntityBase
    {
        public System.Guid Id { get; set; }
        public System.Guid customerId { get; set; }
        public string trackingNumber { get; set; }
        public string pickupNumber { get; set; }
        public DateTime? modifiedDate { get; set; }
        public System.DateTime createdDate { get; set; }
        public string status { get; set; }
        public byte[] shipmentLabel { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
