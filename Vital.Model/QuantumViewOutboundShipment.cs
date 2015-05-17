using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vital.Model
{
    public class QuantumViewOutboundShipment
    {
        public string Type { get; set; }
        public string TrackingNumber { get; set; }
        public string ShipperNumber { get; set; }
        public string ReferenceNumber { get; set; }
        public string Status { get; set; }
        public string ManifestDate { get; set; }
        public string ShipTo { get; set; }
        public string Service { get; set; }
        public string ScheduledDelivery { get; set; }
        public string Images { get; set; }
    }
}
