using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vital.Model
{
    public class QuantumViewImportShipmentDetailsModel
    {
        public string UPSAccountNumber { get; set; }
        public string EntryFiledDate { get; set; }
        public string LeadTrackingNumber { get; set; }
        public string EntryNumber { get; set; }
        public string Images { get; set; }
        public string ShipperName { get; set; }
        public decimal TransportationCharges { get; set; }
        public decimal TotalDuties { get; set; }
        public decimal TaxCharges { get; set; }
        public decimal TotalFees { get; set; }
    }
}
