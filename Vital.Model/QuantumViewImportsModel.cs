using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vital.Model
{
    public class QuantumViewImportsModel
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

        [DisplayName("Summary")]
        public List<QuantumViewImportSummaryModel> ImportSummary { get; set; }

        [DisplayName("Shipment Details")]
        public List<QuantumViewImportShipmentDetailsModel> ImportShipmentDetails { get; set; }
    }
}
