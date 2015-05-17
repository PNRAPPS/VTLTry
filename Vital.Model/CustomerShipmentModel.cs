using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vital.Model
{
    public class CustomerShipmentModel
    {
        public System.Guid Id { get; set; }
        public System.Guid customerId { get; set; }
        public string trackingNumber { get; set; }
        public string pickupNumber { get; set; }
        public System.DateTime createdDate { get; set; }
        public string status { get; set; }
        public byte[] shipmentLabel { get; set; }
    }
}
