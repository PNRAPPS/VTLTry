using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vital.Model
{
    public class QuantumViewInboundModel
    {
        public List<QuantumViewInboundSummaryModel> InboundSummary { get; set; }
        public List<QuantumViewInboundShipmentDetailsModel> ShipmentDetails { get; set; }
    }

    public class QuantumViewInboundSummaryModel
    {
        public string LocationID { get; set; }
        public int Total { get; set; }
    }

    public class QuantumViewInboundShipmentDetailsModel
    {
        public string TrackingNumber { get; set; }
        public string ReferenceNumber { get; set; }
        public string Status { get; set; }
        public string ManifestDate { get; set; }
        public string ShipTo { get; set; }
        public string Service { get; set; }
        public string ScheduledDelivery { get; set; }
        public string Images { get; set; }
    }
}
