using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vital.Model
{
    public class QuantumViewImportSummaryModel
    {
        public string UPSAccountNumber { get; set; }
        public int NumberOfImports { get; set; }
        public decimal TransportationCharges { get; set; }
        public decimal TotalDuties { get; set; }
        public decimal TotalTaxes { get; set; }
        public decimal TotalFees { get; set; }
    }
}
