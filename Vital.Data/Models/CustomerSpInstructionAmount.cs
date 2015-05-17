using System;
using System.Collections.Generic;

namespace Vital.Data.Models
{
    public partial class CustomerSpInstructionAmount
    {
        public System.Guid Id { get; set; }
        public decimal CustomerAmount { get; set; }
        public System.Guid CustomerId { get; set; }
        public System.Guid SpecialInstructionId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual SpecialInstruction SpecialInstruction { get; set; }
    }
}
