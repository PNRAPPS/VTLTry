using System;
using System.Collections.Generic;

namespace Vital.Data.Models
{
    public partial class SpecialInstruction
    {
        public SpecialInstruction()
        {
            this.CustomerSpInstructionAmounts = new List<CustomerSpInstructionAmount>();
            this.SpecialInstructionAmounts = new List<SpecialInstructionAmount>();
        }

        public System.Guid Id { get; set; }
        public string SpecialInstructionName { get; set; }
        public virtual ICollection<CustomerSpInstructionAmount> CustomerSpInstructionAmounts { get; set; }
        public virtual ICollection<SpecialInstructionAmount> SpecialInstructionAmounts { get; set; }
    }
}
