using System;
using System.Collections.Generic;

namespace Vital.Data.Models
{
    public partial class SpecialInstructionAmount
    {
        public System.Guid Id { get; set; }
        public decimal CarrierAmount { get; set; }
        public System.Guid CarrierId { get; set; }
        public System.Guid SpecialInstructionId { get; set; }
        public virtual Carrier Carrier { get; set; }
        public virtual SpecialInstruction SpecialInstruction { get; set; }
    }
}
