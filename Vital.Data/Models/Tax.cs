using System;
using System.Collections.Generic;

namespace Vital.Data.Models
{
    public partial class Tax
    {
        public System.Guid Id { get; set; }
        public string TaxName { get; set; }
        public string TaxStateAbbreviation { get; set; }
        public string TaxState { get; set; }
        public decimal TaxPercent { get; set; }
    }
}
