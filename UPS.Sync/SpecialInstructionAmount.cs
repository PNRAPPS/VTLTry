//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UPS.Sync
{
    using System;
    using System.Collections.Generic;
    
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
