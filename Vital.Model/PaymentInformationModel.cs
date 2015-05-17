using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vital.Model
{
    public class PaymentInformationModel
    {
        public string ServiceName { get; set; }
        public string ChargeValue { get; set; }
        public bool IsSelected { get; set; }
        public string EstimatedArrival { get; set; }
        public string Remarks { get; set; }
        public string CurrencyCode { get; set; }
        public string NegotiatedCharges { get; set; }
    }
}
