using System;
using System.Collections.Generic;

namespace Vital.Data.Models
{
    public partial class CustomerMarkup
    {
        public System.Guid Id { get; set; }
        public decimal MarkupPercentage { get; set; }
        public System.Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
