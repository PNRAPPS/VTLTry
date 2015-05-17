using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vital.Model
{
    public class QuantumViewOutboundSummary
    {
        [DisplayName("UPS Account")]
        public string UPSAccount { get; set; }

        [DisplayName("Manifest")]
        public int Manifest { get; set; }

        [DisplayName("In Transit")]
        public int InTransit { get; set; }

        [DisplayName("Out of Deliver")]
        public int OutOfDeliver { get; set; }

        [DisplayName("Ready for Pickup")]
        public int ReadyForPickup { get; set; }

        [DisplayName("Delivered")]
        public int Delivered { get; set; }

        [DisplayName("Exception")]
        public int Exception { get; set; }

        [DisplayName("Void")]
        public int Void { get; set; }

        [DisplayName("Total")]
        public int Total { get; set; }
    }

    public class QuantumViewSummary
    {
        [DisplayName("UPS Account")]
        public string UPSAccount { get; set; }

        [DisplayName("Manifest")]
        public int Manifest { get; set; }

        [DisplayName("In Transit")]
        public int InTransit { get; set; }

        [DisplayName("Out of Deliver")]
        public int OutOfDeliver { get; set; }

        [DisplayName("Ready for Pickup")]
        public int ReadyForPickup { get; set; }

        [DisplayName("Delivered")]
        public int Delivered { get; set; }

        [DisplayName("Exception")]
        public int Exception { get; set; }

        [DisplayName("Void")]
        public int Void { get; set; }

        [DisplayName("Total")]
        public int Total { get; set; }
    }
}
