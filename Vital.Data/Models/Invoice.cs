using System;
using System.Collections.Generic;

namespace Vital.Data.Models
{
    public partial class Invoice : Repository.EntityBase
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
