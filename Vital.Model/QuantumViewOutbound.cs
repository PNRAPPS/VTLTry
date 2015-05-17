using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vital.Model
{
    public class QuantumViewOutbound
    {
        [DisplayName("View")]
        public string OutboundView { get; set; }

        [DisplayName("From")]
        public string FromDate { get; set; }

        [DisplayName("To")]
        public string ToDate { get; set; }

        [DisplayName("Search")]
        public string SearchTag { get; set; }

        [DisplayName("Filter")]
        public string SearchFilter { get; set; }

        public List<QuantumViewOutboundSummary> OutboundSummary { get; set; }
        public List<QuantumViewOutboundShipment> OutboundShipmentDetails { get; set; }
        public List<QuantumViewOutboundShipment> InboundShipmentDetails { get; set; }
        public List<QuantumViewOutboundShipment> CombinedShipmentDetails { get; set; }

        public QuantumViewOutbound()
        {
            OutboundSummary = new List<QuantumViewOutboundSummary>();
            OutboundShipmentDetails = new List<QuantumViewOutboundShipment>();
            InboundShipmentDetails = new List<QuantumViewOutboundShipment>();
            CombinedShipmentDetails = new List<QuantumViewOutboundShipment>();
        }
    }
}
