using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vital.Model
{
    public class QuantumViewShipmentDetail
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

        public string ShipmentEvent { get; set; }
        public string SignedBy { get; set; }
        public string ShipToAttention { get; set; }
        public string ShipToAddressLine1 { get; set; }
        public string ShipToAddressLine2 { get; set; }
        public string ShipToTelephoneNumber { get; set; }
        public string ShipToCity { get; set; }
        public string ShipToStateProvince { get; set; }
        public string ShipToPostalCode { get; set; }
        public string ShipToCountry { get; set; }
        public string ExceptionDescription { get; set; }
        public string ShipToName { get; set; }
    }
}
