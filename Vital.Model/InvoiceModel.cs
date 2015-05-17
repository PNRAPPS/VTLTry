using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vital.Model
{
    public class InvoiceModel
    {
        public int invoiceId { get; set; }
        public string invoiceSubject { get; set; }

        public string invoiceDetails { get; set; }
        public System.DateTime invoiceDate { get; set; }
        public byte[] invoiceFileName { get; set; }

        public System.DateTime dateUpload { get; set; }
        public string username { get; set; }
        public string accountnumber { get; set; }
    }
}
